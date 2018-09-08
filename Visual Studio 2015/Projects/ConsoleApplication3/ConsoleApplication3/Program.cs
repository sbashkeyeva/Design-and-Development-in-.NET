using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using FileSearch;

namespace ConsoleApplication3
{
    class Program
    {
        public delegate void DisplayFileName(string file);

        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name of Directory");
            string input = Console.ReadLine();
            FileSearch.File fileObj = new FileSearch.File();
            fileObj.sendFileName += sendFileName;

        }
    }
}
