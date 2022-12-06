using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace LearnMate
{
    public partial class frmEnrol : Form
    {
        backend backendREF;
        frmContainer containerREF;
        public Point subjectBoxLocation = new Point(10, 10);
        public Point welcomeEndLocation = new Point(0, 0);
        public List<Button> subjectBoxButtons = new List<Button>();
        public List<string> selectedSubjects = new List<string>();
        string selectedSubjectName;

        public frmEnrol(backend backend, frmContainer container)
        {
            InitializeComponent();

            backendREF = backend;
            containerREF = container;
            pnlSubjects.AutoScroll = true;
            pnlSubjects.HorizontalScroll.Visible = false;
            if (backend.currentUserType == "Teacher")
            {
                lblWelcome.Text = "Welcome, " + backend.currentName + "!";
                welcomeEndLocation = new Point(lblWelcome.Location.X+lblWelcome.Width, lblWelcome.Location.Y+5);
                lblCurrentView.Text="What subjects do you teach?";
                lblCurrentView.Location = new Point(welcomeEndLocation.X, welcomeEndLocation.Y);
            }
            else
            {
                lblWelcome.Text = "Welcome, " + backend.currentName + "!";
                welcomeEndLocation = new Point(lblWelcome.Location.X + lblWelcome.Width, lblWelcome.Location.Y + 5);
                lblCurrentView.Text = "What subjects are you learning?";
                lblCurrentView.Location = new Point(welcomeEndLocation.X, welcomeEndLocation.Y);
            }

            addSubject("Mathematics", "iconMaths.png");
            addSubject("Physics", "iconPhysics.png");
            addSubject("Computer Science", "iconCompSci.png");

        }

        public void addSubject(string subjectName, string imageName)
        {
            PictureBox pctSubject = new PictureBox();
            pctSubject.Height = 100;
            pctSubject.Width = 855;
            pctSubject.BackgroundImage = Image.FromFile("pctSubjectBackground.png");
            pctSubject.Location = subjectBoxLocation;
            pctSubject.BackColor = Color.Transparent;


            Button btnSelect = new Button();
            btnSelect.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnSelect.Text = "Select";
            btnSelect.Location=new Point(subjectBoxLocation.X+700, subjectBoxLocation.Y+35);
            btnSelect.Width = 100;
            btnSelect.Height = 30;
            btnSelect.BackColor = Color.FromArgb(112, 155, 230);
            btnSelect.MouseClick += BtnSelect_MouseClick;
            btnSelect.Name = subjectName;

            Label lblSubjectTitle = new Label();
            lblSubjectTitle.Text = subjectName;
            lblSubjectTitle.Font = new Font("Century Gothic", 15, FontStyle.Regular);
            lblSubjectTitle.ForeColor = Color.Gray;
            lblSubjectTitle.BackColor = Color.FromArgb(232,232,232);
            lblSubjectTitle.Size = new Size(400, 50);
            lblSubjectTitle.Location = new Point(subjectBoxLocation.X + 120, subjectBoxLocation.Y + 38);


            PictureBox subjectPicture = new PictureBox();
            subjectPicture.Location = new Point(subjectBoxLocation.X+13, subjectBoxLocation.Y+12);
            subjectPicture.Width = 75;
            subjectPicture.Height = subjectPicture.Width; //height must be greater than or equal to the width of the button.
            subjectPicture.BackgroundImageLayout = ImageLayout.Zoom;
            subjectPicture.BackColor = Color.FromArgb(232, 232, 232);
            subjectPicture.BackgroundImage = Image.FromFile(imageName);


            subjectBoxLocation.Offset(0, pctSubject.Height + 10);


            pnlSubjects.Controls.Add(lblSubjectTitle);
            pnlSubjects.Controls.Add(btnSelect);
            pnlSubjects.Controls.Add(subjectPicture);
            pnlSubjects.Controls.Add(pctSubject);

            subjectBoxButtons.Add(btnSelect);
        }

        private void BtnSelect_MouseClick(object? sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            selectedSubjectName = test.Name;
            if (selectedSubjects.Contains(selectedSubjectName))
            {
                selectedSubjects.Remove(selectedSubjectName);
                test.Text = "Select";
                test.BackColor = Color.FromArgb(112, 155, 230);
            }
            else
            {
                selectedSubjects.Add(selectedSubjectName);
                test.Text = "Selected";
                test.BackColor = Color.LightGreen;
            }
        }

        private void btnCompleteSetup_Click(object sender, EventArgs e)
        {
            for (int i = selectedSubjects.Count - 1; i >= 0; i--)
            {
                backend.Users[backend.currentUserID - 1].addSelectedSubjectsByName(selectedSubjects[i]);
            }
            
            containerREF.btnMenu.Enabled = true;
            containerREF.loadHomepage();
            containerREF.refreshAllElements();
            
            //if (backend.Users[backend.currentUserID - 1].kicked == true)
            //{
            //    containerREF.loadKickedFromSchool();
            //}

            //if (!(backendREF.getCurrentUserSchool() == "NO SCHOOL"))
            //{
            //    containerREF.loadHomepage();
            //}

            //else
            //{
            //    containerREF.loadNoSchool();
            //}
        }
    }
}
