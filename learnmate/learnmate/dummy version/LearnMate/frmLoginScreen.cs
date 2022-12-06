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
        backend Backend = new backend(); //the one and only instantiation of the database.

        //code for the round borders, no borders and form drag.
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
        //end code.


        public frmLoginScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            //generates a random image for the background to show different slides. centres the image to the centre of the screen. 

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
            LoginResult = Backend.login(enteredUsername,enteredPassword);

            if (LoginResult)
            {
                int enteredUserID=Backend.getUserIDWithUsername(enteredUsername);
                string enteredInstitutionCode="";
                bool success=false;
                
                if (Backend.checkUserType(enteredUserID)=="Student" || Backend.checkUserType(enteredUserID)=="Teacher")
                {
                    //for every single school, for every single class, for every single teacher or student in that class, + unassigned members, if enteredUserID == that user.UserID then school.institutioncode=enteredInstitutionCode.
                    for (int i = Schools.Count - 1; i >= 0; i--)
                    {
                        for (int j = Schools[i].classesInSchool.Count - 1; j >= 0; j--)
                        {
                            for (int l = Schools[i].classesInSchool[j].Students.Count - 1; l >= 0; l--)
                            {
                                if (Schools[i].classesInSchool[j].Students[l].userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }

                            if (Schools[i].classesInSchool[j].mainTeacher != null)
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

                        if (Backend.checkUserType(enteredUserID) == "Student")
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
                            for (int k = Schools[i].unassignedTeachers.Count - 1; k >= 0; k--)
                            {
                                if (Schools[i].unassignedTeachers[k].userID == enteredUserID)
                                {
                                    enteredInstitutionCode = Schools[i].InstitutionCode;
                                    success = true;
                                }
                            }
                        }

                    }

                    if (success)
                    {
                        Backend.setCurrentUserWithSchool(enteredUserID, enteredInstitutionCode); //find the entered user's school.
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
    } 
}
