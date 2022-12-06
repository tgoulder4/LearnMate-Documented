using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using static LearnMate.backend;

namespace LearnMate
{
    public partial class dummyUI : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        private static extern int AllocConsole();
        backend backendREF;
        public dummyUI()
        {
            InitializeComponent();
            AllocConsole();
            Console.WriteLine("New teacher 'TestTeacher' created.\nTestTeacher belongs to 'TyesSchool'.");
            
        }

        //public async void beginSession(backend.subTopic st)
        //{
        //    backend.subTopic currentSubTopic;
        //    backend.microSession currentMicroSession;
        //    backend.TopicQuestion currentTopicQuestion;
        //    currentSubTopic = st;

        //    for (int j = 0; j <= currentSubTopic.microSessions.Count - 1; j++) //for every microsession in that subtopic,
        //    {
        //        currentMicroSession = currentSubTopic.microSessions[j]; //the current microsession is the one in that index
        //        Console.WriteLine("Loading microsession " + currentMicroSession.name);
        //        loadVideo(); //video would theoretically be loaded into UI in future
        //        Console.WriteLine("Video Loaded");
        //        await btnNext.WhenClicked(); //waits until the next button is clicked
        //        for (int k = 0; k <= currentMicroSession.TopicQuestions.Count - 1; k++) //once video finished, go through questions
        //        {
        //            currentTopicQuestion = currentMicroSession.TopicQuestions[k];
        //            Console.WriteLine("Question: " + currentTopicQuestion.Question); //output the question 
        //        }
        //    }
        //    Console.WriteLine("End"); //once all above is complete, code ends.
        //}
        public void logout()
        {
            //string username = txtUsername.Text; //the username is that which they entered
            //int userID = backendREF.getUserIDWithUsername(username); //the current user
            //backend.Users[userID - 1].loggedIn = false; //..gets logged out.
        }

        public class microSession
        {
            
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            ////FOR SIGNING UP
            //if (drpUserType.Text == "Teacher") //if the entered user type is a teacher,
            //{
            //    backend.Teacher teacher = new backend.Teacher(txtUsername.Text, txtPassword.Text, txtName.Text);
            //    //make a new teacher, then
            //    if (!backendREF.checkAnySchoolExists()) //if a school doesn't exist,
            //    {
            //        MessageBox.Show("Looks like no schools exist. Would you like to create one?");
            //        //as they're a teacher, they have the permissions to create a new school
            //    }
            //    else //if a school DOES exist overall,
            //    {
            //        if (backendREF.checkASchoolexists(txtInstitution.Text))
            //        //check the school tehy entered exists
            //        {
            //            teacher.addToSchool(backendREF.getSchoolID(txtInstitution.Text));
            //            //if it does, add them to it
            //        }
            //        else
            //        {
            //            MessageBox.Show("That school doesn't exist.");
            //        }
            //        //if a school does exist, then what they've entered 
            //    }
            //    //create the new teacher and affiliate them with the entered school.
            //}
            //else if (drpUserType.Text == "Student") //if the entered user type is a student,
            //{
            //    backend.Student student = new backend.Student(txtUsername.Text, txtPassword.Text, txtName.Text);
            //    //make a new student
            //    if (!backendREF.checkAnySchoolExists())
            //    { //rest applies same as above
            //        MessageBox.Show("Looks like no schools currently exist. Please ask your teacher to configure one!");
            //    }
            //    else
            //    {
            //        if (backendREF.checkASchoolexists(txtInstitution.Text))
            //        {
            //            student.addToSchool(backendREF.getSchoolID(txtInstitution.Text));
            //        }
            //        else
            //        {
            //            MessageBox.Show("That school doesn't exist.");
            //        }
            //    }
            //}
            //else if (drpUserType.Text == "Home Learner")
            //{
            //    backend.HomeLearner hl = new backend.HomeLearner(txtUsername.Text, txtPassword.Text, txtName.Text);
            //}


            //if(!txtName.Text.Contains(" "))
            //{
            //    MessageBox.Show("Please enter your full name");
            //}
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No spaces are allowed.");
        }
    }
    public static class Utils
    {
        public static Task WhenClicked(this Control target)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler onClick = null;
            onClick = (sender, e) =>
            {
                target.Click -= onClick;
                tcs.TrySetResult(null);
            };
            target.Click += onClick;
            return tcs.Task;
        }
    }

}
