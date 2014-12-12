using DesignPatterns.Creational.AbstractFactory;
using DesignPatterns.Creational.Factory;
using DesignPatterns.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main() 
        {
            //FactoryProgram.ExecuteFactory();
            //AbstractFactoryProgram.Execute();
            DIService.Execute();

            Console.ReadKey();
        }
    }
}
