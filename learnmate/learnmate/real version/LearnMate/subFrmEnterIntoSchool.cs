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
    public partial class subFrmEnterIntoSchool : Form
    {
        backend backendREF;
        frmContainer containerREF;
        public subFrmEnterIntoSchool(backend backend, frmContainer container)
        {
            InitializeComponent();
            backendREF = backend;
            containerREF = container;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!backendREF.checkASchoolexists(txtInstitution.Text))
            {
                MessageBox.Show("That school doesn't exist. Ask a teacher to set one up for you!");
            }
            else
            {
                School school = Schools[backendREF.getSchoolID(txtInstitution.Text) - 1];
                //get current student
                backend.User user = backend.Users[currentUserID - 1];
                backend.Student student = (backend.Student)user;
                student.schoolID = Schools[backendREF.getSchoolID(txtInstitution.Text) - 1].schoolID;
                student.replaceInUsersList();
                school.unassignedStudents.Add(student);
                school.replaceInSchoolsList();
                backendREF.setCurrentUserWithSchool(backend.currentUserID, txtInstitution.Text);
                Schools[backendREF.getSchoolID(txtInstitution.Text) - 1] = school;
                containerREF.loadHomepage();
                containerREF.refreshAllElements();
                this.Close();
            }

        }
    }
}
