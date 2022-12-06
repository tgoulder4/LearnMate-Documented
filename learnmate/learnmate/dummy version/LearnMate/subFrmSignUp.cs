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

            //references to existing objects
            loginREF = login;
            backendREF = backend;
            containerREF = container;

            this.Location = loginREF.Location;

            lblInstitution.Visible = false;
            txtInstitution.Visible = false;
            lblType.Visible = true;
            txtName.Visible = false;
            lblName.Visible = false;
            lblUsername.Visible = true;
            txtPassword.Visible = true;
            txtSchoolName.Visible = false;
            lblSchoolName.Visible = false;
            
            lblStage.Text = "Glad you chose us!";
            btnBegin.Text = "Next";
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
            containerREF.Location = loginREF.Location;
            //the below code may cause an error as users are created AFTER 
            containerREF.Show();
            loginREF.Hide();
            this.TopMost = true;

        }
        private void btnBegin_Click(object sender, EventArgs e)
        {
            //add user to database e.g. backend.AddUserToDB(.,.,.)
            //THEN run login function in backend class e.g. backend.Login(.,.,.)


            //as first time login, if user is a teacher, load frmManageClasses into container so they can start forming their groups of students.
            //trying to do this part below:


            if (currentStage == 1) //move onto entering their school info if they're a teacher or a student.
            {
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
                    lblInstitution.Visible = true;
                    txtInstitution.Visible = true;
                    lblStage.Text = "What school do you belong to?";
                    btnBegin.Text = "Next";

                    if (!backendREF.checkAnySchoolExists())
                    {
                        if (enteredUserType == "Teacher") //if no schools exist, a teacher can create a new school
                        {
                            TeacherResponse = MessageBox.Show("Its been detected that there are no schools available. Do you want to create a new school?", "Notice", MessageBoxButtons.YesNoCancel);

                            if (TeacherResponse == DialogResult.Yes)
                            {
                                CreatingANewSchool = true;
                                withoutSchool = false;
                                txtSchoolName.Visible = true;
                                lblSchoolName.Visible = true;
                                lblStage.Text = "What school do you want to create?";
                            }
                            else if (TeacherResponse == DialogResult.No)
                            {
                                withoutSchool = true;
                            }
                        }
                        else if (enteredUserType == "Student")
                        {
                            withoutSchool = true;
                            MessageBox.Show("You're being entered without a school as none exist.");
                        }

                    }
                }
                else if (enteredUserType=="Home Learner")
                {
                    lblName.Visible = true;
                    txtName.Visible = true;
                    lblStage.Text = "What should we call you?";
                    btnBegin.Text = "Get Started!";
                    btnBegin.BackColor = Color.DarkSeaGreen;
                }

                currentStage += 1;
            }

            else if (currentStage == 2) //they move to stage 3: entering their name
            {

                if (enteredUserType == "Teacher" || enteredUserType == "Student")
                {
                    if (!withoutSchool)
                    {
                        enteredInstitutionCode = txtInstitution.Text;

                        if (CreatingANewSchool)
                        {
                            enteredInstitutionCode = txtInstitution.Text;
                            txtInstitution.Visible = false;
                            lblInstitution.Visible = false;

                            enteredSchoolName = txtSchoolName.Text;
                            txtSchoolName.Visible = false;
                            lblSchoolName.Visible = false;

                            lblStage.Text = "What should we call you?";
                            lblName.Visible = true;
                            txtName.Visible = true;
                            btnBegin.BackColor = Color.DarkSeaGreen;
                            btnBegin.Text = "Empower young minds!";
                            currentStage += 1;
                        }
                        else if (!backendREF.checkASchoolexists(enteredInstitutionCode) && enteredUserType == "Teacher")
                        {
                            TeacherResponse = MessageBox.Show("Its been detected that that school doesn't exist. Do you want to create a new school?", "Notice", MessageBoxButtons.YesNo);
                            if (TeacherResponse == DialogResult.Yes) //dont add a currentstage so that 
                            {
                                CreatingANewSchool = true;
                                txtSchoolName.Visible = true;
                                lblSchoolName.Visible = true;
                                lblInstitution.Visible = true;
                                txtInstitution.Visible = true;
                                lblStage.Text = "What school do you want to create?";

                            }
                            else if (TeacherResponse == DialogResult.No)
                            {
                                withoutSchool = true;
                                lblStage.Text = "What should we call you?";
                                lblName.Visible = true;
                                txtName.Visible = true;
                                btnBegin.BackColor = Color.DarkSeaGreen;
                                lblInstitution.Visible = false;
                                txtInstitution.Visible = false;
                                currentStage += 1;
                                btnBegin.Text = "Empower young minds!";
                            }
                        }
                        else if (backendREF.checkASchoolexists(enteredInstitutionCode) && enteredUserType == "Teacher")
                        {
                            enteredSchoolName = txtSchoolName.Text;
                            enteredInstitutionCode = txtInstitution.Text;
                            txtInstitution.Visible = false;
                            lblInstitution.Visible = false;

                            lblStage.Text = "What should we call you?";
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
                                MessageBox.Show("That school doesn't exist. Ask a teacher to set one up for you!");
                            }
                            else
                            {
                                btnBegin.Text = "Boost my grades!";
                                txtInstitution.Visible = false;
                                lblInstitution.Visible = false;
                                lblStage.Text = "What should we call you?";
                                lblName.Visible = true;
                                txtName.Visible = true;
                                btnBegin.BackColor = Color.DarkSeaGreen;
                                currentStage += 1;
                            }
                        }
                    }

                }
                else
                {
                    enteredName = txtName.Text;
                    backend.HomeLearner homelearner = new backend.HomeLearner(enteredUsername, enteredPassword, enteredName);
                    backendREF.setCurrentUser(homelearner.userID); //calls getname throwing errors sometimes
                    moveToContainer();
                }

            }


            else if (currentStage == 3) //THIRD STAGE: MOVE TO HOMEPAGE
            {
                enteredName = txtName.Text;
                
                //they ARE a teacher or a student here
                //NEW STAGE 3 CODE
                    
                if (enteredUserType == "Teacher")
                {
                    if (CreatingANewSchool)
                    {
                        //create relationship
                        backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                        backend.School school = new backend.School(enteredSchoolName, enteredInstitutionCode);

                        teacher.schoolID = school.schoolID;
                        teacher.replaceInUsersList();
                        school.unassignedTeachers.Add(teacher);
                        school.replaceInSchoolsList();
                        backendREF.setCurrentUserWithSchool(teacher.userID, school.InstitutionCode); //sets current user ID. sets all the current info used within container.

                    }
                    else if (withoutSchool)
                    {
                        backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                        backendREF.setCurrentUser(teacher.userID); //calls getname throwing errors sometimes
                    }
                    else if (!withoutSchool)
                    {
                        if (enteredUserType == "Teacher")
                        {
                            School school = Schools[backendREF.getSchoolID(enteredInstitutionCode) - 1];
                            backend.Teacher teacher = new backend.Teacher(enteredUsername, enteredPassword, enteredName);
                            teacher.schoolID = school.schoolID;
                            school.unassignedTeachers.Add(teacher);
                            school.replaceInSchoolsList();
                            backendREF.setCurrentUserWithSchool(teacher.userID,school.InstitutionCode); //sets current user ID. sets all the current info used within container.
                        }
                    }
                }

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
                moveToContainer(); //position of this may cause object reference error
                this.Hide();
            }        
        }
    }
}
