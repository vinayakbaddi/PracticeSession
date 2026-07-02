using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.ASSIGNMENTS.Tu
{

    class BaseballGame
    {
        public int CalPoints(string[] ops)
        {
            if (ops == null || ops.Length == 0)
                return 0;

            Stack<int> stack = new Stack<int>();

            foreach (string op in ops)
            {
                if (int.TryParse(op, out int score))
                {
                    stack.Push(score);
                }
                else if (op == "+")
                {
                    int prev1 = stack.Pop();
                    int prev2 = stack.Peek();
                    int newScore = prev1 + prev2;
                    stack.Push(prev1);
                    stack.Push(newScore);
                }
                else if (op == "D")
                {
                    int prev = stack.Peek();
                    int newScore = 2 * prev;
                    stack.Push(newScore);
                }
                else if (op == "C")
                {
                    stack.Pop();
                }
                else
                {
                    
                    throw new ArgumentException("Invalid operation: " + op);
                }
            }

            int totalScore = 0;
            while (stack.Count > 0)
            {
                totalScore += stack.Pop();
            }

            return totalScore;
        }
    }

    class BaseBall
    {
        public static void run()
        {
            BaseballGame game = new BaseballGame();
            //string[] ops = { "5", "2", "C", "D", "+" };
            string[] ops = { "5", "-2","4", "C", "D","9","+", "+" };
            int totalScore = game.CalPoints(ops);
            Console.WriteLine("Total Score: " + totalScore); // Output: 30
        }
    }
    
}
