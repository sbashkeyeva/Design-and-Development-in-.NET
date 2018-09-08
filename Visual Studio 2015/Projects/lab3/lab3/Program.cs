using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sWatch = Stopwatch.StartNew();
            
            
            Random rd = new Random();

            for(int i=0;i<100;i++)
            {
                ListDictionary myList = new ListDictionary();
                for(int j=0;j<1000;j++)
                {
                    myList[j] = rd.Next();
                }
                
            }
            sWatch.Stop();
            Console.WriteLine("ListDictionary works at: "+" "+sWatch.Elapsed);
            Stopwatch sWatch1 = Stopwatch.StartNew();
            for (int i=0;i<1000;i++)
            {
                HybridDictionary myHybr = new HybridDictionary();
                for(int j=0;j<1000;j++)
                {
                    myHybr[j] = rd.Next();
                }
                
            }
            sWatch1.Stop();
            Console.WriteLine("HybridDictionary works at: " + sWatch1.Elapsed);
            Stopwatch sWatch2 = Stopwatch.StartNew();
            for (int i=0;i<1000;i++)
            {
                Hashtable myHash = new Hashtable();
                for(int j=0;j<1000;j++)
                {
                    myHash[j] = rd.Next();
                }
            }
            sWatch2.Stop();
            Console.WriteLine("Hashtable works at: " + sWatch2.Elapsed);
            Console.ReadKey();
        }
    }
}
