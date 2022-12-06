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

namespace LearnMate
{
    public partial class frmContainer : Form
    {
        //code for the round borders, no borders and form drag.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

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
        private bool mouseDown;
        private Point lastLocation;
        private bool isCollapsed;
        public static event EventHandler Idle;
        public int Multiplier;
        private backend backendREF;
        private frmLoginScreen loginREF;
        public static Point point = new Point(0, 0);
        public static Point linkPoint = new Point(375, 440);
        public static bool homepageActive;

        public List<Button> ButtonList = new List<Button>();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        } //speeds up prgorma

        //private const int CS_DROPSHADOW = 0x00020000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        // add the drop shadow flag for automatically drawing
        //        // a drop shadow around the form
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        //end of code for the round borders, no borders and form drag.

        public frmContainer(frmLoginScreen login, backend backend)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));

            //show a loading screen until the elements have finished loading
            //while (!Application.Idle)
            //{
            //    showLoadingScreen();
            //}
            backendREF = backend;
            loginREF = login;
            pnlMenu.Width = 0;
            btnLink.Visible = false;

        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            
        }

        private void addbtn(string imageName) //adds a form button for navigation. called depending on user actions
        {
            if (point.X > pnlForms.Width - 100) //if the next button to be added overflows, start a new line.
            {
                point.Offset(-point.X, 110);
            }
            
            PictureBox ptcbackground = new PictureBox(); //create a background w/attributes
            ptcbackground.Width = 100;
            ptcbackground.Height = 100;
            ptcbackground.Location = point;
            ptcbackground.BackgroundImage = Image.FromFile("frmBackground.png");
            ptcbackground.BackgroundImageLayout = ImageLayout.Zoom;
            ptcbackground.Name = imageName;

            PictureBox ptcFormImage = new PictureBox(); //create an image w/attributes
            ptcFormImage.Width = 75;
            ptcFormImage.Height = 75;
            ptcFormImage.Location = new Point(13, 13);
            ptcFormImage.BackgroundImage = Image.FromFile(imageName);
            ptcFormImage.Name = imageName;
            ptcFormImage.BackgroundImageLayout = ImageLayout.Zoom;
            ptcFormImage.BackColor = Color.FromArgb(220, 220, 220);

            ptcbackground.MouseClick += Btn_MouseClick;
            ptcFormImage.MouseClick+=Btn_MouseClick;
            point.Offset(110,0);

            ptcbackground.Controls.Add(ptcFormImage); //add the form image to the button backgorund

            pnlForms.Controls.Add(ptcbackground); //add the button background (and the form image) to the panel of forms.

        }

        public void disableMenu()
        {
            btnMenu.Visible = false;
        }

        public void enableMenu()
        {
            btnMenu.Visible = true;
        }
        public void refreshAllElements()
        {
            btnLink.Visible = false;
            btnReturn.Visible = false;
            lblName.Text = backendREF.getFirstName(); //getFirstName returns the name of the current user
            lblUserType.Text = backendREF.getUserType(); //same idea as above
            pnlForms.Controls.Clear(); //clear the current subform
            point = new Point(0, 0); //the point for adding navigation form buttons resets to zero to add in the buttons
            
            
            addbtn("HomePage.png"); //these two buttons are common among all users
            addbtn("TimeOrganiser.png");
            
            if (backendREF.getUserType() == "Teacher") //depending on the type of user, they have additional forms avialbale to them.
            {
                addbtn("ManageClasses.png");
                //addbtn("Manage Assignments");
                lblLinked.Visible = true; //if they're a student or a teacher, they will see the "linked to school..." label
                lblLinked.Text = "LINKED TO " + backendREF.getCurrentUserSchool();
            }
            else if (backendREF.getUserType() == "Student")
            {//same idea applies as above
                addbtn("LearnPractice.png");
                addbtn("Performance.png");
                lblLinked.Visible = true;
                lblLinked.Text = "LINKED TO " + backendREF.getCurrentUserSchool();
                enableMenu();
                if (backendREF.getCurrentUserSchool() == "NO SCHOOL") //if they don't belong to a school, they are required to sign into a school.
                                                                      //A form will be displayed informing them of this, they won't be able to get out of the form unless they affiliate with a school.
                {

                    disableMenu(); //removes the hamburger menu, disallowing navigation
                }
                else
                {
                    btnLink.Visible = false;
                    btnReturn.Visible = false;
                    if (homepageActive)
                    {
                        disableMenu();
                    }
                }
            }
            else if (backendREF.getUserType() == "Home Learner")
            { //home learners have the following abilities
                addbtn("LearnPractice.png");
                addbtn("Performance.png");
            }

        } //refresh controls
        private void Btn_MouseClick(object sender, MouseEventArgs e) //if a form navigation button was clicked, depending on its name perform the corresponding action.
        {
            PictureBox test = (PictureBox)sender;
            if (test.Name=="TimeOrganiser.png")
            {
                loadTimeOrganiser();
            }
            else if (test.Name == "ManageClasses.png")
            {
                if (backend.currentSchoolID != -1)
                {
                    loadManageClasses();
                }
                else
                {
                    MessageBox.Show("You don't belong to a school!");
                }
            }
            else if (test.Name == "LearnPractice.png")
            {
                loadLearnAndPractice();
            }
            else if (test.Name == "Manage Assignments")
            {
                //loadmanageassignments
            }
            else if (test.Name == "Assignments")
            {
                //loadassignments
            }
            else if (test.Name == "HomePage.png")
            {
                loadHomepage();
            }

        }
        public void loadNoSchool()
        {
            disableMenu();
            btnLink.Visible = true;
            btnLink.Location = linkPoint;
            mainPanel2.Controls.Clear();
            titlePanel.BackColor = Color.FromArgb(237, 237, 237);
            lblTitle.Text = "ERR SCHID=-1";
            mainPanel2.BackgroundImage = Image.FromFile("unenrolled.jpg");
            mainPanel2.BackgroundImageLayout = ImageLayout.Zoom;
        }

        public void loadSession(string selectedSubjectName,string selectedTopic,string selectedSubTopic,List<int>chosenSubTopicIDs)
        {
            clearCurrentSubform();
            disableMenu();
            homepageActive = false;
            frmSession session = new frmSession(backendREF,this,selectedSubjectName,selectedTopic,selectedSubTopic,chosenSubTopicIDs);
            session.TopLevel = false;
            mainPanel2.Controls.Add(session);
            lblTitle.Text = "In session";
            session.Show();
        }
        public void loadBanned()
        {
            disableMenu();
            clearCurrentSubform();
            btnReturn.Visible = true;
            btnReturn.Location = linkPoint;
            mainPanel2.BackgroundImage = Image.FromFile("kicked.jpg");
            titlePanel.BackColor = Color.FromArgb(237, 237, 237);
            mainPanel2.BackgroundImageLayout = ImageLayout.Zoom;
            lblTitle.Text = "ERR banned=TRUE";
            lblDivider.Visible = false;
        }
        public void loadLearnAndPractice() //loads the learn and practice form
        {
            enableMenu(); //allows the hamburger form once the user is away from the homepage or locked pages
            clearCurrentSubform(); //clears current subform
            homepageActive = false;
            frmLearnAndPractice LearnPage = new frmLearnAndPractice(this,backendREF); //new instance of subform, puts it into the mainPanel
            LearnPage.TopLevel = false;
            mainPanel2.Controls.Add(LearnPage);
            lblTitle.Text = "Advance your knowledge"; //change the title of the current subform accordingly

            LearnPage.Show();
        }
        //all following load functions act similarly.
        public void loadEnrol()
        {
            clearCurrentSubform();
            homepageActive = false;
            frmEnrol enrol = new frmEnrol(backendREF,this);
            enrol.TopLevel = false;
            mainPanel2.Controls.Add(enrol);
            lblTitle.Text = "";
            lblDivider.Visible = false;

            enrol.Show();
        }
        public void loadManageClasses()
        {
            enableMenu(); //allows the hamburger form once the user is away from the homepage or locked pages
            homepageActive = false;
            clearCurrentSubform();
            frmManageClasses Manage = new frmManageClasses(backendREF);
            Manage.TopLevel = false;
            mainPanel2.Controls.Add(Manage);
            lblTitle.Text = "Manage your classes";

            Manage.Show();
        }

        public void loadHomepage()
        {
            disableMenu(); //disallows the hamburger form once the user is entering the homepage
            clearCurrentSubform(); //clears the currently active subform
            frmHomepage homepage = new frmHomepage(this, backendREF); //new instance of the homepage
            titlePanel.BackColor = Color.FromArgb(255, 255, 255);
            homepage.TopLevel = false; //allows the control to be added
            mainPanel2.Controls.Add(homepage);
            lblTitle.Text = "Home"; //change the title in the titlebar
            lblDivider.Visible = true;
            homepage.Show();
        }

        public void loadTimeOrganiser()
        {
            enableMenu(); //enable the hamburger menu if it was disabled
            clearCurrentSubform(); //remove the current subform
            frmTimeOrganiser TimePage = new frmTimeOrganiser(backendREF); //new instance of the time organiser
            TimePage.TopLevel = false; //allows it to be implemented into the mainPanel
            mainPanel2.Controls.Add(TimePage); //add the control
            lblTitle.Text = "Time Organiser"; //change the title in the titlebar

            TimePage.Show(); //show the control.
        }

        public void clearCurrentSubform()
        {
            mainPanel2.Controls.Clear();
        }

        private void mainPanel2_Paint(object sender, PaintEventArgs e)
        {



        }

        private void menuTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlMenu.Width += 10;
                if (pnlMenu.Width == 360)
                {
                    btnMenu.Image = Image.FromFile("expand.png");
                    isCollapsed = false;
                    menuTimer.Stop();
                }
            }
            else
            {
                pnlMenu.Width -= 50;
                if (pnlMenu.Width == 1)
                {
                    btnMenu.Image = Image.FromFile("collapse.png");
                    isCollapsed = true;
                    menuTimer.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMenu.Width = 301;
            lblLogo.Visible = false;
            lblDivider.Visible = false;
            lblTitle.Location = new Point(26, 27);
            lblDivider.Visible = false;

        }

        private void btnLogOutOfContainer_Click(object sender, EventArgs e)
        {
            point.X = 0;
            point.Y = 0;
            backendREF.logout();
            loginREF.Show();
            this.Hide();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            pnlMenu.Width = 0;
            lblLogo.Visible = true;
            lblDivider.Visible = true;
            lblTitle.Location = new Point(172, 27);
            lblDivider.Visible = true;
        }

        private void frmContainer_Shown(object sender, EventArgs e)
        {
            if (backend.Users[backend.currentUserID - 1].banned == true)
            {
                loadBanned();
                btnMenu.Visible = false;
            }
            else if ((backend.currentSchoolID==-1)&&(backend.currentUserType=="Student"))
            {
                loadNoSchool();
                btnMenu.Visible = false;
            }
            else if (backend.Users[backend.currentUserID - 1].SubjectsEnrolledTo.Count == 0)
            {
                loadEnrol();
                btnMenu.Visible = false;
            }
            else
            {
                loadHomepage();
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            subFrmEnterIntoSchool enter = new subFrmEnterIntoSchool(backendREF, this);
            enter.Location = this.Location;
            enter.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            loginREF.Show();
            this.Hide();
        }
    }
}
