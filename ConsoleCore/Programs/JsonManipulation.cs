using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCore.Programs
{
    
    public class MyObject
    {
        public string n { get; set; }
    }

    class JsonManipulation
    {
        public static void ex()
        {
            run();
        }
        static void run()
        {
            string jsonString = "FirstText {\"n\":\"NValue 1\"} anytext {\"n\":\"anotherVal\"}";

            // Define a regular expression to match JSON objects
            string pattern = @"\{[^{}]*\}";

            // Find matches in the input string
            MatchCollection matches = Regex.Matches(jsonString, pattern);

            // Iterate through each match and replace the JSON object with the value of 'n'
            foreach (Match match in matches)
            {
                MyObject obj = JsonSerializer.Deserialize<MyObject>(match.Value);
                jsonString = jsonString.Replace(match.Value, obj.n);
            }

            // Output the modified string
            Console.WriteLine(jsonString);
        }
    }
}
