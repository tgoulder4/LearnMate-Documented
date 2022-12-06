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
            backend.Student selectedStudent = (backend.Student)user; //cast the user as a student to access student attirubtes
            int oldClassID=-1;

            for (int i = selectedClassIDs.Count - 1; i >= 0; i--)  //for every class they selected
            {
                currentSchool.addStudentToClass(selectedStudent, selectedClassIDs[i]); //they then also exist in that class. 
                //they are not removed from the current class as a student can exist in multiple classes at once.
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
