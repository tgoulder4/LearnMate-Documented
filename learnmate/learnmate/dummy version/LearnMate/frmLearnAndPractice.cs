using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace LearnMate
{
    public partial class frmLearnAndPractice : Form
    {

        frmContainer containerREF;
        public Point point = new Point(0, 0);
        List<PictureBox> topicList = new List<PictureBox>();
        public List<Button> subjectBoxButtons = new List<Button>();
        public string selectedSubject;
        public int selectedSubjectID;
        public string selectedTopic;
        public int selectedTopicID;
        public string selectedSubTopic;
        public int selectedSubTopicID;
        public Point subjectBoxLocation = new Point(10, 10);
        public List<int> chosenSubTopicIDs = new List<int>();
        backend backendREF;


        public frmLearnAndPractice(frmContainer container, backend backend)
        {
            InitializeComponent();
            containerREF = container;
            backendREF = backend;
            fillSubjects();
        }

        private void fillSubjects()
        {
            pnlSubjects.Controls.Clear();
            point = new Point(0, 0);
            //for every subject taken, 
            for (int i = backend.Users[backend.currentUserID-1].SubjectsEnrolledTo.Count - 1; i >= 0; i--) //for every subject,
            {
                string subject = backend.Users[backend.currentUserID - 1].SubjectsEnrolledTo[i];  //"subject" (with spaces) = that subject
                addSubjectButton(subject); //e.g. addSubject(Mathematics, Mathematics.png), addSubject(ComputerScience,ComputerScience.png)
            }
        }

        private void fillTopics()
        {
            point = new Point(0, 0);
            pnlSubjects.Controls.Clear();
            //get ID of selected Subject
            for (int i = backend.Subjects[selectedSubjectID - 1].SubjectTopics.Count - 1; i >= 0; i--)
            {
                string topic = backend.Subjects[selectedSubjectID - 1].SubjectTopics[i].TopicName;  //"subject" (with spaces) = that subject
                addTopicButon(topic); //e.g. addSubject(Mathematics, Mathematics.png), addSubject(ComputerScience,ComputerScience.png)
            }
        }

        private void fillSubTopics()
        {
            point = new Point(0, 0);
            pnlSubjects.Controls.Clear();
            //get ID of selected Subject
            for (int i = backend.Subjects[selectedSubjectID - 1].SubjectTopics[selectedTopicID-1].subTopics.Count - 1; i >= 0; i--)
            {
                string subTopic = backend.Subjects[selectedSubjectID - 1].SubjectTopics[selectedTopicID - 1].subTopics[i].SubTopicName;  //"subject" (with spaces) = that subject
                addSubTopicButton(subTopic); //e.g. addSubject(Mathematics, Mathematics.png), addSubject(ComputerScience,ComputerScience.png)
            }
        }

        private void addSubTopicButton(string subtopicName)
        {
            Button btn = new Button();
            btn.Location = point;
            btn.Width = pnlSubjects.Width-10;
            btn.Height = 50;
            btn.MouseClick += SubTopic_MouseClick;
            btn.Text = subtopicName;
            if (subtopicName.Contains(" "))
            {
                btn.Name = subtopicName.Replace(" ", "_");
            }
            else
            {
                btn.Name = subtopicName;
            }
            pnlSubjects.Controls.Add(btn);
            point.Offset(0, 60);
            //replace _ with " "
        }

        private void SubTopic_MouseClick(object? sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btnBegin.Enabled = true;
            selectedSubTopic = btn.Text;
            if (selectedSubTopic.Contains("_"))
            {
                selectedSubTopic = selectedSubject.Replace("_", " ");
            }
            PictureBox pic = new PictureBox();
            selectedSubTopicID = backend.Subjects[selectedSubjectID - 1].getSubTopicIDByName(selectedSubTopic,selectedTopicID);
            if (!chosenSubTopicIDs.Contains(selectedSubTopicID))
            {
                chosenSubTopicIDs.Add(selectedSubTopicID);
                pic.Width = 30;
                pic.Height = 30;
                pic.Location = new Point(450, 10);
                pic.BackgroundImage = Image.FromFile("StudentChecked.png");
                pic.BackgroundImageLayout = ImageLayout.Zoom;
                pic.BackColor = Color.Transparent;


                btn.Controls.Add(pic);
            }
            else
            {
                chosenSubTopicIDs.Remove(selectedSubTopicID);
                btn.Controls.Clear();
            }
            //add to list of selectedSubTopicIDs
        }

        private void addTopicButon(string topicName)
        {
            PictureBox ptc = new PictureBox();
            ptc.Location = point;
            ptc.Width = 230;
            ptc.Height = ptc.Width;
            ptc.MouseClick += Topic_MouseClick;
            ptc.BackColor = Color.Transparent;
            ptc.BackgroundImageLayout = ImageLayout.Zoom;
            
            if (topicName.Contains(" "))
            {
                ptc.Name = topicName.Replace(" ", "_"); //controls can't have a name with spaces.
            }
            else
            {
                ptc.Name = topicName;
            }

            //IF IT LOOKS LIKE THERE ARE NO BUTTONS, THE BUTTONS ARE THERE BUT THEY DON#T HAVE A PICTURE.
            if (topicName == "Pure")
            {
                ptc.BackgroundImage = Image.FromFile("btnMathsPure.png"); //icon pure
            }
            else if (topicName == "Mechanics")
            {
                if (selectedSubject == "Physics")
                {
                    ptc.BackgroundImage = Image.FromFile("btnPhysicsMechanics.png"); //icon physics mechanics
                }
                else
                {
                    ptc.BackgroundImage = Image.FromFile("btnMathsMechanics.png"); //icon maths mechanics
                }
            }
            else if (topicName == "Statistics")
            {
                ptc.BackgroundImage = Image.FromFile("btnMathsStatistics.png");
            }
            else if (topicName == "Dynamics")
            {
                ptc.BackgroundImage = Image.FromFile("btnDynamics.png");
            }
            else if (topicName == "Further Mechanics")
            {
                ptc.BackgroundImage = Image.FromFile("btnFurtherMechanics.png");
            }
            else if (topicName == "Thermal Physics")
            {
                ptc.BackgroundImage = Image.FromFile("btnThermalPhysics.png");
            }
            else
            {
                ptc.BackgroundImage = Image.FromFile("btnNoPicture.png");
            }

            Label topicTitle = new Label();
            topicTitle.Text = topicName;
            topicTitle.Font = new Font("Century Gothic", 15, FontStyle.Regular);
            topicTitle.ForeColor = Color.Gray;
            topicTitle.BackColor = Color.FromArgb(232, 232, 232);
            topicTitle.Size = new Size(400, 50);
            topicTitle.Location = new Point(subjectBoxLocation.X + 120, subjectBoxLocation.Y + 38);


            point.Offset(235, 0);

            pnlSubjects.Controls.Add(ptc);
            topicList.Add(ptc);
        }

        private void Topic_MouseClick(object? sender, MouseEventArgs e)
        {
            PictureBox test = (PictureBox)sender;
            selectedTopic = test.Name; //e.g. Computer Science, Mathematics
            if (selectedTopic.Contains("_"))
            {
                selectedTopic = selectedTopic.Replace("_", " ");
            }
            selectedTopicID = backend.Subjects[selectedSubjectID - 1].getTopicIDByName(selectedTopic);
            this.BackgroundImage = Image.FromFile("learnstage2.jpg"); //the choose topics and go background image
            pnlSubjects.Size = new Size(535, 248);

            pnlNotification.Location = new Point(721, 226);
            pnlNotification.Visible = true;
            
            btnBegin.Enabled = false;

            lblSaysMySubjects.Text = selectedSubject+" - "+selectedTopic;
            fillSubTopics();
            //move to learn session
        }


        public void addSubjectButton(string subjectName)
        {
            PictureBox pctSubject = new PictureBox();
            pctSubject.Height = 100;
            pctSubject.Width = 792;
            pctSubject.BackgroundImage = Image.FromFile("pctSubjectBackground.png");
            pctSubject.Location = subjectBoxLocation;
            pctSubject.BackColor = Color.Transparent;


            Button btnSelect = new Button();
            btnSelect.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnSelect.Text = "Select";
            btnSelect.Location = new Point(subjectBoxLocation.X + 600, subjectBoxLocation.Y + 35);
            btnSelect.Width = 100;
            btnSelect.Height = 30;
            btnSelect.BackColor = Color.FromArgb(112, 155, 230);
            btnSelect.MouseClick += Subject_MouseClick;

            if (subjectName.Contains(" "))
            {
                btnSelect.Name = subjectName.Replace(" ", "_"); //controls can't have a name with spaces.
            }
            else
            {
                btnSelect.Name = subjectName;
            }

            btnSelect.Name = subjectName; //put the name as the subject BUT it gets changed later if the subject contains a space
            Label lblSubjectTitle = new Label();
            lblSubjectTitle.Text = subjectName;
            lblSubjectTitle.Font = new Font("Century Gothic", 15, FontStyle.Regular);
            lblSubjectTitle.ForeColor = Color.Gray;
            lblSubjectTitle.BackColor = Color.FromArgb(232, 232, 232);
            lblSubjectTitle.Size = new Size(400, 50);
            lblSubjectTitle.Location = new Point(subjectBoxLocation.X + 120, subjectBoxLocation.Y + 38);


            PictureBox subjectPicture = new PictureBox();
            subjectPicture.Location = new Point(subjectBoxLocation.X + 13, subjectBoxLocation.Y + 12);
            subjectPicture.Width = 75;
            subjectPicture.Height = subjectPicture.Width; //height must be greater than or equal to the width of the button.
            subjectPicture.BackgroundImageLayout = ImageLayout.Zoom;
            subjectPicture.BackColor = Color.FromArgb(232, 232, 232);

            if (subjectName == "Mathematics")
            {
                subjectPicture.BackgroundImage = Image.FromFile("iconMaths.png");
            }
            else if (subjectName == "Physics")
            {
                subjectPicture.BackgroundImage = Image.FromFile("iconPhysics.png");
            }
            else if (subjectName == "Computer Science")
            {
                subjectPicture.BackgroundImage = Image.FromFile("iconCompSci.png");
                btnSelect.Name = "Computer_Science"; //spaces aren't valid for control names.
            }


            subjectBoxLocation.Offset(0, pctSubject.Height + 10);


            pnlSubjects.Controls.Add(lblSubjectTitle);
            pnlSubjects.Controls.Add(btnSelect);
            pnlSubjects.Controls.Add(subjectPicture);
            pnlSubjects.Controls.Add(pctSubject);

            subjectBoxButtons.Add(btnSelect);
        }

        private void Subject_MouseClick(object? sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            selectedSubject = test.Name;
            if (selectedSubject.Contains("_"))
            {
                selectedSubject = selectedSubject.Replace("_", " ");
            }
            selectedSubjectID = backendREF.getSubjectIDByName(selectedSubject);
            lblSaysMySubjects.Text = selectedSubject;
            fillTopics();
            //create new subject with selectedSubjectID
            //move to next screen
        }

        private void btnBegin_Click(object sender, EventArgs e)
        { 
            containerREF.loadSession(selectedSubject,selectedTopic,selectedSubTopic, chosenSubTopicIDs); //selectedSubTopic supposed to be selectedtopicID?
        }
    }
}
