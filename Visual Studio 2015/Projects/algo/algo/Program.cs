using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace algo
{
    class Program
    {
        class EditDistance
        {
            public int editDistance(char[] str1, char[] str2)
            {
                int[,] arr = new int[str1.Length + 1, str2.Length + 1];
                for (int i = 0; i < str1.Length; arr[i, 0] = i++)
                {

                }
                for (int j = 0; j < str2.Length; arr[0, j] = j++)
                {

                }
                for (int i = 1; i <= str1.Length; i++)
                {
                    for (int j = 1; j <= str2.Length; j++)
                    {
                        int edit = 2;
                        if (str1[i - 1] == str2[j - 1])
                        {
                            edit = 1;
                            arr[i, j] = arr[i - 1, j - 1];
                        }
                        else
                        {
                            arr[i, j] = (min(arr[i - 1, j] + 1, arr[i, j - 1] + 1, arr[i - 1, j - 1] + edit));
                        }
                    }
                }
                return arr[str1.Length, str2.Length];
            }
            public int min(int x, int y, int z)
            {
                int o = Math.Min(x, y);
                return Math.Min(o, z);
            }

        }

        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            /*string str1="intention";
            string str2="execution";
            int num = ed.editDistance(str1.ToCharArray(), str2.ToCharArray());
            Console.WriteLine(num); */

            EditDistance ed = new EditDistance();
            StreamReader sr = new StreamReader("words");
            while (!sr.EndOfStream)
            {
                string str2 = sr.ReadLine();
                int num = ed.editDistance(str1.ToCharArray(), str2.ToCharArray());
                if (num <= 1 )
                {
                    Console.WriteLine(str2);
                   
                }
            }
            Console.ReadKey();
        }
    }
}
