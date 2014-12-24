using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.OOPS
{
    public class ImplementOops : IOpenLock, IOpenElectronicLock   , ILockAdaptor 
    {
        void IOpenLock.Open()
        {
            Console.WriteLine("IOpenLock.Open execution");
        }

        void IOpenElectronicLock.Open()
        {
            Console.WriteLine("IOpenElectronicLock.Open execution");
        }

        public void MyOwnMethod()
        {
            Console.WriteLine("My OWN Method");
        }

        public static void Oops()
        {
            ImplementOops implementOops = new ImplementOops();
            implementOops.MyOwnMethod();

            ImplementOops implementOops2 = new ImplementOops();
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
    }
}
