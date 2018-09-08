using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task2
{
    class Program
    {
        bool x= false;
        void isPhone()
        {
            string pattern = @"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$";
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (Regex.IsMatch(input, pattern))
                {
                    x = true;
                    Console.WriteLine("Input matches regular expression");
                }
                else
                {
                    x = false;
                    Console.WriteLine("Input does not match regular expression");
                }

            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
