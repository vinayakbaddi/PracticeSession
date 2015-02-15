using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication.LINQ;
using ConsoleApplication.OOPS;
using ConsoleApplication.Threading;
using ConsoleApplication.Methods;
using ConsoleApplication.Delegates;
using ConsoleApplication.Memory;
using ConsoleApplication.C_Sharp._6._0;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringPlay.Execute();
            Indexers.Execute();
            //PlayWithMemory.Execute();
            //Oops();
            //Overloading();
            //TypeCasting();
            //LinqPlay();
            //ExecuteExtension.ExecuteMethod();
            //DelegateExample.RunExample();
            System.Console.ReadKey();
        }

        public void Other() {
            //Logic.TestObject();
            //System.Console.WriteLine(Guid.NewGuid());
            //System.Console.ReadLine();
            //StringPlay.StringSearch();
            //Logic.TestBoolConditions();
            //new ListPlay().ListStringReplace();
            //var playWithClassesForLinq = new PlayWithClassesForLinq();
            //playWithClassesForLinq.Play();
            StringPlay.DateWithoutTime();
            
        }

        public static void LinqPlay()
        {
            LinqMethods.Execute();
        }

        

        public static void TypeCasting()
        {
            TypeCasting typeCasting = new TypeCasting();
            typeCasting.Run();
            //typeCasting.AbstracPractise();
        }

        public static void Overloading() { 
            Overloading overloading  = new Overloading();
            overloading.RunOverloading();
        }

        public static void Threading() {
            TaskExample.Execute();
        }
    }
}

