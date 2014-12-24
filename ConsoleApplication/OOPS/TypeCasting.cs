using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.OOPS
{
    public abstract class MyAbstract
    {
        public int MyDataVairable = 10;

        public int CanBeShadowVairable = 1;

        //private MyAbstract()
        //{
        //    System.Console.WriteLine("This is my private constructor");
        //}

        //Mandatory
        public MyAbstract()
        {
            System.Console.WriteLine("This is me abstract constructor");
        }

        public MyAbstract(int a)
        {
            System.Console.WriteLine("This is me, parameterised constructor {0}", a);
        }

        public abstract void AbstractMethod();

        public virtual void VirtualMethod() 
        {
            System.Console.WriteLine("Virtual method from abstract class");
        }

    }

    public class ImplementMyAbstract : MyAbstract
    {
        public ImplementMyAbstract() : base(10)
        { 
            
        }
        public ImplementMyAbstract(int a)
            : base(a)
        {

        }
        public new int CanBeShadowVairable = 11;

        public int MyOwnVariable = 20;
        
        public void OwnMethod() 
        {
            System.Console.WriteLine(MyDataVairable);

            MyDataVairable = 20;

            System.Console.WriteLine(MyDataVairable);

        }

        public override void AbstractMethod()
        {
            System.Console.WriteLine("Abstract method implementation");
        }
    }

    public class A
    {
        private int AVariableA = 1;

        public A()
        {
            System.Console.WriteLine("From A's Constructor");
        }

        public virtual void MyMethod()
        {
            System.Console.WriteLine("From Class A");
        }

        public virtual void AnotherMethodToBeShadowed()
        {
            System.Console.WriteLine("From Class A AnotherMethodToBeShadowed");
        }
    }

    class B : A
    {
        private int BVariableA = 10;

        public B()
        {
            System.Console.WriteLine("From B's Constructor");
        }

        public override void MyMethod()
        {
            //base.MyMethod();
            System.Console.WriteLine("From Class B");
        }

        public new void AnotherMethodToBeShadowed()
        {
            System.Console.WriteLine("From Class B AnotherMethodToBeShadowed");
        }

        public void CheckSuperClassPrivateVariable()
        {
            System.Console.WriteLine();
        }
    
    }

    class TypeCasting
    {
        public void Run()
        {
            Object object1 = new Object();
            A a = new A();
            B b = new B();

            //Error	1	Cannot implicitly convert type 'ConsoleApplication.OOPS.A' to 'ConsoleApplication.OOPS.B'. An explicit conversion exists (are you missing a cast?)	
            //B b2 = new A();
            
            object1 = a;
            Object object2 = new A();
            //b = (B)a; // Invalid Cast Exception
            a = b;
            a.MyMethod();
            a.AnotherMethodToBeShadowed();
            b.AnotherMethodToBeShadowed();
            
            A a1 = new B();
            a1.MyMethod();
            a1.AnotherMethodToBeShadowed();                        
        }

        public void AbstracPractise() 
        {
            MyAbstract myAbstract = new ImplementMyAbstract();

            System.Console.WriteLine("myAbstract.MyDataVairable {0}", myAbstract.MyDataVairable);
            System.Console.WriteLine("myAbstract.CanBeShadowVairable {0}", myAbstract.CanBeShadowVairable);
            
            // Can't access
            //System.Console.WriteLine("myAbstract.CanBeShadowVairable {0}", myAbstract.MyOwnVariable);

            myAbstract.AbstractMethod();
            myAbstract.VirtualMethod();

            ImplementMyAbstract implementMyAbstract = new ImplementMyAbstract();
            System.Console.WriteLine("implementMyAbstract.MyDataVairable {0}", implementMyAbstract.MyDataVairable);
            implementMyAbstract.OwnMethod();

            System.Console.WriteLine("implementMyAbstract.CanBeShadowVairable {0} ", implementMyAbstract.CanBeShadowVairable);

            implementMyAbstract = new ImplementMyAbstract(20);
        }
    }
}
