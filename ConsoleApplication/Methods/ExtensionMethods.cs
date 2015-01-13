using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.Methods
{
    public class UseOfExtensionMethods
    {
        public string JustMethod()
        {
            Console.WriteLine("This is more data");
            return string.Empty;
        }
    }

    public static class ExtensionMethod
    {
        public static string DefineExtension(this UseOfExtensionMethods ext, string data)
        {
            Console.WriteLine("Inside extension method {0}", data);
            return data;
        }
    }

    public class ExecuteExtension
    { 
        

        public static void ExecuteMethod()
        {
            UseOfExtensionMethods ex = new UseOfExtensionMethods();
            ex.JustMethod();
            ex.DefineExtension("data");
           
        }
    }
}
