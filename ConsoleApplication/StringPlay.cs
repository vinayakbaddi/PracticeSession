using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    public static class StringPlay
    {
        public static void StringNull()
        {
            string v = null;
            if (v != null)
            {
                if (string.IsNullOrEmpty(v.Trim()))
                {
                    System.Console.WriteLine("Is Null");
                }
                else
                {
                    System.Console.WriteLine("Is NOT Null");


                }
            }
        }

        public static void randomNumbers()
        {
            Random random = new Random(2012);

            for (int i = 1; i < 5; i++)
            {
                System.Console.WriteLine("> {0}", random.Next(9999));
            }
            Console.ReadKey();
        }

        public static void EnumListToString()
        {
            var Weekdays = new List<DayOfWeek>()
                               {
                                   DayOfWeek.Friday,
                                   DayOfWeek.Saturday
                               };

            Console.ReadKey();
        }

        public static void StringSearch()
        {
            var data = "%123";
            if (data.IndexOf("%") < 0)
            {
                System.Console.WriteLine("String not found " + data.IndexOf("%"));
            }
            else
            {
                System.Console.WriteLine("String found " + data.IndexOf("%"));

            }
        }

        public static void DateWithoutTime()
        {
            var dateWithoutTime = new DateTime(2014,1,1);
            Console.WriteLine(dateWithoutTime);
            Console.WriteLine(DateWithoutTimeCheck);

        }

        //public DateTime DateWithoutTime { get; set; }
        private static DateTime myDateTime;

        public static DateTime DateWithoutTimeCheck
        {
            get { return myDateTime; }
            set
            {
                myDateTime = value;
            }
        }



    }
}

