using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Dates
{
    public class Dates
    {

        public static void Weekly(DateTime startDate, DateTime endDate)
        {
            int WeeklyDays = 4; // Working Days
            
            var weeks = new List<Tuple<DateTime, DateTime>>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date == startDate)
                {
                    var start = (int)date.DayOfWeek;
                    if (start == 0 || start == 6)
                        continue;
                    var target = (int)DayOfWeek.Friday;
                    if (target < start)
                        target += WeeklyDays;
                    weeks.Add(Tuple.Create(date, date.AddDays(target - start)));
                }
                else if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    if (date.AddDays(WeeklyDays) > endDate)
                        weeks.Add(Tuple.Create(date, date.AddDays((endDate-date).TotalDays)));
                    else
                        weeks.Add(Tuple.Create(date, date.AddDays(WeeklyDays)));
                }
            }
            foreach (var week in weeks)
                Console.WriteLine("Start Date {0} End Date {1}", week.Item1, week.Item2);

        }


        public static void FrequencyFallingThisWeek(DateTime startDate, DateTime endDate)
        {
            int WeeklyDays = 4; // Working Days

            var weeks = new List<Tuple<DateTime, DateTime>>();
            
            DateTime weekStartDate = DateTime.Now;

            if (weekStartDate < startDate)
                return;

            DateTime weekEndDate = DateTime.Now;

            while(weekEndDate.DayOfWeek != DayOfWeek.Friday)
                weekEndDate = weekEndDate.AddDays(1);

            if (startDate < weekEndDate && startDate.AddDays(5) >= weekEndDate)
                return;

            for (var date = weekStartDate; date <= endDate && date <= weekEndDate; date = date.AddDays(1))
            {
                if (date == weekStartDate)
                {
                    var start = (int)date.DayOfWeek;
                    if (start == 0 || start == 6)
                        continue;
                    var target = (int)DayOfWeek.Friday;
                    if (target < start)
                        target += WeeklyDays;
                    weeks.Add(Tuple.Create(date, date.AddDays(target - start)));
                }
                else if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    if (date.AddDays(WeeklyDays) > endDate)
                        weeks.Add(Tuple.Create(date, date.AddDays((endDate - date).TotalDays)));
                    else
                        weeks.Add(Tuple.Create(date, date.AddDays(WeeklyDays)));
                }
            }
            foreach (var week in weeks)
                Console.WriteLine("Start Date {0} End Date {1}", week.Item1, week.Item2);

        }

        public static void FrequencyFallingNextWeek(DateTime startDate, DateTime endDate)
        {
            int WeeklyDays = 4; // Working Days

            var weeks = new List<Tuple<DateTime, DateTime>>();
            DayOfWeek startOfTriggerDay = DayOfWeek.Friday;
            DateTime weekStartDate = DateTime.Now;

            while (weekStartDate.DayOfWeek != startOfTriggerDay)
                weekStartDate=weekStartDate.AddDays(1);

            weekStartDate = weekStartDate.AddDays(3);

            if (weekStartDate < startDate)
                return;

            DateTime weekEndDate = weekStartDate.AddDays(5);

            
            for (var date = weekStartDate; date <= endDate && date<=weekEndDate; date = date.AddDays(1))
            {
                if (date == weekStartDate)
                {
                    var start = (int)date.DayOfWeek;
                    if (start == 0 || start == 6)
                        continue;
                    var target = (int)DayOfWeek.Friday;
                    if (target < start)
                        target += WeeklyDays;
                    weeks.Add(Tuple.Create(date, date.AddDays(target - start)));
                }
                else if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    if (date.AddDays(WeeklyDays) > endDate)
                        weeks.Add(Tuple.Create(date, date.AddDays((endDate - date).TotalDays)));
                    else
                        weeks.Add(Tuple.Create(date, date.AddDays(WeeklyDays)));
                }
            }
            foreach (var week in weeks)
                Console.WriteLine("Start Date {0} End Date {1}", week.Item1, week.Item2);

        }

        public static void BiWeekly(DateTime startDate, DateTime endDate)
        {
            int biWeeklyDays = 11; // Working Days
            
            var weeks = new List<Tuple<DateTime, DateTime>>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date == startDate)
                {
                    var start = (int)date.DayOfWeek;
                    if (start == 0 || start == 6)
                        continue;
                    var target = (int)DayOfWeek.Friday;
                    if (target < start)
                        target += biWeeklyDays;
                    weeks.Add(Tuple.Create(date, date.AddDays(target - start)));
                }
                else if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    if (date.AddDays(biWeeklyDays) > endDate)
                        weeks.Add(Tuple.Create(date, date.AddDays((endDate - date).TotalDays)));
                    else
                    {
                        var update = date.AddDays(biWeeklyDays);
                        weeks.Add(Tuple.Create(date, update));
                        date = update;
                    }
                }
            }
            foreach (var week in weeks)
                Console.WriteLine("Start Date {0} End Date {1}", week.Item1, week.Item2);

        }

        public static int GetMonthsBetween(DateTime from, DateTime to)
        {
            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }

        public static void Monthly(DateTime startDate, DateTime endDate)
        {
            int data= GetMonthsBetween(startDate, endDate);

            //Console.WriteLine("Start Date {0} End Date {1}, months {2}", startDate, endDate, data);
            for (var date = startDate; date < endDate;date= date.AddMonths(1))
            {
                var start = (int)date.DayOfWeek;
                if (start == 0 )
                {
                    Console.WriteLine("Start Date {0} End Date {1}", startDate, date.AddDays(-2));
                    startDate = date.AddDays(1);
                }
                else if (start == 6)
                {
                    Console.WriteLine("Start Date {0} End Date {1}", startDate, date.AddDays(-1));
                    startDate = date.AddDays(2);
                }
                else{
                    Console.WriteLine("Start Date {0} End Date {1}", startDate, date);
                    startDate = date;
                }
            }

        }   

        public static void Execute()
        {
            Console.WriteLine("Weekly \n");

            FrequencyFallingThisWeek(DateTime.Now, DateTime.Now.AddDays(30));

            Console.WriteLine("NExt Weekly \n");
            FrequencyFallingNextWeek(DateTime.Now.AddDays(5), DateTime.Now.AddDays(30));

            //Weekly(new DateTime(2015,1,1),new DateTime(2015,1,21));
            //Console.WriteLine("\n");
            //Weekly(DateTime.Now, new DateTime(2015, 5, 31));
            //Console.WriteLine("\n");

            //Console.WriteLine("Bi Weekly \n");
            //BiWeekly(new DateTime(2015, 1, 1), new DateTime(2015, 1, 21));
            //Console.WriteLine("\n");

            //Console.WriteLine("Monthly\n");
            //Monthly(new DateTime(2015, 1, 1), new DateTime(2015, 3, 21));
        }
    }
}
