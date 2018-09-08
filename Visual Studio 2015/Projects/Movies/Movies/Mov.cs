using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Movies
{
    public class Mov
    {
        public Mov()
        {

        }
        string txt = "";
        //string name = "";
        //string date = "";
        
        public Mov(string t)
        {
            this.txt = t;
        }
        public string ParserToName()
        {
            string res = "";
            int position = txt.Length - 8;
            
            while(!(txt[position] >= '0' && txt[position] <= '9'))
            {
                position--;
            }
            position+=3;
            while(position < txt.Length && txt[position] != '(')
            {
                
                res += txt[position];
                position++;

            }
            return res;
            //name = txt;
            
        }
        public string ParserToDate()
        {
            return txt.Substring(txt.Length - 5, 4);
            /*string res = "";
            for(int i=txt.Length-2;i>=txt.Length-5;i--)
            {
                res += txt[i];
            }
            return res;*/
            //date = txt;
        }

    }
}
