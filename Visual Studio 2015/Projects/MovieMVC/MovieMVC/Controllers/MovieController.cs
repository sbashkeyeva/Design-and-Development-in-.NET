using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace MovieMVC.Controllers
{
    public class MovieController : Controller
    {
        
        // GET: Movie
        public ActionResult TopFresh()
        {
            string txt = "";
            string name = "";
            string date = "";
            FileStream fs = new FileStream(@"\\Mac\Home\Downloads\listofmovies.txt",FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            string[] lines = line.Split('\n');
            List<Models.Movie> movies = new List<Models.Movie>();
            foreach (string s in lines)
            {
                movies.Add(new Models.Movie(s));
                foreach (Models.Movie aMov in movies)
                {
                    //string p = "";
                    // p = aMov.ParserToName();
                    string r = aMov.ParserToDate();
                    // Console.WriteLine(r);

                }

                //Console.WriteLine("\t" + s);

            }
            /*for (int i=0;i<lines.Length;i++)
            {
                string[] lines2 = lines[i].Split('|');
                movies.Add(new Models.Movie { Title = lines2[3], Year = lines2[4] });

            }
            var result = movies.OrderBy(n => (n.Year)).Reverse().Take(5).ToList();*/
            // var d = movies.OrderBy(n => (n.Year)).Reverse().Take(5).ToList();
            //var dr = movies.OrderBy(n => (n.Year)).Select(n=>n).ToList();
            //Console.WriteLine(d);
            //foreach (var i in d) Console.WriteLine(i.ParserToDate());
            var d = movies.OrderBy(n => n.ParserToDate()).Reverse().Take(5).ToList();
           
            foreach (var i in d) //Console.WriteLine(i.ParserToDate());
            //var e = movies.OrderBy(x => x.ParserToName()).Reverse().Take(5).ToList();
            //foreach (var i in e) Console.WriteLine(i.ParserToName());
            return View(d);
        }
    }
}