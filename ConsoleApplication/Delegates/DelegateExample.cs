using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Delegates
{
    public class UseDelegates 
    {
        #region Simple Paremeterless delegate
        delegate Stream StreamFactory();

        static MemoryStream GenerateSampleData()
        {
            byte[] buffer = new byte[16];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)i;

            return new MemoryStream(buffer);
        }

        static string TestStringReturn()
        {
            return String.Empty;
        }

        public void ConsumeDelegates()
        {
            //Converts method group with Covariance
            StreamFactory factory = GenerateSampleData;
            using (Stream stream = factory())
            {
                int data;
                while ((data = stream.ReadByte()) != -1)
                    Console.WriteLine(data);
            }
            //factory = TestStringReturn; // Has a wrong written type
        }
        #endregion Simple Paremeterless delegate

        #region Anonymous Delegates

        public void UsingActionDelegateWithAnonymousMethod()
        {
            //Action Delegate
            Action<String> printReverse = delegate(string text)
            {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                Console.WriteLine(new string(chars));
                Console.WriteLine(text.Reverse().FirstOrDefault());
            };

            Action<int> printRoot = delegate(int number) { Console.WriteLine(Math.Sqrt(number)); };

            printReverse("Reverse ME");

            printRoot(20);

            List<int> x = new List<int>() { 1,5,7,9};

            x.ForEach(delegate(int n) { Console.WriteLine(" SQR Root {0}",Math.Sqrt(n)); });
            
        }

        public void UsingPredicateDelegateWithAnonymousMethod()
        { 
            //Predicate Delegate
            Predicate<int> isEven = delegate(int number) { Console.WriteLine(" No is {0}", number); return number % 2 == 0; };

            var IsNoEvent= isEven(7);
            Console.WriteLine(IsNoEvent);

        }
        #endregion Anonymous Delegates
    }

    public static class DelegateExample
    {
        public static void RunExample() 
        {
            var useDelegate = new UseDelegates();
            useDelegate.ConsumeDelegates();
            useDelegate.UsingActionDelegateWithAnonymousMethod();
            useDelegate.UsingPredicateDelegateWithAnonymousMethod();
        }
    }
}
