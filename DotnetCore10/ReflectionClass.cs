using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DotnetCore10
{
    // Demonstrates basic reflection usage and simple marshalling between
    // managed and unmanaged memory using System.Runtime.InteropServices.Marshal.
    public class ReflectionClass
    {
        // Public entry that other code (e.g., Program.Main) can call to run the demo.
        public static void RunDemo()
        {
            Console.WriteLine("--- Reflection demo ---");
            ReflectionExample();

            Console.WriteLine();
            Console.WriteLine("--- Marshalling demo ---");
            MarshallingExample();
        }

        // Example of using reflection to inspect types, create instances and invoke members.
        private static void ReflectionExample()
        {
            var personType = typeof(Person);
            Console.WriteLine($"Type: {personType.FullName}");

            Console.WriteLine("Properties:");
            foreach (var prop in personType.GetProperties())
            {
                Console.WriteLine($" - {prop.PropertyType.Name} {prop.Name}");
            }

            Console.WriteLine("Constructors:");
            foreach (var ctor in personType.GetConstructors())
            {
                Console.WriteLine($" - {ctor}");
            }

            // Create instance via Activator and set property values via reflection
            var person = Activator.CreateInstance(personType);
            var nameProp = personType.GetProperty("Name");
            var ageProp = personType.GetProperty("Age");
            nameProp.SetValue(person, "Reflective Alice");
            ageProp.SetValue(person, 28);

            // Invoke method via reflection
            var greetMethod = personType.GetMethod("Greet");
            var result = greetMethod.Invoke(person, new object[] { "Hello" });
            Console.WriteLine($"Greet returned: {result}");

            Console.WriteLine($"Person via reflection: Name={nameProp.GetValue(person)}, Age={ageProp.GetValue(person)}");
        }

        // Simple marshalling example: marshal a managed struct to unmanaged memory and back.
        private static void MarshallingExample()
        {
            var emp = new EmployeeUnmanaged { Id = 42, Name = "Bob Marshall", Salary = 12345.67 };

            int size = Marshal.SizeOf<EmployeeUnmanaged>();
            Console.WriteLine($"Size of EmployeeUnmanaged: {size} bytes");

            // Allocate unmanaged memory, copy struct to it, read it back, then free
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(emp, ptr, false);

                // Read back from unmanaged memory into managed struct
                var empCopy = Marshal.PtrToStructure<EmployeeUnmanaged>(ptr);
                Console.WriteLine($"Unmanaged -> Managed: Id={empCopy.Id}, Name={empCopy.Name}, Salary={empCopy.Salary}");
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            // Demonstrate marshalling a single string
            string original = "Some unmanaged string";
            IntPtr sPtr = Marshal.StringToHGlobalAnsi(original);
            try
            {
                string roundTrip = Marshal.PtrToStringAnsi(sPtr);
                Console.WriteLine($"String round-trip via unmanaged memory: {roundTrip}");
            }
            finally
            {
                Marshal.FreeHGlobal(sPtr);
            }
        }

        // A simple class used for reflection examples
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person() { }

            public string Greet(string prefix)
            {
                return $"{prefix}, my name is {Name} and I am {Age} years old.";
            }
        }

        // Struct layout must be sequential for predictable marshalling
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct EmployeeUnmanaged
        {
            public int Id;

            // Fixed-length ANSI string in the unmanaged representation
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string Name;

            public double Salary;
        }
    }
}
