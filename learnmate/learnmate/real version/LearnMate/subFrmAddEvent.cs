using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LearnMate
{
    public partial class subFrmAddEvent : Form
    {
        public backend backendREF;
        frmTimeOrganiser timeOrganiserREF;
        public subFrmAddEvent(frmTimeOrganiser tm)
        {
            InitializeComponent();
            //just fill by date comparison to current date.
            timeOrganiserREF = tm;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Contains("%"))
            {
                MessageBox.Show("% sign isn't allowed.");
                txtName.Text.Replace("%", "");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            backend.Event newevent = new backend.Event(); //new event object to be added to the user object
            newevent.EventName = txtName.Text; //set the events attributes
            newevent.EventDescription = txtDescription.Text;
            newevent.eventType = cmbEventType.SelectedText;

            var eventDayandTime = Convert.ToDateTime(dtPicker.Value); //convert the day they entered to dateTime format
            var eventDate = eventDayandTime.Date; //choose only the day
            newevent.eventDate = eventDate; 
            string startTime = cmbStartTimeh.Text + ":" + cmbStartTimem.Text + ":" + "00"; //write the startTime in the correct format for parsing
            DateTime start = DateTime.ParseExact(startTime, "HH:mm:ss", CultureInfo.InvariantCulture); //parse the startTime so it can be understood
            newevent.startTime = start;
            string endTime = cmbEndTimeh.Text + ":" + cmbEndTimem.Text + ":" + "00"; //do the same with the endTime
            DateTime end = DateTime.ParseExact(endTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            newevent.endTime = end;
            backend.Users[backend.currentUserID-1].Events.Add(newevent); //add that new event to the user object
            timeOrganiserREF.refreshEvents(); //refresh the elements in the time organiser.
        }
    }
}
