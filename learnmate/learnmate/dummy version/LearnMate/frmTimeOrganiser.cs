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
    public partial class frmTimeOrganiser : Form
    {

        backend backendREF;
        backend.User currentUser = backend.Users[backend.currentUserID - 1];
        public DateTime dt = new DateTime();
        DateTime now = DateTime.Now;
        DateTime mondayDay;
        DateTime tuesdayDay;
        DateTime wednesdayDay;
        DateTime thursdayDay;
        DateTime fridayDay;
        DateTime maxDay;


        public frmTimeOrganiser(backend _backend)
        {
            InitializeComponent();
            //divide the panels into 18 Y pixels per hour meaning each half hour is 9Y pixels.
            //retrieve current week info
            //fill current week info
            backendREF = _backend;
            DateTime currentStartDate = searchlastmonday(6);

            mondayDay = currentStartDate;
            tuesdayDay = currentStartDate.AddDays(1);
            wednesdayDay = currentStartDate.AddDays(2);
            thursdayDay = currentStartDate.AddDays(3);
            fridayDay = currentStartDate.AddDays(4);
            maxDay = currentStartDate.AddDays(4);

            lblMondayDate.Text = mondayDay.Day.ToString();
            lblTuesdayDate.Text = tuesdayDay.Day.ToString();
            lblWednesdayDate.Text = wednesdayDay.Day.ToString();
            lblThursdayDate.Text = thursdayDay.Day.ToString();
            lblFridayDate.Text = fridayDay.Day.ToString();
            textBox1.Text=backend.Users[currentUser.userID - 1].note;

            refreshEvents();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static DateTime searchlastmonday(int tosubstract)
        {
            if ((System.DateTime.Today.AddDays(-tosubstract)).DayOfWeek != System.DayOfWeek.Monday)
            {
                searchlastmonday(tosubstract -= 1);
            }
            return System.DateTime.Today.AddDays(-tosubstract);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void offsetDays(int offset)
        {
            mondayDay = mondayDay.AddDays(offset);
            tuesdayDay = tuesdayDay.AddDays(offset);
            wednesdayDay = wednesdayDay.AddDays(offset);
            thursdayDay=thursdayDay.AddDays(offset);
            fridayDay = fridayDay.AddDays(offset);

        }
        public void fillDaysIntoLabels()
        {
            lblMondayDate.Text = mondayDay.Day.ToString();
            lblTuesdayDate.Text = tuesdayDay.Day.ToString();
            lblWednesdayDate.Text = wednesdayDay.Day.ToString();
            lblThursdayDate.Text = thursdayDay.Day.ToString();
            lblFridayDate.Text = fridayDay.Day.ToString();
        }
        public void refreshEvents()
        {
            clearPanels();
            int durationHeight;
            TimeSpan t;
            for (int i= currentUser.Events.Count - 1; i >= 0; i--)
            {
                //create a new button
                Button btn = new Button();
                t= currentUser.Events[i].endTime - currentUser.Events[i].startTime;
                Point startPoint = new Point(0, ((currentUser.Events[i].startTime.Hour*16)-96) + (int)(currentUser.Events[i].startTime.Minute*0.27)); //how many hours * 16, how many minutes * 0.27
                durationHeight = (int)(t.TotalMinutes*0.27);  //split panel into 18: 16 Y pixels each hour.

                btn.Size = new Size(pnlFriday.Width, durationHeight);
                btn.MouseClick += btnEvent_MouseClick;
                btn.Text = currentUser.Events[i].EventName;
                btn.Name = btn.Text.Replace(" ", "_")+"%"+currentUser.userID; //e.g. Picnic_In_Park%1
                btn.BackColor = Color.FromArgb(221,174,123);
                btn.Font = new Font("Darker Grotesque", 15, FontStyle.Regular);
                //then know the panel dates so you can match them if its within the given datespan.

                if (currentUser.Events[i].eventDate<fridayDay && currentUser.Events[i].eventDate > mondayDay)
                {
                    if (currentUser.Events[i].eventDate == mondayDay)
                    {
                        pnlMonday.Controls.Add(btn);
                    }
                    else if (currentUser.Events[i].eventDate == tuesdayDay)
                    {
                        pnlTuesday.Controls.Add(btn);
                    }
                    else if (currentUser.Events[i].eventDate == wednesdayDay)
                    {
                        pnlWednesday.Controls.Add(btn);
                    }
                    else if (currentUser.Events[i].eventDate == thursdayDay)
                    {
                        pnlThursday.Controls.Add(btn);
                    }
                    else if (currentUser.Events[i].eventDate == fridayDay)
                    {
                        pnlFriday.Controls.Add(btn);
                    }
                    btn.Location = startPoint;
                }

            }
        }

        private void btnEvent_MouseClick(object? sender, MouseEventArgs e)
        {
            btnRemoveEvent.Enabled = true;
        }

        public void clearPanels()
        {
            pnlFriday.Controls.Clear();
            pnlMonday.Controls.Clear();
            pnlThursday.Controls.Clear();
            pnlTuesday.Controls.Clear();
            pnlWednesday.Controls.Clear();
        }
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            subFrmAddEvent add = new subFrmAddEvent(this);
            add.Location = this.Location;
            add.Show();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            offsetDays(7);
            fillDaysIntoLabels();
            refreshEvents();
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            offsetDays(-7);
            fillDaysIntoLabels();
            refreshEvents();
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //error because i looked at the name of the remove button not the selected event
            //find the name of the event,
            string[] eventNameSeparated = btn.Name.Split("%");
            int userID = Convert.ToInt32(eventNameSeparated[1]);
            string _eventName = eventNameSeparated[0];
            string eventname = _eventName.Replace("_", " ");
            //for eac.... both equals, remove.

            for (int i = currentUser.Events.Count - 1; i >= 0; i--)
            {
                if (currentUser.Events[i].EventName == eventname&&currentUser.userID==userID)
                {
                    currentUser.Events.RemoveAt(i);
                }
            }

            refreshEvents();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            backend.Users[currentUser.userID - 1].note = textBox1.Text;
        }
    }
}
