using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMVC.Models
{
    public class Movie
    {
        public string Rating { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Movie()
        {

        }
        string txt = "";

        public Movie(string t)
        {
            this.txt = t;
        }
        public string ParserToName()
        {
            string res = "";
            int position = txt.Length - 8;

            while (!(txt[position] >= '0' && txt[position] <= '9'))
            {
                position--;
            }
            position += 3;
            while (position < txt.Length && txt[position] != '(')
            {

                res += txt[position];
                position++;

            }
            return res;

        }
        public string ParserToDate()
        {
            return txt.Substring(txt.Length - 5, 4);
            
        }

    }
}