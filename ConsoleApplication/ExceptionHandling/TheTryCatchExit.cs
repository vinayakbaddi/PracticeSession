using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.ExceptionHandling
{
    public class TheTryCatchExit
    {

        public static void Main()
        {
            try
            {
                System.Console.WriteLine("HERE at Try start");
                Environment.Exit(Environment.ExitCode);
                System.Console.WriteLine("HERE at Try End");
                System.Console.ReadLine();

            }
            catch (Exception ex) { }
            finally
            {
                System.Console.WriteLine("HERE at FInally");
                System.Console.ReadLine();


            }
        }
    }
}
