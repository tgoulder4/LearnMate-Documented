using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace LearnMate
{
    public partial class frmManageClasses : Form
    {
        public backend backendREF;
        public int selectedClassID;
        public int selectedUserID;
        public List<Button>ClassButtonlist=new List<Button>();
        public List<Button> StudentButtonlist = new List<Button>();
        public Point newLocation = new Point(0, 0);

        public frmManageClasses(backend backend)
        {
            InitializeComponent();
            backendREF = backend;
            pnlClass.AutoScroll = true;
        }

        public void fillClassButtons()
        {
            pnlClass.Controls.Clear();
            newLocation = new Point(0, 0);
            if (backend.currentSchoolID != -1)
            {
                for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool.Count - 1; i >= 0; i--)
                {
                    addClassButton(backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].className, backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].classID);
                }
            }
        }

        public void fillStudentButtons()
        {
            pnlClass.Controls.Clear();
            newLocation = new Point(0, 0);
            for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassID - 1].Students.Count - 1; i >= 0; i--)
            {
                addStudentButton(backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassID - 1].Students[i].Name, backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassID - 1].Students[i].Username); //resize according to amount.
            }
        }
        private void addClassButton(string ClassName, int classID) //add list of classes as buttons
        {

            Button btnClass = new Button();
            btnClass.BackColor = Color.White;
            btnClass.Height = 50;
            btnClass.Width = pnlClass.Width;
            btnClass.Location = newLocation;
            newLocation.Offset(0, 5+btnClass.Height);
            btnClass.MouseClick += BtnClass_MouseClick;
            btnClass.ForeColor = Color.SteelBlue;
            btnClass.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnClass.Text = ClassName;
            btnClass.Name = Convert.ToString(classID);

            pnlClass.Controls.Add(btnClass);
            ClassButtonlist.Add(btnClass);
            //find the corresponding index to each i value
        }

        private void addStudentButton(string FirstName,string username) //add list of classes as buttons
        {
            //int i is the number of classes the teacher is responsible for. example, 4

            Button btnStudent = new Button();
            btnStudent.BackColor = Color.White;
            btnStudent.Height = 125;
            btnStudent.Width = 100;

            if (newLocation.X > pnlClass.Width-100)
            {
                newLocation.Offset(-newLocation.X, 125 + 10);
            }

            btnStudent.Location = newLocation;
            newLocation.Offset(100+10, 0);
            btnStudent.MouseClick += BtnStudent_MouseClick;
            btnStudent.ForeColor = Color.SteelBlue;
            btnStudent.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnStudent.Text = FirstName;
            btnStudent.Name = username;
            PictureBox pic = new PictureBox();
            pic.Location = new Point(10, 10);
            pic.Width = 100-20;
            pic.Height = 100-20; //height must be greater than or equal to the width of the button.
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.BackgroundImage = Image.FromFile("student.png");
            //pic.MouseEnter
            btnStudent.Controls.Add(pic);
            btnStudent.TextAlign = ContentAlignment.BottomCenter;
                
            pnlClass.Controls.Add(btnStudent);
            StudentButtonlist.Add(btnStudent);

        }

        private void BtnStudent_MouseClick(object sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            selectedUserID = backendREF.getUserIDWithUsername(test.Name);
            enableStudentActions();
            lblClassName.Text = test.Text;
        }

        private void BtnClass_MouseClick(object sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            selectedClassID = Convert.ToInt32(test.Name); //find class ID by username
                                                          //backendREF.get


            enableClassActionButtons();
            lblClassName.Text = test.Text;
        }

        private void disableClassActionButtons()
        {
            btnRemoveClass.Enabled = false;
            btnEditStudents.Enabled = false;
        }

        private void enableStudentActions()
        {
            btnEditStudents.Enabled = true;
            btnMoveStudent.Enabled = true;
            btnRemoveStudent.Enabled = true;
            btnBan.Visible = true;
            btnKick.Visible = true;
        }
        private void disableStudentActions()
        {
            btnEditStudents.Enabled = false;
            btnMoveStudent.Enabled = false;
            btnRemoveStudent.Enabled = false;
            btnBan.Visible = false;
            btnKick.Visible = false;
        }

        private void enableClassActionButtons()
        {
            btnRemoveClass.Enabled = true;
            btnEditStudents.Enabled = true;
        }

        private void disableAllActions()
        {
            disableClassActionButtons();
            disableStudentActions();
        }

        private void showStudentActionButtons()
        {
            btnAddStudent.Visible = true;
            btnRemoveStudent.Visible = true;
            btnMoveStudent.Visible = true;
            btnBan.Visible = true;
        }
        private void hideStudentActionButtons()
        {
            btnAddStudent.Visible = false;
            btnRemoveStudent.Visible = false;
            btnMoveStudent.Visible = false;
            btnBan.Visible = false;
        }

        private void hideClassActionButtons()
        {
            btnEditStudents.Visible = false;
            btnRemoveClass.Visible = false;
            btnAddClass.Visible = false;
        }

        private void showClassActionButtons()
        {
            btnEditStudents.Visible = true;
            btnRemoveClass.Visible = true;
            btnAddClass.Visible = true;
        }

        private void frmManageClasses_Shown(object sender, EventArgs e)
        {
            fillClassButtons();
            disableAllActions();
            btnBack.Visible = false;
        }

        private void btnEditStudents_Click(object sender, EventArgs e)
        {
            lblCurrentView.Text = "students in "+lblClassName.Text;
            pnlClass.Controls.Clear();

            showStudentActionButtons();
            hideClassActionButtons();
            disableStudentActions();

            ClassButtonlist.Clear();

            lblClassName.Text = "Select a student";
            fillStudentButtons();

            

            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            lblCurrentView.Text = "classes in your school";
            pnlClass.Controls.Clear();
            StudentButtonlist.Clear();
            fillClassButtons();

            hideStudentActionButtons();
            showClassActionButtons();
            disableClassActionButtons();



            lblClassName.Text = "Select a class";

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            subFrmAddStudentToClass addStudent = new subFrmAddStudentToClass(backendREF,selectedClassID,this);
            addStudent.Location = this.Location;
            addStudent.Show();
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            backend.User user = backend.Users[selectedUserID - 1];
            backend.Student student = (backend.Student)user; //cast the user as a teacher

            //if confirmed,
            backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassID - 1].Students.Remove(student);
            backend.Schools[backend.currentSchoolID - 1].addUnassignedStudentByUserID(selectedUserID);
            backend.Schools[backend.currentSchoolID - 1].replaceInSchoolsList();

            fillStudentButtons();
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            //cast as student to remove them from their school
            backend.Student student = (backend.Student)backend.Users[selectedUserID - 1];
            for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool.Count - 1; i >= 0; i--)
            {
                if (backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Contains(student))
                {
                    backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Remove(student);
                }
            }
            backend.Schools[backend.currentSchoolID - 1].replaceInSchoolsList();

            fillStudentButtons();
        }

        private void btnBan_Click(object sender,EventArgs e)
        {
            backend.Users[selectedUserID - 1].banned = true;

            //cast as student to remove them from their school
            backend.Student student = (backend.Student)backend.Users[selectedUserID - 1];
            for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool.Count - 1; i >= 0; i--)
            {
                if (backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Contains(student))
                {
                    backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Remove(student);
                }
            }
            backend.Schools[backend.currentSchoolID - 1].replaceInSchoolsList();
            fillStudentButtons();
        }
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            subFrmCreateClass createClass = new subFrmCreateClass(backendREF, this);
            createClass.Location = this.Location;
            createClass.Show();
        }

        private void btnMoveStudent_Click(object sender, EventArgs e)
        {
            frmMoveStudentClass addStudent = new frmMoveStudentClass(this,backendREF, selectedUserID,selectedClassID) ;
            addStudent.Location = this.Location;
            addStudent.Show();
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            //backend.Schools[backend.currentSchoolID - 1].removeClass(selectedClassID);
            //backend.Schools[backend.currentSchoolID - 1].replaceInSchoolsList();

            //fillClassButtons();
        }
    }


}
