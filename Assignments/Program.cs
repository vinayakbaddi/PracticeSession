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

            string data = "Arrange meeting for 60min \n New client meet 120min";

            var results = schedulePresenter.SubmitSchedule(data);
            Console.WriteLine(results);

            Console.ReadKey();
        }
    }
}
