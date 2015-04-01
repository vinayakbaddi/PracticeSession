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

            //     Compares two instances of the specified reference type T for equality and,
            //     if they are equal, replaces one of them.
            //
            // Parameters:
            //   location1:
            //     The destination, whose value is compared with comparand and possibly replaced.
            //     This is a reference parameter (ref in C#, ByRef in Visual Basic).
            //
            //   value:
            //     The value that replaces the destination value if the comparison results in
            //     equality.
            //
            //   comparand:
            //     The value that is compared to the value at location1.
            //
            // Type parameters:
            //   T:
            //     The type to be used for location1, value, and comparand. This type must be
            //     a reference type.
            //
            // Returns:
            //     The original value in location1.
            //
            Interlocked.CompareExchange(ref singleton, tempSingleton, null);

            return singleton;
        }
    }

    //Using Lazy and a much universal solution
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton(), true);

        public static LazySingleton Instance { get {return lazy.Value;} }

        private LazySingleton() { }

        public void UnderHoodLaziness() {
            Console.WriteLine(lazy.Value);
            Console.WriteLine(lazy.IsValueCreated);
            Console.WriteLine(lazy.GetType());
        }
    }
}
