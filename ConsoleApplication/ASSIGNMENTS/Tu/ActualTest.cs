using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.ASSIGNMENTS.Tu
{
    public class ActualTest
    {
        public static void run()
        {
            ex3();
            Console.Read();
        }

        static void ex3()
        {
            string k = "abcdddeeeeaabbbcd";
            IList<IList<int>> validSubstrings = ValidSubstringsT(k);

            foreach (var pair in validSubstrings)
            {
                Console.WriteLine($"[{pair[0]}, {pair[1]}]");
            }
        }
        public static IList<IList<int>> ValidSubstringsT(string k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int start = 0;
            int end = 0;
            int n = k.Length;

            while (end < n)
            {
                int count = 1;
                while (end + 1 < n && k[end] == k[end + 1])
                {
                    end++;
                    count++;
                }

                if (count >= 3)
                {
                    result.Add(new List<int>() { start, end });
                }

                end++;
                start = end;
            }

            return result;
        }
        static void ex()
        {
            string input = "abcdddeeeeaabbbcd";
            List<int[]> validSubstrings = FindValidSubstrings(input);

            Console.WriteLine("Valid substrings:");
            foreach (int[] indices in validSubstrings)
            {
                Console.WriteLine("[" + indices[0] + ", " + indices[1] + "]");
            }
        }


        static void ex2()
        {
            string input = "abcdddeeeeaabbbcd";
            List<Tuple<int, int>> validSubstrings = FindValidSubstringsVec(input);

            foreach (var tuple in validSubstrings)
            {
                Console.WriteLine("[" + tuple.Item1 + ", " + tuple.Item2 + "]");
            }

        }
        static List<int[]> FindValidSubstrings(string k)
        {
            List<int[]> validSubstrings = new List<int[]>();
            int count = 1;

            for (int i = 1; i < k.Length; i++)
            {
                if (k[i] == k[i - 1])
                {
                    count++;
                    if (i == k.Length - 1 && count >= 3)
                    {
                        int startIndex = i - count + 1;
                        validSubstrings.Add(new int[] { startIndex, i });
                    }
                }
                else
                {
                    if (count >= 3)
                    {
                        int startIndex = i - count;
                        validSubstrings.Add(new int[] { startIndex, i - 1 });
                    }
                    count = 1;
                }
            }

            return validSubstrings;
        }


        public static List<Tuple<int, int>> FindValidSubstringsVec(string k)
        {
            List<Tuple<int, int>> validSubstrings = new List<Tuple<int, int>>();
            int start = 0;
            int end = 0;

            while (end < k.Length)
            {
                if (k[start] == k[end])
                {
                    end++;
                    if (end - start >= 3)
                    {
                        validSubstrings.Add(new Tuple<int, int>(start, end - 1));
                    }
                }
                else
                {
                    start = end;
                }
            }

            return validSubstrings;
        }

    }


}
