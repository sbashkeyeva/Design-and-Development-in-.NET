using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "This is a sample sentence.";
            char delimeter = ' ';
            string[] words = s.Split(delimeter);

            /*for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Replace("[^\\w]", "");
            }*/
            string e = " ";
            Array.Sort(words);
            string res = string.Join(e, words);
      
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
