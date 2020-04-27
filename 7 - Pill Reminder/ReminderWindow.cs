using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        private readonly BindingList<PillModel> medications = new BindingList<PillModel>();
        private BindingList<PillModel> pillsToTake = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";

            PopulateDummyData();
        }

        private void PopulateDummyData()
        {
            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.ParseExact("0:15 am", "h:mm tt", null, System.Globalization.DateTimeStyles.AssumeLocal) });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("11:45 pm") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("6:15 pm") });
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            List<PillModel> temp = new List<PillModel>();

            foreach (PillModel medication in medications)
            {
                if (DateTime.Now.TimeOfDay >= medication.TimeToTake.TimeOfDay && medication.LastTaken.Date != DateTime.Now.Date)
                    temp.Add(medication);
            }

            if (temp.Count != pillsToTake.Count)
            {
                pillsToTake = new BindingList<PillModel>(temp);
                pillsToTakeListBox.DataSource = pillsToTake.OrderBy(o => o.TimeToTake).ToList();
                pillsToTakeListBox.DisplayMember = "PillInfo";
            }
        }

        private void TakePill_Click(object sender, EventArgs e)
        {
            var item = pillsToTakeListBox.SelectedItem;

            foreach (PillModel medication in medications)
            {
                if (medication.Equals(item))
                {
                    medication.LastTaken = DateTime.Now;
                    pillsToTake.Remove(medication);
                    pillsToTakeListBox.DataSource = pillsToTake;
                    break;
                }
            }
        }
    }
}