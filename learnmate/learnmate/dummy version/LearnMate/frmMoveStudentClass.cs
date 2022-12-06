using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LearnMate.backend;

namespace LearnMate
{
    public partial class frmMoveStudentClass : Form
    {

        public int selectedUserIDREF;
        public int currentClassIDREF;
        public Point newLocation = new Point(0, 0);
        public List<Button> ClassButtonlist = new List<Button>();
        public List<int> selectedClassIDs = new List<int>();
        public int selectedClassID;
        backend.School currentSchool = backend.Schools[backend.currentSchoolID - 1];
        backend backendREF;
        frmManageClasses manageREF;

        public frmMoveStudentClass(frmManageClasses manage,backend backend, int selectedUserID,int currentClassID)
        {
            InitializeComponent();
            backendREF = backend;
            selectedUserIDREF = selectedUserID;
            currentClassIDREF = currentClassID;
            manageREF = manage;

            fillClassButtons();
        }

        public void fillClassButtons()
        {
            pnlClasses.Controls.Clear();
            newLocation = new Point(0, 0);
            backend.User user = backend.Users[selectedUserIDREF - 1];
            backend.Student student = (backend.Student)user;
            if (backend.currentSchoolID != -1)
            {
                for (int i = backend.Schools[backend.currentSchoolID - 1].classesInSchool.Count - 1; i >= 0; i--)
                {
                    if (backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].classID != currentClassIDREF) //don't consider the selected class
                    {

                        //or classes the user is in
                        if(!backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].Students.Contains(student))
                        {
                            addClassButton(backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].className, backend.Schools[backend.currentSchoolID - 1].classesInSchool[i].classID);
                        }
                    }
                }
            }
        }

        private void addClassButton(string ClassName, int classID) //add list of classes as buttons
        {

            Button btnClass = new Button();
            btnClass.BackColor = Color.White;
            btnClass.Height = 50;
            btnClass.Width = pnlClasses.Width;
            btnClass.Location = newLocation;
            newLocation.Offset(0, 5 + btnClass.Height);
            btnClass.MouseClick += BtnClass_MouseClick;
            btnClass.ForeColor = Color.SteelBlue;
            btnClass.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            btnClass.Text = ClassName;
            btnClass.Name = Convert.ToString(classID);

            pnlClasses.Controls.Add(btnClass);
            ClassButtonlist.Add(btnClass);
            //find the corresponding index to each i value
        }

        private void BtnClass_MouseClick(object sender, MouseEventArgs e)
        {
            Button test = (Button)sender;
            btnMoveToNewClass.Enabled = true;
            selectedClassID = currentSchool.getClassIDByClassName(test.Text);
            selectedClassIDs.Add(selectedClassID);
        }

        private void btnMoveToNewClass_Click(object sender, EventArgs e)
        {
            backend.User user = backend.Users[selectedUserIDREF - 1];
            backend.Student selectedStudent = (backend.Student)user; //only one student object needs to be made as we're moving one students' class.
            int oldClassID=-1;

            for (int i = selectedClassIDs.Count - 1; i >= 0; i--)
            {
                currentSchool.addStudentToClass(selectedStudent, selectedClassIDs[i]);


                //BELOW REMOVES STUDENT TOO, AKA MOVES STUDENT FROM ONE CLASS TO MANY. CHANGED TO ADD CLASS TO MANY OTHERS INSEAD
                ////remove from their old class
                ////if they're already in a class,
                //for (int l = currentSchool.classesInSchool.Count - 1; l >= 0; l--) //for every class,
                //{
                //    for (int j = currentSchool.classesInSchool[l].Students.Count - 1; j >= 0; j--) //for every student in that class,
                //    {
                //        if (currentSchool.classesInSchool[l].Students[j].userID == selectedUserIDREF) //if the userID of the student matches that of selected student id
                //        {
                //            oldClassID = l + 1; //save old class ID and...
                //        }
                //    }
                //}

                ////OR if the student was an unassigned student,

                //if (oldClassID == -1) // they're an unassigned member their classID will return -1. repeat above but for an unassigned member.
                //{
                //    currentSchool.removeUnassignedStudentByObject(selectedStudent);
                //}
                //else
                //{
                //    //remove from old class
                //    currentSchool.removeStudentFromClass(selectedStudent, oldClassID);
                //    Console.WriteLine("Moved student " + selectedStudent.Name + " from " + currentSchool.getClassNameByClassID(oldClassID) + " to " + currentSchool.getClassNameByClassID(selectedClassIDs[i]));
                //}
                //if the user doesn't already exist in that class,
                Console.WriteLine("Added student " + selectedStudent.Name + " to " + currentSchool.getClassNameByClassID(selectedClassIDs[i]));

            }
            MessageBox.Show("Operation successful.");
            ClassButtonlist.Clear();
            backend.Schools[backend.currentSchoolID - 1] = currentSchool;
            fillClassButtons();
            manageREF.fillStudentButtons();
            selectedClassIDs.Clear();
            btnMoveToNewClass.Enabled = false;
            //add the user to the class.
        }
    }
}
