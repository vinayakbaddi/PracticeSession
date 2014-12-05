using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns.Creational.Singleton
{
    interface ISingleton
    { 

    }

    // Double checked locking
    sealed class Singleton
    {
        private static Singleton singleton = null;

        private Singleton() 
        { 
        }

        public static Singleton GetSingleton()
        {
            if (singleton != null)
                return singleton;

            Singleton tempSingleton = new Singleton();

            Interlocked.CompareExchange(ref singleton, tempSingleton, null);

            return singleton;
        }
    }

    //Using Lazy and a much universal solution
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance { get {return lazy.Value;} }

        private LazySingleton() { }

        public void UnderHoodLaziness() {
            Console.WriteLine(lazy.Value);
            Console.WriteLine(lazy.IsValueCreated);
            Console.WriteLine(lazy.GetType());
        }
    }
}
