using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Delegates
{
    public class UseEvent
    {
        public event EventHandler MyEvent;
        
        public void UseMyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("An event is occured");
        }
 
    }
    public class EventAndDelegates
    {
        public static void Execute()
        {
            UseEvent useEvent = new UseEvent();
 
        }
    }
}
