using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    class Program
    {
        class EditDistance
        {
            public int editDistance(string s1, string s2)
            {
                int n = s1.Length;
                int m = s2.Length;
                int[,] arr = new int[n + 1, m + 1];
                for (int i = 0; i < n; arr[i, 0] = i++)
                {

                }
                for (int j = 0; j < m; arr[0, j] = j++)
                {

                }
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        int edit = 2;
                        if (s1[i - 1] == s2[j - 1])
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
                return arr[n, m];
            }
            public int min(int x, int y, int z)
            {
                int o = Math.Min(x, y);
                return Math.Min(o, z);
            }

        }

        static void Main(string[] args)
        {
            string s1 = "intention";
            string s2 = "execution";

            EditDistance ed = new EditDistance();

            int num = ed.editDistance(s1, s2);
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
