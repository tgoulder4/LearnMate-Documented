using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LearnMate.backend;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LearnMate
{
    public partial class subFrmSignUp : Form
    {

        //if the user signs up, the container obejct is created during the SIGN UP FORM
        //if they don't, the container object is created from the LOGIN SCREEN
        public frmContainer containerREF;
        public frmLoginScreen loginREF;
        public backend backendREF;
        public int currentStage=1;
        public string enteredUsername;
        public string enteredPassword;
        public string enteredInstitutionCode;
        public string enteredUserType;
        public string enteredName;
        public string enteredSchoolName;
        public int index;
        public DialogResult StudentResponse;
        public DialogResult TeacherResponse;
        public bool CreatingANewSchool = false;
        public bool withoutSchool = false;


        public subFrmSignUp(frmLoginScreen login, frmContainer container, backend backend)
        {
            InitializeComponent();

            //references to existing objects to access their methods
            loginREF = login;
            backendREF = backend;
            containerREF = container;

            this.Location = loginREF.Location;

            lblInstitution.Visible = false; //hide labels and textboxes corresponding to stages which aren't the first.
            txtInstitution.Visible = false;
            txtName.Visible = false;
            lblName.Visible = false;

            txtSchoolName.Visible = false;
            lblSchoolName.Visible = false;
            
            //first stage's controls
            lblStage.Text = "Glad you chose us!";
            btnBegin.Text = "Next";
            lblUsername.Visible = true;
            txtPassword.Visible = true;
            lblType.Visible = true;
        }

        //the following code changes the position of the controls depending on which type of user they say they are.
        //e.g. if they're a teacher, they also have to enter their institution code in a textbox which was hidden and will be shown at the bottom
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbType.SelectedItem)=="Student")
            {
                enteredUserType = "Student";
            }
            else if (Convert.ToString(cmbType.SelectedItem) == "Teacher")
            {
                enteredUserType = "Teacher";
            }
            else
            {
                enteredUserType = "Home Learner";
            }
        }

        void moveToContainer()
        {
            containerREF.Location = loginREF.Location; //position of the container will be of the same position as this form
            containerREF.Show();
            loginREF.Hide();
            this.TopMost = true; //container form is shown

        }
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (currentStage == 1) //if they were on the first screen (STAGE) when clicking the button,
            {
                //all the current stage controls are removed,
                enteredUsername = txtUsername.Text;
                lblUsername.Visible = false;
                txtUsername.Visible = false;

                enteredPassword = txtPassword.Text;
                txtPassword.Visible = false;
                lblPassword.Visible = false;

                enteredUserType = cmbType.Text;
                lblType.Visible = false;
                cmbType.Visible = false;

                if (enteredUserType == "Teacher" || enteredUserType == "Student")
                {
                    //a member of a school is required to enter their institution code for the second stage of signing up.
                    lblInstitution.Visible = true;
                    txtInstitution.Visible = true;
                    lblStage.Text = "What school do you belong to?";
                    btnBegin.Text = "Next";

                    if (!backendREF.checkAnySchoolExists()) //if no schools exist, prompt a teacher to make a new school or a student that they are without a school.
                    {
                        if (enteredUserType == "Teacher") //if no schools exist, a teacher can create a new school
                        {
                            TeacherResponse = MessageBox.Show("Its been detected that there are no schools available. Do you want to create a new school?", "Notice", MessageBoxButtons.YesNoCancel); //teachers have the option to create a new school

                            if (TeacherResponse == DialogResult.Yes)
                            {
                                CreatingANewSchool = true; //an extra stage is added as the next one if they answered yes. They are asked information about the school they're creating
                                withoutSchool = false;
                                txtSchoolName.Visible = true;
                                lblSchoolName.Visible = true;
                                lblStage.Text = "What school do you want to create?";
                            }
                            else if (TeacherResponse == DialogResult.No)
                            {
                                withoutSchool = true; //they are entered without a school and can affiliate later.
                            }
                        }
                        else if (enteredUserType == "Student")
                        {
                            withoutSchool = true;
                            MessageBox.Show("You're being entered without a school as none exist.");
                        }

                    }
                }
                else if (enteredUserType=="Home Learner") //home learners move to the name stage as they don't belong to a school and therefore don't have to enter their isntitution code.
                {
                    lblName.Visible = true;
                    txtName.Visible = true;
                    lblStage.Text = "What should we call you?";
                    btnBegin.Text = "Get Started!";
                    btnBegin.BackColor = Color.DarkGreen;
                }

                currentStage += 1;
            }

            else if (currentStage == 2) //they move to stage 3: entering their name
            {

                if (enteredUserType == "Teacher" || enteredUserType == "Student") //if they're a teacher or student,
                {
                    if (!withoutSchool) //if they weren part of a school,
                    {
                        enteredInstitutionCode = txtInstitution.Text; //the enteredIns is what the ins they entered.

                        if (CreatingANewSchool) //if the teacher is making a new school,
                        {
                            enteredInstitutionCode = txtInstitution.Text; //the new school information they entered is saved.
                            txtInstitution.Visible = false;
                            lblInstitution.Visible = false;

                            enteredSchoolName = txtSchoolName.Text;
                            txtSchoolName.Visible = false;
                            lblSchoolName.Visible = false;

                            lblStage.Text = "What should we call you?"; //moves onto entering their name
                            lblName.Visible = true;
                            txtName.Visible = true;
                            btnBegin.BackColor = Color.DarkSeaGreen;
                            btnBegin.Text = "Empower young minds!";
                            currentStage += 1;
                        }
                        else if (!backendREF.checkASchoolexists(enteredInstitutionCode) && enteredUserType == "Teacher") //if the school they entered doesn't match a school, teachers have the permissions to make a new one.
                        {
                            TeacherResponse = MessageBox.Show("Its been detected that that school doesn't exist. Do you want to create a new school?", "Notice", MessageBoxButtons.YesNo); //their decision
                            if (TeacherResponse == DialogResult.Yes) //dont add a currentstage so that 
                            {
                                CreatingANewSchool = true;
                                txtSchoolName.Visible = true;
                                lblSchoolName.Visible = true;
                                lblInstitution.Visible = true;
                                txtInstitution.Visible = true;
                                lblStage.Text = "What school do you want to create?"; //creating school form

                            }
                            else if (TeacherResponse == DialogResult.No) //if they don't want to make a new school and entered a wrong ins code, they are entered through as 'school-less'
                            {
                                withoutSchool = true;
                                lblStage.Text = "What should we call you?"; //moves onto entering their name
                                lblName.Visible = true;
                                txtName.Visible = true;
                                btnBegin.BackColor = Color.DarkSeaGreen;
                                lblInstitution.Visible = false;
                                txtInstitution.Visible = false;
                                currentStage += 1; //so that when its called again from the presented stage, they will be shown the next stage
                                btnBegin.Text = "Empower young minds!";
                            }
                        }
                        else if (backendREF.checkASchoolexists(enteredInstitutionCode) && enteredUserType == "Teacher") //if the school they enetered does exist
                        {
                            enteredSchoolName = txtSchoolName.Text;
                            enteredInstitutionCode = txtInstitution.Text; //their entered ins code is saved to be added to the current user information stored in backend upon account creation.
                            txtInstitution.Visible = false;
                            lblInstitution.Visible = false;

                            lblStage.Text = "What should we call you?"; //moves onto entering their name
                            lblName.Visible = true;
                            txtName.Visible = true;
                            btnBegin.BackColor = Color.DarkSeaGreen;
                            btnBegin.Text = "Empower young minds!";
                            currentStage += 1;
                        }

                        else if (enteredUserType == "Student")
                        {
                            if (!backendREF.checkASchoolexists(enteredInstitutionCode))
                            {
                                MessageBox.Show("That school doesn't exist. Ask a teacher to set one up for you!"); //if a student enters a wrong school and schools exist, they have to try again. 
                            }
                            else
                            {
                                btnBegin.Text = "Boost my grades!";
                                txtInstitution.Visible = false;
                                lblInstitution.Visible = false;
                                lblStage.Text = "What should we call you?"; //moves onto entering their name
                                lblName.Visible = true;
                                txtName.Visible = true;
                                btnBegin.BackColor = Color.DarkGreen;
                                currentStage += 1;
                            }
                        }
                    }

                }
                else //if they're a homelearner, they will move onto the container form already. 
                {
                    enteredName = txtName.Text;
                    backend.HomeLearner homelearner = new backend.HomeLearner(enteredUsername, enteredPassword, enteredName); //a new home learner instance is created.
                    backendREF.setCurrentUser(homelearner.userID); //the current user information stored in backend is updated to show the user signing up is now the current user.
                    moveToContainer();
                }

            }


            else if (currentStage == 3) //THIRD STAGE: MOVE TO HOMEPAGE
            {
                enteredName = txtName.Text;
                
                //they ARE a teacher or a student here
                //NEW STAGE 3 CODE
                    
                if (enteredUserType == "Teacher") //if they're a teacher, 
                {
                    if (CreatingANewSchool) //and creating a new school,
                    {
                        //create a new teacher and school with the entered information they provided
                        backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                        backend.School school = new backend.School(enteredSchoolName, enteredInstitutionCode);

                        //set attributes of each depending on what was entered
                        teacher.schoolID = school.schoolID; 
                        teacher.replaceInUsersList();
                        school.unassignedTeachers.Add(teacher);
                        school.replaceInSchoolsList();
                        backendREF.setCurrentUserWithSchool(teacher.userID, school.InstitutionCode); //sets current user ID. sets all the current info used within container.

                    }
                    else if (withoutSchool) //if they're a teacher adn without a school,
                    {
                        //a new teacher is created. they are not set to a school.
                        backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                        backendREF.setCurrentUser(teacher.userID); //the current user is set
                    }
                    else if (!withoutSchool) 
                    {
                        if (enteredUserType == "Teacher")
                        {
                            //if they're a teacher, their schoolID is set to the schoolID which they entered. 
                            //they are added as an unassigned teacher like all members are.
                            //school is updated to reflect changes and maintain data consistency.
                            //data is set so the backend knows the current user who's logged in.
                            School school = Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1];
                            backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                            teacher.schoolID = school.schoolID;
                            school.unassignedTeachers.Add(teacher);
                            school.replaceInSchoolsList();
                            backendREF.setCurrentUserWithSchool(teacher.userID,school.InstitutionCode); //sets current user ID. sets all the current info used within container.
                        }
                    }
                }
                //the above explaination can be applied below
                else if (enteredUserType == "Student")
                {
                    if (withoutSchool)
                    {
                        backend.Student student = new backend.Student(enteredUsername, enteredPassword, enteredName);
                        student.schoolID = Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1].schoolID;
                        student.replaceInUsersList();
                        backendREF.setCurrentUser(student.userID); //sets current user ID. sets all the current info used within container.
                    }
                    else if (!withoutSchool)
                    {
                        School school = Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1];
                        backend.Student student = new backend.Student(enteredUsername, enteredPassword, enteredName);
                        student.schoolID= Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1].schoolID;
                        student.replaceInUsersList();
                        school.unassignedStudents.Add(student);
                        school.replaceInSchoolsList();
                        Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1] = school;
                        backendREF.setCurrentUserWithSchool(student.userID, enteredInstitutionCode);
                    }
                }
                containerREF.refreshAllElements(); //copies backend info to elements
                moveToContainer();
                this.Hide();
            }        
        }
    }
}
