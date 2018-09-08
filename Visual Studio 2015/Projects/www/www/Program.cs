using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace www
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\system.txt");
                sw.WriteLine("I like to read books");
                sw.Close();
                try
                {
                    TextReader tr = new StreamReader(new FileStream("test.txt", FileMode.Open));
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine("The file can't be read:");
                    Console.WriteLine(e.Message);
                }

                
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine("Not available for this user: ");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
