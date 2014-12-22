using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    public class PrePopFund 
    {
        public int Id;
        public double Percentage { get; set; }
    }

    public static class Logic
    {
        public static void TestBoolConditions()
        {
            bool test = true && false;

            Console.WriteLine("The test for true && false is {0}",test);
            test = true && true;
            Console.WriteLine("The test for true && false is {0}", test);

        }

        public static void TestValues() 
        {
            double[] values1 = { 87.63, 6.18, 6.18 };
            TestRoundingArrayTo100(values1);

            double[] values2 = { 86.63, 6.88, 6.88 };
            TestRoundingArrayTo100(values2);

            double[] values3 = { 86.00, 7, 7};
            TestRoundingArrayTo100(values3);
            
        }

        public static void TestObject() {
            var prePopFundList = new List<PrePopFund>() { 
            new PrePopFund(){
                Id=1,
                Percentage=86.63
            },
            new PrePopFund(){
                Id=2,
                Percentage = 6.18,
            },
            new PrePopFund(){
                Id=3,
                Percentage = 6.18,
            }};


            var prePopFundList2 = new List<PrePopFund>() { 
            new PrePopFund(){
                Id=1,
                Percentage=6.63
            },
            new PrePopFund(){
                Id=2,
                Percentage = 6.63,
            },
            new PrePopFund(){
                Id=3,
                Percentage = 87.38,
            }};



            var prePopFundList3 = new List<PrePopFund>() { 
            new PrePopFund(){
                Id=1,
                Percentage=33.33
            },
            new PrePopFund(){
                Id=2,
                Percentage = 33.33,
            },
            new PrePopFund(){
                Id=3,
                Percentage = 33.33,
            }};

            var prePopFundList4 = new List<PrePopFund>() { 
            new PrePopFund(){
                Id=1,
                Percentage=70.33
            },
            new PrePopFund(){
                Id=2,
                Percentage = 14.84,
            },
            new PrePopFund(){
                Id=3,
                Percentage = 14.84,
            }};

            //TestRoundingArrayTo100(prePopFundList);

            TestRoundingArrayTo100(prePopFundList4);

            //TestRoundingArrayTo100(prePopFundList3);
        }

        public static void TestRoundingArrayTo100(List<PrePopFund> prePopFundList)
        {
            System.Console.WriteLine("MAX " + prePopFundList.Max(x=>x.Percentage));
            System.Console.WriteLine("MAX ID >>> " + prePopFundList.OrderByDescending(x=> x.Percentage).FirstOrDefault().Id);

            var MaxId = prePopFundList.OrderByDescending(x=> x.Percentage).FirstOrDefault().Id;
            Console.WriteLine(prePopFundList.Sum(x=>x.Percentage));
            var difference = prePopFundList.Sum(x => x.Percentage);
            if (difference > 100)
            {



                System.Console.WriteLine("> 100");
                System.Console.WriteLine(prePopFundList.Sum(x => x.Percentage) - 100);
                System.Console.WriteLine(Math.Round((prePopFundList.Sum(x => x.Percentage) - 100), 2));

                var amount =  prePopFundList.Where(x=> x.Id==MaxId).FirstOrDefault().Percentage;
                var deduct = Math.Round((prePopFundList.Sum(x => x.Percentage) - 100), 2);
                prePopFundList.Where(x => x.Id == MaxId).FirstOrDefault().Percentage = amount - deduct;

                System.Console.WriteLine("{0} -  {1} = {2}",amount,deduct,prePopFundList.Where(x => x.Id == MaxId).FirstOrDefault().Percentage);

            }

            else if (difference < 100)
            {
                System.Console.WriteLine("< 100");

                System.Console.WriteLine(100 - prePopFundList.Sum(x => x.Percentage));
                System.Console.WriteLine(Math.Round((100 - prePopFundList.Sum(x => x.Percentage)), 2));
            }
            else
            {
                System.Console.WriteLine("=== 100");
                System.Console.WriteLine(100 - prePopFundList.Sum(x => x.Percentage));
                System.Console.WriteLine(Math.Round((100 - prePopFundList.Sum(x => x.Percentage)), 2));
            }

        }

        public static void TestRoundingArrayTo100(double[] values)
        {
            System.Console.WriteLine("MAX " + values.Max());

            Console.WriteLine(values.Sum());
            var difference = values.Sum();
            if (difference > 100)
            {

                

                System.Console.WriteLine("> 100");
                System.Console.WriteLine(values.Sum() - 100);
                System.Console.WriteLine(Math.Round((values.Sum() - 100), 2));


            }

            else if (difference < 100)
            {
                System.Console.WriteLine("< 100");

                System.Console.WriteLine(100 - values.Sum());
                System.Console.WriteLine(Math.Round((100 - values.Sum()), 2));
            }
            else {
                System.Console.WriteLine("=== 100");
                System.Console.WriteLine(100 - values.Sum());
                System.Console.WriteLine(Math.Round((100 - values.Sum()), 2));
            }

        }

    }
}
