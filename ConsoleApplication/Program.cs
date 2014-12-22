using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication.LINQ;
using ConsoleApplication.OOPS;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oops();
            //TypeCasting();
            Overloading();
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

        public static void Oops()
        {
            ImplementOops implementOops = new ImplementOops();
            implementOops.MyOwnMethod();

            ImplementOops implementOops2 =new ImplementOops();
            implementOops2.MyOwnMethod();

            IOpenElectronicLock openElectronicLock = implementOops;
            openElectronicLock.Open();

            IOpenLock openLock = implementOops;
            openLock.Open();

            ImplementMultipleInterfaces implementMultipleInterfaces = new ImplementMultipleInterfaces();
            implementMultipleInterfaces.MyOwnMethod();

            //ILockAdaptor iLockAdaptor = implementMultipleInterfaces;
            //iLockAdaptor.Open(); //Ambigous Call, CTE

            //ILockAdaptor iLockAdaptor2 = (IOpenElectronicLock)implementMultipleInterfaces;//Cannot convert this type

            //IOpenElectronicLock openElectronicLock2;
            //ILockAdaptor iLockAdaptor3 = (IOpenElectronicLock)openElectronicLock2; // Cannot implicitly convert

            IOpenElectronicLock openElectronicLock2 = implementOops;
            ILockAdaptor lockAdaptor4 = (ILockAdaptor)openElectronicLock2;

            ILockAdaptor lockAdaptor5 = implementOops;
            IOpenElectronicLock openElectronicLock5 = lockAdaptor5;
            openElectronicLock5.Open();
            
        }

        public static void TypeCasting()
        {
            TypeCasting typeCasting = new TypeCasting();
            //typeCasting.Run();
            typeCasting.AbstracPractise();
        }

        public static void Overloading() { 
            Overloading overloading  = new Overloading();
            overloading.RunOverloading();
        }
    }
}

