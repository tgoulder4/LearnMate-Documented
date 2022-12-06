using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Newtonsoft.Json;
using static LearnMate.backend;

namespace LearnMate

{
    public partial class frmLoginScreen : Form
    {
        backend Backend = new backend(); //only instantiation of the database.

        //Foreign code for the round borders, no borders and form drag.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public string enteredUsername;
        public string enteredPassword;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
            );
        //end foreign code.


        public frmLoginScreen()
        {
            InitializeComponent();

            //Sets the round borders
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));


            //setting stronger accessibility colours
            txtUsername.BackColor = Color.FromArgb(192, 220, 204);
            txtUsername.ForeColor = Color.FromArgb(48, 48, 48);
            txtPassword.BackColor = Color.FromArgb(192, 220, 204);
            txtPassword.ForeColor = Color.FromArgb(48, 48, 48);


            //The following generates a random image for the background to show different slides.
            //centres the image to the centre of the screen. 
            Random r = new();
            int rInt = r.Next(0, 3);

            if (rInt == 0)
            {
                this.BackgroundImage = Image.FromFile("Login31.jpg");

            }
            if (rInt == 1)
            {
                this.BackgroundImage = Image.FromFile("Login11.jpg");
            }
            else if (rInt == 2)
            {
                this.BackgroundImage = Image.FromFile("Login21.jpg");

            }
            this.CenterToScreen();



        }

        public void btnBegin_Click(object sender, EventArgs e)
        {
            enteredUsername = txtUsername.Text;
            enteredPassword = txtPassword.Text;
            //backend.Login(txtUsername.Text, txtPassword.Text);
            //if returned true, load the correct form(s)
            //load cmd to see comms between backend and form
            bool LoginResult;
            LoginResult = Backend.login(enteredUsername,enteredPassword); //login result is stored

            if (LoginResult) //if login returns true (the login was successful)
            {
                int enteredUserID=Backend.getUserIDWithUsername(enteredUsername);
                string enteredInstitutionCode=""; //so that the current user can be set with an institutioncode if they're a member of the school. 
                //(elements in the container form will require current user information) 
                bool success=false; //success means if they have been found to be part of a school
                
                if (Backend.checkUserType(enteredUserID)=="Student" || Backend.checkUserType(enteredUserID)=="Teacher") //if they're a student or a teacher
                {
                    //for every school,
                    for (int i = Schools.Count - 1; i >= 0; i--)
                    {
                        //for every class
                        for (int j = Schools[i].classesInSchool.Count - 1; j >= 0; j--)
                        {
                            //for every student
                            for (int l = Schools[i].classesInSchool[j].Students.Count - 1; l >= 0; l--)
                            {
                                if (Schools[i].classesInSchool[j].Students[l].userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                } //if the student is found to be present in that class, success is true.
                            }

                            if (Schools[i].classesInSchool[j].mainTeacher != null) //same applies for teachers and assitant teacher if the user logging in is of that user type.
                            {
                                if (Schools[i].classesInSchool[j].mainTeacher.userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }
                            if (Schools[i].classesInSchool[j].assistantTeacher != null)
                            {
                                if (Schools[i].classesInSchool[j].assistantTeacher.userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }
                        }

                        if (Backend.checkUserType(enteredUserID) == "Student") //if they're a student, make sure to check the unassigned student list too
                        {
                            for (int k = Schools[i].unassignedStudents.Count - 1; k >= 0; k--)
                            {
                                if (Schools[i].unassignedStudents[k].userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }
                        }
                        else
                        {
                            for (int k = Schools[i].unassignedTeachers.Count - 1; k >= 0; k--) //same goes for if they're poitentially an unassigned teacher.
                            {
                                if (Schools[i].unassignedTeachers[k].userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }
                        }

                    }

                    if (success) //if they were found to be a part of a school,
                    {
                        Backend.setCurrentUserWithSchool(enteredUserID, enteredInstitutionCode); //tell the backend to set the current user's school information as required.
                                                                                                 //This is so that elements such as "my school" in the panel show their current school.
                    }
                    else
                    {
                        Backend.setCurrentUser(enteredUserID);
                    }
                }
                else
                {
                    Backend.setCurrentUser(enteredUserID);
                }
                frmContainer container = new frmContainer(this,Backend);
                container.Location = this.Location;
                container.Show();
                container.refreshAllElements();


                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect login.");
            }

        }
        
        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void LoginScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            frmContainer container = new frmContainer(this,Backend);
            subFrmSignUp SignUpForm = new subFrmSignUp(this,container,Backend);
            SignUpForm.StartPosition = FormStartPosition.CenterScreen;
            SignUpForm.Show();
        }

        private void btnBegin_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnBegin_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnBegin_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void lblSignUp_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblSignUp_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

        }
    } 
}
