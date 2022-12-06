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

        private void addbtn(string imageName)
        {
            //100 by 100 from point (0,0), skip new line: adjust point.Y by 110 and X by -widthitisnow. 

            if (point.X > pnlForms.Width - 100)
            {
                point.Offset(-point.X, 110);
            }
            
            PictureBox ptcbackground = new PictureBox();
            ptcbackground.Width = 100;
            ptcbackground.Height = 100;
            ptcbackground.Location = point;
            ptcbackground.BackgroundImage = Image.FromFile("frmBackground.png");
            ptcbackground.BackgroundImageLayout = ImageLayout.Zoom;
            ptcbackground.Name = imageName;

            PictureBox ptcFormImage = new PictureBox();
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

            ptcbackground.Controls.Add(ptcFormImage);

            pnlForms.Controls.Add(ptcbackground);

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
            lblName.Text = backendREF.getFirstName();
            lblUserType.Text = backendREF.getUserType();
            pnlForms.Controls.Clear();
            point = new Point(0, 0);
            
            
            addbtn("HomePage.png");
            addbtn("TimeOrganiser.png");
            
            if (backendREF.getUserType() == "Teacher")
            {
                addbtn("ManageClasses.png");
                //addbtn("Manage Assignments");
                lblLinked.Visible = true;
                lblLinked.Text = "LINKED TO " + backendREF.getCurrentUserSchool();
            }
            else if (backendREF.getUserType() == "Student")
            {
                addbtn("LearnPractice.png");
                addbtn("Performance.png");
                //addbtn("Complete Assignments");
                lblLinked.Visible = true;
                lblLinked.Text = "LINKED TO " + backendREF.getCurrentUserSchool();
                enableMenu();
                if (backendREF.getCurrentUserSchool() == "NO SCHOOL")
                {

                    disableMenu();
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
            {
                addbtn("LearnPractice.png");
                addbtn("Performance.png");
            }
            Console.WriteLine("Refresh all elements was called in frontend, duplicating backend...");

        } //refresh controls
        private void Btn_MouseClick(object sender, MouseEventArgs e)
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
        public void loadLearnAndPractice()
        {
            enableMenu();
            clearCurrentSubform();
            homepageActive = false;
            frmLearnAndPractice LearnPage = new frmLearnAndPractice(this,backendREF);
            LearnPage.TopLevel = false;
            mainPanel2.Controls.Add(LearnPage);
            lblTitle.Text = "Advance your knowledge";

            LearnPage.Show();
        }
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
            enableMenu();
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
            disableMenu();
            homepageActive = true;
            clearCurrentSubform();
            frmHomepage homepage = new frmHomepage(this, backendREF);
            titlePanel.BackColor = Color.FromArgb(255, 255, 255);
            homepage.TopLevel = false;
            mainPanel2.Controls.Add(homepage);
            lblTitle.Text = "Home";
            lblDivider.Visible = true;
            homepage.Show();
            //based on the JSON parse, get the type of the user that has logged in.
            //if the type of the user is a student,
        }

        public void loadTimeOrganiser()
        {
            enableMenu();
            clearCurrentSubform();
            homepageActive = false;
            frmTimeOrganiser TimePage = new frmTimeOrganiser(backendREF);
            TimePage.TopLevel = false;
            mainPanel2.Controls.Add(TimePage);
            lblTitle.Text = "Time Organiser";

            TimePage.Show();
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
