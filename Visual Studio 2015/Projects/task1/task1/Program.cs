using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task1
{
    class Program
    {

        static void Main(string[] args)
        {
            Hashtable openWith = new Hashtable();
            ListDictionary list = new ListDictionary();
            HybridDictionary myCol = new HybridDictionary();
            
            openWith.Add("txt","notepad.exe");
            openWith.Add("rtf", "wordpad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("png", "picture.exe");
            foreach(DictionaryEntry entry in openWith)
            {
                Console.WriteLine("Using Hashtable:");
                Console.WriteLine("{0}={1}",entry.Key, entry.Value);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Thread.Sleep(100);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elaspsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Runtime" + elaspsedTime);

            }
            list.Add("Seedless Watermelon", "0.49");
            list.Add("Pineapple", "1.49");
            list.Add("Nectarine", "1.99");
            list.Add("Plums", "1.69");
            list.Add("Peaches", "1.99");
            foreach(DictionaryEntry entry in list)
            {
                Console.WriteLine("using ListDictionary:");
                Console.WriteLine("{0}={1}",entry.Key,entry.Value);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Thread.Sleep(100);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elaspsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Runtime" + elaspsedTime);
            }
            

            myCol.Add("Braeburn Apples", "1.49");
            myCol.Add("Fuji Apples", "1.29");
            myCol.Add("Gala Apples", "1.49");
            myCol.Add("Golden Delicious Apples", "1.29");
            myCol.Add("Granny Smith Apples", "0.89");
            foreach(DictionaryEntry entry in myCol)
            {
                Console.WriteLine("Using HybridDictionary");
                Console.WriteLine("{0}={1}",entry.Key,entry.Value);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Thread.Sleep(100);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elaspsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine("Runtime" + elaspsedTime);
            }
            Console.ReadKey();
        }
        
        void f()
        {
            ArrayList coll = new ArrayList();
            coll.Add(50);
            coll.Add("Shades");
            coll.Add(false);
            coll.Add(21.09);
            string[] messages = new string[] { "more","or","less"};
            coll.AddRange(messages);
            foreach(object o in coll)
            {
                Console.WriteLine(o);
            }
            IEnumerator enumerater = coll.GetEnumerator();
            while(enumerater.MoveNext())
            {
                Console.WriteLine(enumerater.Current);
            }
            for(int i=0;i<coll.Count;i++)
            {
                Console.WriteLine(coll[i]);
            }
        }
        void f2()
        {
            List<string> student = new List<string>();
            student.Add("Symbat");
            student.Add("16BD02111");
            student.Add(Convert.ToString(32));
            foreach (object a in student)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
        void f3()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            emails.Add("sbashkeyeva@gmail.com", "Symbat Bashkeyeva");
            emails.Add("aitakyns@mail.ru", "Aitakyn Saniya");
            emails.Add("bloom@gmail.com", "Bloomy Flower");
            emails["speedyblits@gmail.com"] = "Speedy Blits";
            foreach (KeyValuePair<string, string> kv in emails)
            {
                Console.WriteLine(kv.Key + " " + kv.Value);
            }
        }
    }
}
