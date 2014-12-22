using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication.OOPS
{
    public class Parent
    {
        public void Foo(int x) 
        {
            Console.WriteLine("Parent.Foo (int x)");
        }

        public virtual void TheOtherFoo(int x)
        { 
            Console.WriteLine("Parent.TheOtherFoo(int x)");
        }

    }

    public class Child : Parent 
    {
        public int a;
        public void Foo(double x)
        {
           
            Console.WriteLine("Child .Foo (double x)");
        }

        public override void TheOtherFoo(int x)
        {
            Console.WriteLine("Child.TheOtherFoo(int x)");
        }

        public void TheOtherFoo(double x)
        {
            Console.WriteLine("Child.TheOtherFoo(double x)");
        }

        public class GrandChild
        {
            public void Foo(int x)
            {
               Console.WriteLine("GrandChild .Foo (double x)");
            }
            public void Foo1(int x)
            {
                Console.WriteLine("GrandChild .Foo (double x)");
            }
        }
        
    }

    public class Overloading
    {
        public void RunOverloading()
        {
            Child a = new Child();            
            a.Foo(10);
            a.TheOtherFoo(10);
            Child.GrandChild g = new Child.GrandChild();
            

        }
    }
}
