using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnMate
{
    public partial class frmHomepage : Form
    {
        public Point point = new Point(0, 0);
        List<PictureBox> buttonList = new List<PictureBox>();

        public frmContainer containerREF;
        public backend backendREF;
        public frmHomepage(frmContainer container, backend backend)
        {
            InitializeComponent();
            lblCurrentView.ForeColor = Color.FromArgb(48, 156, 77);
            pnlActions.AutoScroll = true;
            pnlActions.AutoScrollPosition = new Point(0, pnlActions.Height+100);
            containerREF = container;
            backendREF = backend;
            refreshButtons();
        }

        //TO ADD A BUTTON TO PNLACTIONS, USE addButton(Colour, Text).
        private void addbtn(string imageName) //takes in an imageName
        {
            PictureBox ptc = new PictureBox(); //create a new pictureBox for each form button
            ptc.Location = point; //set the attributes of a form button
            ptc.Width = 284;
            ptc.Height = ptc.Width;
            ptc.BackgroundImage = Image.FromFile(imageName);
            ptc.MouseClick += Ptc_MouseClick; //create event handler
            ptc.BackColor = Color.White;
            ptc.BackgroundImageLayout = ImageLayout.Zoom;
            ptc.Name = imageName;
            point.Offset(294, 0); //offset so the buttons don't appear on top of each other.

            pnlActions.Controls.Add(ptc);
            buttonList.Add(ptc); //add the button to the panel.
        }

        private void Ptc_MouseClick(object? sender, MouseEventArgs e)
        {
            PictureBox test = (PictureBox)sender;
            if (test.Name=="btnOrganiseTime.png")
            {
                containerREF.loadTimeOrganiser();
            }
            else if (test.Name=="btnManageClasses.png")
            {
                containerREF.loadManageClasses();
            }
            else if (test.Name == "btnLearnAndPractice.png")
            {
                containerREF.loadLearnAndPractice();
            }
            else if (test.Text == "Manage Assignments")
            {
                //loadmanageassignments
            }
            else if (test.Text == "Assignments")
            {
                //loadassignments
            }
            else if (test.Text == "btnPerformance.png")
            {

            }
        }

        public void refreshButtons()
        {
            addbtn("btnOrganiseTime.png"); //all users have a time organiser.
            if (backendREF.getUserType() == "Teacher")
            {
                addbtn("btnManageClasses.png"); //if they're a teacher, they can manage their classes

            }
            else if (backendREF.getUserType() == "Student") //if they're a student, they can do the followigna ctions
            {
                addbtn("btnLearnAndPractice.png");
                addbtn("btnCompleteAssignments.png");
                addbtn("btnPerformance.png");
                //addbtn("Assignments");

            }
            else if (backendREF.getUserType() == "Home Learner")
            {
                addbtn("btnLearnAndPractice.png");
            }

        } //refresh controls

        //find out how to run functions in container based on the action buttons clicked in the homepage form


    }
}
