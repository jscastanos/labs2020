using System;

namespace PillReminderUI
{
    public class PillModel
    {
        public string PillName { get; set; }
        public DateTime TimeToTake { get; set; }
        public DateTime LastTaken { get; set; }

        public string PillInfo
        {
            get
            {
                return $"{ PillName } at { TimeToTake:h:mm tt}";
            }
        }
    }
}