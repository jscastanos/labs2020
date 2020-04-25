﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6___DateTime
{
    class Program
    {

        static void Main()
        {
            string[] options = new string[3] { "Date", "Time", "Exit" };

            Console.WriteLine("DateTime - Challenge");

            while (true)
            {
                switch (SelectOptions(options, "Please Select: "))
                {
                    case 1:
                        CalculateDate();
                        break;
                    case 2:
                        CalculateTime();
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void CalculateDate()
        {
            Regex dateRX = new Regex(@"^(\d{1,2})-(\d{1,2})-(\d{1,4})$");

            string[] format = new string[2] { "MM-dd-yyyy", "dd-MM-yyyy" };
            int formatIndex = SelectOptions(format, "Select Date Format: ");
            string dateStr;

            Console.WriteLine("Please not that the system only accepts \"-\" or dash as date separator");
            Console.Write($"Enter Date ({format[formatIndex - 1]}): ");

            dateStr = Console.ReadLine();

            if (dateRX.IsMatch(dateStr))
            {
                var splitDate = dateStr.Split('-').Select(Int32.Parse).ToArray();

                try
                {
                    DateTime newDate;

                    if (formatIndex == 1)
                        newDate = Convert.ToDateTime(splitDate[0] + "-" + splitDate[1] + "-" + splitDate[2]);
                    else
                        newDate = Convert.ToDateTime(splitDate[1] + "-" + splitDate[0] + "-" + splitDate[2]);

                    Console.WriteLine($"It has been { (DateTime.Now - newDate).Days } days since { newDate.ToString(format[formatIndex - 1])} \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} \n");
                }
            }
            else Console.WriteLine("Invalid Date\n");


        }


        static void CalculateTime()
        {
            Regex timeRx1 = new Regex(@"^(\d{1,2}):(\d{1,2}) ([aApP][mM])$");
            Regex timeRx2 = new Regex(@"^(\d{1,2}):(\d{1,2})$");

            string[] formats = new string[2] { "12 hr AM/PM", "24 hr" };
            int formatIndex = SelectOptions(formats, "Select Time Format: ");
            string timeStr;

            Console.Write($"Enter a ({formats[formatIndex - 1]}) time: ");
            timeStr = Console.ReadLine();

            int[] splitTime;

            switch (formatIndex)
            {
                case 1 when timeRx1.IsMatch(timeStr):
                    var tempTime = timeStr.Split(' ').ToArray();
                    string period = tempTime[1];
                    splitTime = SplitTime(tempTime[0], ':');

                    if (splitTime[0] <= 12)
                    {
                        if (period.ToLower().Equals("pm") && splitTime[0] != 12)
                            splitTime[0] += 12;

                        DisplayTimeDifference(splitTime);

                    }
                    else goto default;
                    break;

                case 2 when timeRx2.IsMatch(timeStr):
                    splitTime = SplitTime(timeStr, ':');

                    if (splitTime[0] <= 24)
                        DisplayTimeDifference(splitTime);
                    else goto default;
                    break;

                default:
                    Console.WriteLine("Invalid Time\n");
                    break;

            }

        }

        static int[] SplitTime(string time, char separator)
        {
            return time.Split(separator).Select(Int32.Parse).ToArray();
        }

        static void DisplayTimeDifference(int[] time)
        {
            try
            {
                TimeSpan timeNow = DateTime.Now.TimeOfDay;

                var timeDiff = timeNow - new TimeSpan(time[0], time[1], 0);
                Console.WriteLine($"The time is { Math.Abs(timeDiff.Hours) } hours and { Math.Abs(timeDiff.Minutes) }  minutes {(timeDiff.Hours > 0 ? "ago" : "from now")}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} \n");
            }
        }

        static int SelectOptions(string[] options, string message)
        {
            while (true)
            {

                for (var index = 0; index < options.Length; index++)
                    Console.WriteLine($"[{index + 1}] - {options[index]}");

                Console.Write("\n" + message);

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    if (command > 0 && command <= options.Length)
                        return command;
                    else
                        Console.WriteLine("Invalid Command\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid Command: {ex.Message}\n");
                }


            }
        }
    }
}
