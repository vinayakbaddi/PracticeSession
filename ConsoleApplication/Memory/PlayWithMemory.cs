using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Memory
{
    public class UseDestructor
    {
        public void Test()
        {
            Console.WriteLine("RUNNING");
        }

         ~UseDestructor()
        {
            Console.WriteLine("Destructor called");
            Console.ReadKey();
        }
    }

    public static class PlayWithMemory
    {
        public static void Execute()
        {
            UseDestructor use = new UseDestructor();
            use.Test();
            //use = null;
        }
    }
}
