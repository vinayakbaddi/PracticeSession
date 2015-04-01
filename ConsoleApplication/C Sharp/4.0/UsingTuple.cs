using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.C_Sharp._4._0
{
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
