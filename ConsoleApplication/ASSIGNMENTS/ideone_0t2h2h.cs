using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class MerchantProgram
    {
       public static void MerchantMain()
        {
            Console.WriteLine("Welcome to Merchant's Guide to Galaxy.Please enter your query with each word sepated by a space.");
            string inputQuery = Console.ReadLine();
            try
            {
                var operatorObj = new Operator();
                var initializeEngine = new InitializeEngine();

                if (inputQuery != null)
                {
                    var splitInputQuery = inputQuery.ToUpper().Split(' ');

                    var onlyDirtToken = new List<string>();
                    var onlyMetalToken = new List<string>();
                    foreach (var validExpression in splitInputQuery)
                    {
                        if (initializeEngine.GetValidDirts().Contains(validExpression))
                        {
                            onlyDirtToken.Add(validExpression);
                        }
                        if (initializeEngine.GetValidMetals().Contains(validExpression))
                        {
                            onlyMetalToken.Add(validExpression);
                        }
                    }

                    if (onlyDirtToken.Any() || onlyMetalToken.Any())
                    {
                        var onlyDirtValue = operatorObj.GetOnlyDirtValue(onlyDirtToken.ToArray());

                        var onlyMetalsCredit = operatorObj.GetMetalsCredit(onlyMetalToken.ToArray());

                        var dirtMetalCredit = operatorObj.DirtMetalCreditCalculator(inputQuery);

                        if (onlyDirtValue > 0 && onlyMetalsCredit > 0 && dirtMetalCredit > 0)
                        {
                            Console.WriteLine(dirtMetalCredit.ToString(CultureInfo.InvariantCulture));
                            Console.ReadLine();
                        }

                        if (onlyDirtValue > 0)
                        {
                            Console.WriteLine(onlyDirtValue.ToString(CultureInfo.InvariantCulture));
                            Console.ReadLine();
                        }
                        if (onlyMetalsCredit > 0)
                        {
                            Console.WriteLine(onlyMetalsCredit.ToString(CultureInfo.InvariantCulture));
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("I have no idea what you are talking about");
                        Console.ReadLine();
                    }


                }
            }
            catch (Exception)
            {
                Console.WriteLine("I have no idea what you are talking about");
            }
        }
    }
public class Operator :IOperator
    {
        public int GetRomanSymbolValue(char romanSymbol)
        {
            int romanSymbolValue = 0;

            foreach (var valuePair in _initializeEngine.GetValidSymbolValueMapper())
            {
                if (romanSymbol == valuePair.Key)
                {
                    romanSymbolValue = valuePair.Value;
                }
            }
            return romanSymbolValue;
        }

        //how much is pish tegj glob glob
        public int GetOnlyDirtValue(string[] expressionSentence)
        {
            var sum = 0;
            var romanSymolValArry = new int[10];
            int index = 0;
            foreach (var expression in expressionSentence)
            {
                if (_initializeEngine.GetValidDirts().Contains(expression) ||
                    _initializeEngine.GetValidMetals().Contains(expression))
                {
                    if (_initializeEngine.GetDirtSymbolMapper().ContainsKey(expression))
                    {
                        var romanSymbol = _initializeEngine.GetDirtSymbolMapper()[expression];
                        var romanSymbolVal = GetRomanSymbolValue(romanSymbol);
                        if (romanSymbolVal > 0)
                        {
                            romanSymolValArry[index] = romanSymbolVal;
                            index++;
                        }
                    }
                }
            }

            bool counterSelect = false;
            for (int i = 0; i < romanSymolValArry.Length - 1; )
            {
                if (romanSymolValArry[i + 1] > romanSymolValArry[i])
                {
                    sum = romanSymolValArry[i + 1] - romanSymolValArry[i];
                    i++;
                    counterSelect = true;
                }
                else
                {
                    if (counterSelect)
                    {
                        sum = sum + romanSymolValArry[i + 1];
                    }
                    else
                    {
                        sum = sum + romanSymolValArry[i];
                    }
                    counterSelect = false;
                    i++;

                }
            }
            return sum;
        }

        public double GetMetalsCredit(string[] metalNames)
        {
            double metalCreditSum = 0;
            foreach (var metalName in metalNames)
            {
                if (_metalCreditMapper.ContainsKey(metalName))
                {
                    metalCreditSum = metalCreditSum + _metalCreditMapper[metalName];
                }
            }
            return metalCreditSum > Garbagevalue ? metalCreditSum : Garbagevalue;
        }

        public double DirtMetalCreditCalculator(string expressionSentence)
        {
            var validExpressionSentence = expressionSentence.ToUpper().Split(' ');
            var onlyDirtToken = new List<string>();
            var onlyMetalToken = new List<string>();
            foreach (var validExpression in validExpressionSentence)
            {
                if (_initializeEngine.GetValidDirts().Contains(validExpression))
                {
                    onlyDirtToken.Add(validExpression);
                }
                if (_initializeEngine.GetValidMetals().Contains(validExpression))
                {
                    onlyMetalToken.Add(validExpression);
                }
            }
            var dirtCredits = GetOnlyDirtValue(onlyDirtToken.ToArray());
            var metalCredit = GetMetalsCredit(onlyMetalToken.ToArray());
            return dirtCredits * metalCredit;
        }

        public Operator()
        {
            _initializeEngine = new InitializeEngine();
            _metalCreditMapper = _initializeEngine.GetMetalCreditMapper();
        }

        private const int Garbagevalue = 0;
        private readonly InitializeEngine _initializeEngine;
        private Dictionary<string, double> _metalCreditMapper = new Dictionary<string, double>();
    }
interface IOperator
    {
        int GetRomanSymbolValue(char romanSymbol);
        int GetOnlyDirtValue(string[] expressionSentence);
        double GetMetalsCredit(string[] metalNames);
        double DirtMetalCreditCalculator(string expressionSentence);
    }
public class InitializeEngine
    {        
        public List<string> GetValidDirts()
        {
            _dirtDetails.ValidDirt = new List<string> { "GLOB", "PROK", "PISH", "TEGJ" };
            var validDirt = _dirtDetails.ValidDirt;
            return validDirt;
        }

        public Dictionary<string, char> GetDirtSymbolMapper()
        {
            _dirtDetails.DirtSymbolMapper = new Dictionary<string, char>
                                                                          {
                                                                              {"GLOB", 'I'},
                                                                              {"PROK", 'V'},
                                                                              {"PISH", 'X'},
                                                                              {"TEGJ", 'L'},
                                                                              {"ANAND", 'D'},
                                                                              {"AJAY", 'C'}
                                                                          };
            var dirtSymbolMapper = _dirtDetails.DirtSymbolMapper;
            return dirtSymbolMapper;
        }


        public List<string> GetValidMetals()
        {
            _metalDetails.ValidMetal = new List<string> { "GOLD", "SILVER", "IRON" };
            var validDirt = _metalDetails.ValidMetal;
            return validDirt;
        }

        public Dictionary<string, double> GetMetalCreditMapper()
        {
            InitializeMetalValueMapper("glob glob Silver is 34 Credits");
            InitializeMetalValueMapper("glob prok Gold is 57800 Credits");
            InitializeMetalValueMapper("pish pish Iron is 3910 Credits");
            var metalValueMapper = MetalCreditMapper;
            return metalValueMapper;
        }

        public List<char> GetValidSymbol()
        {
            _romanSymbolDetails.ValidSymbol = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            var symbols = _romanSymbolDetails.ValidSymbol;
            return symbols;
        }

        public Dictionary<char, int> GetValidSymbolValueMapper()
        {
            _romanSymbolDetails.ValidSymbolValueMapper = new Dictionary<char, int>
                                                             {
                                                                 {'I', 1},
                                                                 {'V', 5},
                                                                 {'X', 10},
                                                                 {'L', 50},
                                                                 {'C', 100},
                                                                 {'D', 500},
                                                                 {'M', 1000}
                                                             };
            var romanValueMapper = _romanSymbolDetails.ValidSymbolValueMapper;
            return romanValueMapper;

        }
        public Dictionary<string, double> MetalCreditMapper = new Dictionary<string, double>();

        public Dictionary<string, double> InitializeMetalValueMapper(string expressionSentence)
        {
            var expressionArray = expressionSentence.ToUpper().Split(' ');
            var sum = 0;
            var romanSymolValArry = new int[10];
            var symbolArry = new string[10];
            var index = 0;
            var metalCredit = string.Empty;
            var metal = string.Empty;
            var grossCreditvalue = 0;
            foreach (var expression in expressionArray)
            {
                if (GetValidDirts().Contains(expression))
                {
                    if (GetDirtSymbolMapper().ContainsKey(expression))
                    {
                        var romanSymbol = GetDirtSymbolMapper()[expression];
                        var romanSymbolVal = GetValidSymbolValueMapper()[romanSymbol];
                        if (romanSymbolVal > 0)
                        {
                            romanSymolValArry[index] = romanSymbolVal;
                            symbolArry[index] = romanSymbol.ToString(CultureInfo.InvariantCulture);
                            index++;
                        }
                    }
                }
                if (GetValidMetals().Contains(expression))
                {
                    metal = expression;
                }
                if (GetValidCredits().Contains(expression))
                {
                    metalCredit = expression;
                }
            }
            bool counterSelect = false;
            for (int i = 0; i < romanSymolValArry.Length - 1; )
            {
                if (romanSymolValArry[i + 1] > romanSymolValArry[i])
                {
                    sum = romanSymolValArry[i + 1] - romanSymolValArry[i];
                    i++;
                    counterSelect = true;
                }
                else
                {
                    if (counterSelect)
                    {
                        sum = sum + romanSymolValArry[i + 1];
                    }
                    else
                    {
                        sum = sum + romanSymolValArry[i];
                    }
                    counterSelect = false;
                    i++;

                }
            }
            double actualCreditValue = 0;
            int.TryParse(metalCredit, out grossCreditvalue);
            if (sum > 0)
            {
                actualCreditValue = (double)grossCreditvalue / sum;
            }

            MetalCreditMapper.Add(metal, actualCreditValue);
            return MetalCreditMapper;

        }

        public List<string> GetValidCredits()
        {
            _baseCredits.ValidCredits = new List<String> { "34", "57800", "3910" };
            var baseCredits = _baseCredits.ValidCredits;
            return baseCredits;
        }

        public InitializeEngine()
        {
            _dirtDetails = new DirtDetails();
            _metalDetails = new MetalDetails();
            _romanSymbolDetails = new RomanSymbolDetails();
            _baseCredits = new BaseCredits();
        }

        private readonly DirtDetails _dirtDetails;
        private readonly MetalDetails _metalDetails;
        private readonly RomanSymbolDetails _romanSymbolDetails;
        private readonly BaseCredits _baseCredits;
    }    
public class DirtDetails
{
    public List<string> ValidDirt { get; set; }
    public Dictionary<string,char> DirtSymbolMapper { get; set; }
    public Dictionary<string, int> DirtValueMapper { get; set; }
}
public class MetalDetails
{
    public List<string> ValidMetal { get; set; }
    public Dictionary<string, double> MetalCreditMapper { get; set; }

}
public class RomanSymbolDetails
{
   public List<char> ValidSymbol  { get; set; }

   public Dictionary<char,int> ValidSymbolValueMapper { get; set; }
}
public class BaseCredits
{
   public List<string> ValidCredits  { get; set; }
}