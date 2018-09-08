using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace workWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader tr;
            try
            {
                tr = new StreamReader(new FileStream("test.txt", FileMode.Open));
                try
                {
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch (System.UnauthorizedAccessException e)
                {
                    Console.WriteLine("Not available for this user: ");
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("The file can't be read:");
                Console.WriteLine(e.Message);
            }
        }
       
       
    }
}
