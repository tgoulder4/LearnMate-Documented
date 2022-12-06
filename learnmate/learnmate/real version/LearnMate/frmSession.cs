using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LearnMate
{

    public partial class frmSession : Form
    {
        public string currentMCName,currentSubjectName,currentSubTopicName,currentTopicName;
        public int currentSubjectID,currentSubTopicID,currentTopicID;
        public List<backend.subTopic> subTopicsLeft = new List<backend.subTopic>();
        public List<int> subTopicIDsChosen;
        public backend.Subject currentSubject;
        public backend.subTopic currentSubTopic;
        public backend.microSession currentMicroSession;
        public backend.TopicQuestion currentTopicQuestion;
        public bool finished = false;
        backend backendREF;
        frmContainer containerREF;
        public bool watchedVideo;
        public bool completedQuestion;

        public frmSession(backend backend, frmContainer container, string _currentSubjectName, string _currentTopic,string _currentSubTopic,List<int>chosenSubTopicIDs)
        {
            InitializeComponent();
            currentSubjectName = _currentSubjectName;
            currentSubjectID = backend.getSubjectIDByName(_currentSubjectName);
            currentSubject = backend.Subjects[currentSubjectID - 1];

            backendREF = backend;
            containerREF = container;

            currentSubTopicName = _currentSubTopic;
            currentTopicName = _currentTopic;
            currentTopicID = currentSubject.getTopicIDByName(currentTopicName);


            currentSubTopicID = currentSubject.getSubTopicIDByName(currentSubTopicName,currentTopicID);

            subTopicIDsChosen = chosenSubTopicIDs;

            for (int i = subTopicIDsChosen.Count - 1; i>=0; i--)
            {
                subTopicsLeft.Add(backend.Subjects[currentSubjectID - 1].SubjectTopics[currentTopicID-1].subTopics[i]);
            }

            beginSession();

        }

        public async void beginSession()
        {
            //for every microsession in the selected sub topic, [play the video file then for every topic question load the practice question].
            //updateMicrosessionlabel(),loadPracticeFrame(), loadPracticeQuestion(q,a).
            while (!finished) //&sessionsleft.count>=0;
            {
                for (int i = 0;i<= subTopicsLeft.Count - 1; i++)
                {
                    Console.WriteLine("Loading next subtopic...");
                    currentSubTopic=subTopicsLeft[i];
                    for (int j = 0; j <= currentSubTopic.microSessions.Count - 1; j++)
                    {
                        Console.WriteLine("Loading next microsession...");
                        currentMicroSession = currentSubTopic.microSessions[j];
                        updateMicroSessionLabel();
                        loadVideoFrame(currentMicroSession.name, currentMicroSession.videoPath); //video path goes in 

                        //await watchedVideo=true instead of while loop

                        Console.WriteLine("Video Loaded");
                        //then wait until video elapsed = full , set watchedVideo=true;
                        await pctSkip.WhenClicked();


                        Console.WriteLine("Video has been watched");
                        loadPracticeFrame();
                        for (int k = 0; k<= currentMicroSession.TopicQuestions.Count - 1; k++)
                        {
                            Console.WriteLine("Loading next topic question...");
                            currentTopicQuestion = currentMicroSession.TopicQuestions[k];
                            loadPracticeQuestion(currentTopicQuestion.Question, currentTopicQuestion.Answer);

                            //await completedQuestion=true instead of while loop
                            await lblSubmit.WhenClicked();
                        }
                    }
                    subTopicsLeft.Remove(subTopicsLeft[i]); //we've finished going through all microsessioins here

                    //subTopicsLeft.remove at current sub topic, exit while loop to prevent error.
                    if (subTopicsLeft.Count != 0)
                    {
                        finished = true;
                    }

                }
                
                finished = true;
            }
            containerREF.loadLearnAndPractice();
            MessageBox.Show("Congratulations! You've finished your session. Taking you back...");
            this.Close();
            //stop timer here
        }

        public void checkVideoWatched()
        {
            watchedVideo = true;
            //put actual code which checks the duration of the video compared to its proper duration
        }
        public void updateMicroSessionLabel()
        {
            containerREF.lblTitle.Text="In session: "+currentSubjectName + " - " + currentMicroSession.name;//curentSubject+currentMicroSession
        }

        private void pctSkip_Click(object sender, EventArgs e)
        {
            watchedVideo = true;
        }

        public void loadPracticeQuestion(string question, string answer)
        {
            lblQuestion.Text = question;
            lblAnswer.Text= answer;
        }
        public void loadVideoFrame(string videoTitle, string videoPath)
        {
            pnlControls.Visible = true;
            lblVideoTitle.Visible = true;
            lblQuestion.Visible = false;
            txtAnswer.Visible = false;
            lblAnswer.Visible = false;
            btnSubmit.Visible = false;
            lblVideoTitle.Text = videoTitle;
            
            lblVideoTitle.Text = videoTitle;
            this.BackgroundImage = Image.FromFile("[video]LMsessionBkg.jpg");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //consider the answer in txtAnswer
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            finished = true;
        }

        public void loadPracticeFrame()
        {
            pnlControls.Visible = false;
            lblVideoTitle.Visible = false;
            lblQuestion.Visible = true;
            txtAnswer.Visible = true;
            lblAnswer.Visible = true;
            btnSubmit.Visible = true;


            updateMicroSessionLabel();
            this.BackgroundImage = Image.FromFile("practiceQuestion.jpg");
        }
    }

    //foreign code for await functions.
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
