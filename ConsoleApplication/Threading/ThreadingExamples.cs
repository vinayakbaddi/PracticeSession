using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Threading
{
    class ThreadingExamples
    {
    }

    public class TaskExample
    {
        public void runMe()
        {
            Console.WriteLine("data");
        }

        public static void Execute()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                int ctr = 0;
                for (ctr = 0; ctr <= 10000; ctr++)
                { }
                Console.WriteLine("Finished at {0} the loop ", ctr);
            });
            task.Wait();

            //Task.Factory.StartNew(()=>)
        }
    }
}
