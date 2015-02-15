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
            //List<Tuple> t = new List<Tuple>();
            //t.Add(tupleExample);
            Console.WriteLine("{0} {1}", tupleExample.Item1, tupleExample.Item2);
        }
    }
}
