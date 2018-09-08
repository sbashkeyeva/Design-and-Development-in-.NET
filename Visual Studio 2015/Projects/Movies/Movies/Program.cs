using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] text = File.ReadAllLines(@"\\Mac\Home\Downloads\listofmovies.txt");
            List<Mov> m = new List<Mov>();
            foreach (string s in text)
            {
                m.Add(new Mov(s));
                foreach(Mov aMov in m)
                {
                    //string p = "";
                    // p = aMov.ParserToName();
                    string r = aMov.ParserToDate();
                    // Console.WriteLine(r);
                    
                }

                //Console.WriteLine("\t" + s);
                
            }
            var d = m.OrderBy(n => n.ParserToDate()).Reverse().Take(5).ToList();
            //Console.WriteLine(d);
            foreach (var i in d) Console.WriteLine(i.ParserToDate());
            var e = m.OrderBy(x=>x.ParserToName()).Reverse().Take(5).ToList();
            foreach (var i in e) Console.WriteLine(i.ParserToName());
            Console.ReadKey();
            //string[] lines = System.IO.File.ReadAllLines(@"\\Mac\Home\Downloads\listofmovies.txt");
            /*IEnumerable<string> top5HighScore = File.ReadLines("highscore.txt")
            .Select(line => int.Parse(line))
            .OrderByDescending(score => score)
            .Take(5)
            .Select((score, index) => string.Format("{0}. {1}pts", index + 1, score));*/
            //string line = File.ReadAllText(@"\\Mac\Home\Downloads\listofmovies.txt");
        }
    }
}
