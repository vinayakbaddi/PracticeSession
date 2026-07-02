
namespace ConsoleCore.Programs
{
    public class AllPrograms
    {
        public Fibonacci fib { get; set; } = new Fibonacci();
        public static void execute()
        {
            fibonacci();
        }

        private static void fibonacci()
        {
            Fibonacci.test();
            //Fibonacci.FibonacciSeries(10);
            //Console.WriteLine( new Fibonacci().CalculateFibonacci(3));
        }
    }

    public class Fibonacci
    {
        private Dictionary<int, long> memo = new Dictionary<int, long>();

        public long CalculateFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be non-negative.");

            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (memo.ContainsKey(n))
                return memo[n];

            long result = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
            memo[n] = result;
            return result;
        }

        public static void test()
        {
            Console.Write("Please enter the Nth number of the Fibonacci Series : ");
            int NthNumber = 10;
            //Decrement the Nth Number by 1. This is because the series starts with 0
            //NthNumber = NthNumber - 1;
            FibonacciSeries(0,1,1,10);
            Console.WriteLine();
            FibonacciSeries(0,1,3,10);

            Console.ReadKey();
        }
        public static void FibonacciSeries(int firstNumber, int secondNumber, int counter, int number)
        {
            Console.Write(firstNumber + " ");
            if (counter < number)
            {
                FibonacciSeries(secondNumber, firstNumber + secondNumber, counter + 1, number);
            }
        }

        //public static void FibonacciSeries(int firstNumber, int secondNumber,  int number)
        //{
        //    Console.Write(firstNumber + " ");
        //    if (counter < number)
        //    {
        //        FibonacciSeries(secondNumber, firstNumber + secondNumber, counter + 1, number);
        //    }
        //}

        public static void FibonacciSeries( int number)
        {
            int first = 0;
            int second = 1;
            if ((first + second) > number)
            {
                Console.WriteLine(second + " ");
            }
            else
                Console.WriteLine( Fibo(first,second, number));
        }

        private static int Fibo(int first, int second, int number)
        {
            if ((first + second) > number)
                return second;


            return Fibo(second, second + first, number);
        }
    }

}
