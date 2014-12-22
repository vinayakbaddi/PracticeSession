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
    }
}
