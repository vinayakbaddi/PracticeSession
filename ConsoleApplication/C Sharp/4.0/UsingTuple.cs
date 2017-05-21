using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.C_Sharp._4._0
{
    /// <summary>
    /// A tuple is a data structure that has a specific number and sequence of elements. 
    /// An example of a tuple is a data structure with three elements (known as a 3-tuple or triple) 
    /// that is used to store an identifier such as a person's name in the first element, 
    /// a year in the second element, and the person's income for that year in the third element. 
    /// The .NET Framework directly supports tuples with one to seven elements. 
    /// In addition, you can create tuples of eight or more elements by nesting tuple objects in the 
    /// Rest property of a Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> object.
    /// https://msdn.microsoft.com/en-us/library/system.tuple(v=vs.110).aspx
    /// </summary>
    public class UsingTuple
    {


        public static void ExecuteTuples()
        {
            Tuple<int, string> tupleExample = new Tuple<int, string>(
            1,
            "Some data"
        );
            Tuple<int, string, string, object> tupleExample2 = new Tuple<int, string, string, object>(1,"Da","d","d"
        );
            //List<Tuple> t = new List<Tuple>(); //Error	2	'System.Tuple': static types cannot be used as type arguments	C:\Users\vinayak\Source\Repos\PracticeSession\ConsoleApplication\C Sharp\4.0\UsingTuple.cs	19	48	ConsoleApplication

            //t.Add(tupleExample);

            Console.WriteLine("{0} {1}", tupleExample.Item1, tupleExample.Item2);
            Console.WriteLine("{0} {1}", tupleExample2.Item4, tupleExample2.Item3);

        }
    }
}
