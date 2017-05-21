using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.C_Sharp._6._0
{
    /// <summary>
    /// //Indexers are a syntactic convenience that enable you to create a class, struct, or interface that 
    ///client applications can access just as an array. 
    ///Indexers are most frequently implemented in types whose primary purpose is to 
    ///encapsulate an internal collection or array.
    /// </summary>
    public class Indexers
    {
        private float[] temp = new float[3] { 34.2F, 55.2F, 57.4F };
        private string[] data = new string[3] { "First", "Second", "Third" };

        public int Length
        {
            get 
            {
                return temp.Length;
            }
        }

        ///An indexer value is not classified as a variable; therefore, you cannot pass an indexer value as a ref or out parameter.
        public float this[int index]// Indexer declaration
        {
            get
            {
                return temp[index];
            }
            set
            {
                temp[index] = value;
            }
        }

        public string this[int index, string dummy]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
 
        }

        public static void Execute()
        {
            Indexers indexer = new Indexers();

            indexer[0, "data"] = "Updateddd";

            for(int i=0;i< indexer.Length;i++)
            {
                Console.WriteLine("Int Data {0}", indexer[i]);

                Console.WriteLine("String {0}", indexer[i,string.Empty]);

            }
            Console.WriteLine("Done");
        }

    }
}
