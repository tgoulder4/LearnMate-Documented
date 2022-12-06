using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnMate
{
    public partial class subFrmAddStudentToClass : Form
    {
        public Point newLocation = new Point(0, 0);
        backend backendREF;
        frmManageClasses manageREF;
        public List<Button> StudentButtonlist = new List<Button>();
        public List<int> selectedUserIDs = new List<int>();
        public int selectedClassIDREF;
        public string searchingName;

        public subFrmAddStudentToClass(backend backend, int selectedClassID, frmManageClasses manage)
        {
            InitializeComponent();
            backendREF = backend;
            selectedClassIDREF = selectedClassID;
            lblDirectory.Text="Directory "+backendREF.getCurrentUserSchool();//should maybe be get current class' school? shouldn't matter unless admins are created
            loadStudentButtons();
            pnlStudents.AutoScroll = true;
            manageREF = manage;
            btnMoveToThisClass.Enabled = false ;
        }


        public void loadStudentButtons()
        {
            pnlStudents.Controls.Clear();
            //for every class, for every student and for every unassigned member with usertype student, add student button of that name.
            newLocation = new Point(0, 0);
            for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool.Count - 1; i >= 0; i--) //for every class,
            {
                if (i != selectedClassIDREF-1)
                {
                    for (int j = backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Count - 1; j >= 0; j--) //for every student in that class,
                    {
                        addStudentButton(backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students[j].Name, backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students[j].Username); //output their name
                    }
                }

            }
            for (int k = backend.Schools[backend.currentSchoolID - 1].unassignedStudents.Count - 1; k >= 0; k--) //for every unassigned member in that school,
            {
                    addStudentButton(backend.Schools[backend.currentSchoolID - 1].unassignedStudents[k].Name, backend.Schools[backend.currentSchoolID - 1].unassignedStudents[k].Username); //add a button if they're a student.
            }

        }


        private void addStudentButton(string FirstName, string username) //add list of classes as buttons
        {
            //int i is the number of classes the teacher is responsible for. example, 4

            Button btnStudent = new Button();
            btnStudent.BackColor = Color.White;
            btnStudent.Height = 125;
            btnStudent.Width = 100;

            if (newLocation.X > pnlStudents.Width - 100)
            {
                newLocation.Offset(-newLocation.X, 125 + 10);
            }

            btnStudent.Location = newLocation;
            newLocation.Offset(100 + 10, 0);
            btnStudent.MouseClick += BtnStudent_MouseClick;
            btnStudent.ForeColor = Color.SteelBlue;
            btnStudent.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnStudent.Text = FirstName;
            btnStudent.Name = username;
            
            
            PictureBox pic = new PictureBox();
            pic.Location = new Point(30, 30);
            pic.Width = 60 - 20;
            pic.Height = 60 - 20; //height must be greater than or equal to the width of the button.
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.BackgroundImage = Image.FromFile("student.png");
            //pic.MouseEnter
            btnStudent.Controls.Add(pic);
            btnStudent.TextAlign = ContentAlignment.BottomCenter;
            pnlStudents.Controls.Add(btnStudent);
            if (!StudentButtonlist.Contains(btnStudent))
            {
                StudentButtonlist.Add(btnStudent);
            }

        }

        private void BtnStudent_MouseClick(object sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            selectedUserIDs.Add(backendREF.getUserIDWithUsername(test.Name));
            PictureBox pic = new PictureBox();
            pic.Width = 20;
            pic.Height = 20;
            pic.Location = new Point(75, 5);
            pic.BackgroundImage = Image.FromFile("StudentChecked.png");
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.BackColor = Color.White;
            
            test.Controls.Add(pic);
            btnMoveToThisClass.Text = "Move student(s)";
            btnMoveToThisClass.Enabled = true;
        }

        private void btnMoveToThisClass_Click(object sender, EventArgs e)
        {
            int oldClassID=0;
            int oldStudentPlace = 0;
            backend.School currentSchool = backend.Schools[backend.currentSchoolID - 1];
            //for every class, if username is present among students, oldClassID=that class ID.

            //put a for loop in the list of each selected user ID
            for (int i = selectedUserIDs.Count - 1; i >= 0; i--)
            {
                for (int l = currentSchool.classesInSchool.Count - 1; l >= 0; l--) //for every class,
                {
                    if (l != selectedClassIDREF - 1)
                    {
                        for (int j = currentSchool.classesInSchool[l].Students.Count - 1; j >= 0; j--) //for every student in that class,
                        {
                            if (currentSchool.classesInSchool[l].Students[j].userID == selectedUserIDs[i]) //if the userID of the student matches that of selected student id
                            {
                                oldClassID = l + 1; //save old class ID and...
                                oldStudentPlace = j + 1; //...old place of object for later removal
                            }
                        }
                    }
                }

                if (oldClassID == 0) // they're an unassigned member their classID will return 0. repeat above but for an unassigned member.
                {
                    for (int j = currentSchool.unassignedStudents.Count - 1; j >= 0; j--) //for every unassigned student,
                    {
                        if (currentSchool.unassignedStudents[j].userID == selectedUserIDs[i])
                        {
                            oldStudentPlace = j + 1; //get the place of their object for later removal.
                        }
                    }

                    backend.Student student = backend.Schools[backend.currentSchoolID - 1].unassignedStudents[oldStudentPlace - 1];

                        currentSchool.removeUnassignedStudentByObject(student);
                        currentSchool.classesInSchool[selectedClassIDREF - 1].Students.Add(student); //and add this object to the unassignedStudents of the selected class in the currently selected school
                        Console.WriteLine("User " + backend.Users[selectedUserIDs[i] - 1].Name + " moved from being an unassigned user to " + backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassIDREF - 1].className);
                        manageREF.fillStudentButtons();
                }
                else
                {
                    backend.Student tempStudent = currentSchool.classesInSchool[oldClassID - 1].Students[oldStudentPlace - 1];

                    currentSchool.classesInSchool[oldClassID - 1].Students.RemoveAt(oldStudentPlace - 1);
                    currentSchool.classesInSchool[selectedClassIDREF - 1].Students.Add(tempStudent);
                    Console.WriteLine("User " + backend.Users[selectedUserIDs[i] - 1].Name + " moved from " + backend.Schools[backend.currentSchoolID - 1].classesInSchool[oldClassID - 1].className + " to " + backend.Schools[backend.currentSchoolID - 1].classesInSchool[selectedClassIDREF - 1].className);
                    //then add to this class
                    manageREF.fillStudentButtons();
                }
                //loadStudentButtons(); was here
            }
            StudentButtonlist.Clear();
            loadStudentButtons();
            if (StudentButtonlist.Count == 0)
            {
                this.Hide();
            }
            MessageBox.Show("Finished moving "+selectedUserIDs.Count+" student(s).");
            selectedUserIDs.Clear();
            btnMoveToThisClass.Enabled = false;
            backend.Schools[backend.currentSchoolID - 1] = currentSchool;
            //find old class, remove
        }
    }
}
