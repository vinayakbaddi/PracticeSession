using Assignments.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments
{
    class Program
    {
        public static void Main()
        {
            SchedulePresenter schedulePresenter = new SchedulePresenter();

            string data = "Arrange meeting for 60min\nThis is me 60min";

            var results = schedulePresenter.SubmitSchedule(data);
            Console.WriteLine(results);

            Console.ReadKey();
        }
    }
}
