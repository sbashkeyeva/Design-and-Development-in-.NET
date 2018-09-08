using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"\\Mac\Home\Downloads\listofmovies.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            string[] lines = line.Split('\n');
            List<Movie> movies = new List<Movie>();
            //string[] lines = line.Split(new[] { "\r\n", "\r", "\n" },StringSplitOptions.None);
            for (int i=0;i<lines.Length;i++)
            {
                string[] lines2 = lines[i].Split('|');
                movies.Add(new Movie { Title = lines2[3], Year = lines2[4] });
            }
            
            Console.ReadKey();
            /*foreach (var r in lines)
            {
                //Console.WriteLine(r);
            }*/
            //Console.WriteLine(line);
            
        }
    }
}
