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
            backend.Event newevent = new backend.Event();
            newevent.EventName = txtName.Text;
            newevent.EventDescription = txtDescription.Text;
            newevent.eventType = cmbEventType.SelectedText;

            var eventDayandTime = Convert.ToDateTime(dtPicker.Value);
            var eventDate = eventDayandTime.Date;
            newevent.eventDate = eventDate; //issue: has minutes and seconds 
            string startTime = cmbStartTimeh.Text + ":" + cmbStartTimem.Text + ":" + "00";
            DateTime start = DateTime.ParseExact(startTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            newevent.startTime = start;
            string endTime = cmbEndTimeh.Text + ":" + cmbEndTimem.Text + ":" + "00";
            DateTime end = DateTime.ParseExact(endTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            newevent.endTime = end;
            backend.Users[backend.currentUserID-1].Events.Add(newevent);
            timeOrganiserREF.refreshEvents();
        }
    }
}
