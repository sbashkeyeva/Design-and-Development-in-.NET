using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace FarManager
{
    class Program
    {

        static void Main(string[] args)
        {
            fun();

        }
        static void fun()
        {
            Console.SetWindowSize(50, 50);
            Console.CursorVisible = false;
            Stack<FileSystemInfo[]> parent = new Stack<FileSystemInfo[]>();
            Stack<int> indexhist = new Stack<int>();
            string[] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] cur = new FileSystemInfo[drives.Length];
            for (int i = 0; i < cur.Length; i++)
                cur[i] = new DirectoryInfo(drives[i]);
            
            int index = 0;
            Show(cur, index);
            string path = "" , pathTo = "", nameFile="";
            ConsoleKeyInfo pressed = Console.ReadKey(true);
            
            while (pressed.Key != ConsoleKey.Escape)
            {
                switch (pressed.Key)
                {
                    case ConsoleKey.C:
                        {
                            try
                            {
                                path = cur[index].FullName;
                                nameFile = cur[index].Name;

                            }
                            catch (IOException error)
                            {
                                Console.WriteLine(error.Message);
                                Console.ReadKey();
                            }
                        }
                        break;
                        
                    
                    case ConsoleKey.V:
                        {
                            int count = 0;
                            //path = cur[index].FullName;
                            //nameFile = cur[index].Name;
                            pathTo = cur[index].FullName;
                            pathTo = pathTo.Substring(0, pathTo.Length - cur[index].Name.Length);
                            pathTo += nameFile;
                            
                               if(path!=pathTo)
                                {
                                    File.Copy(path, pathTo);
                                } 
                               else
                                {
                                    pathTo+="("+count+")";
                                    count++;
                                    File.Copy(path,pathTo);
                                }
                                DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                                cur = dir.GetFileSystemInfos();

                                // FileSystemInfo[] newCur = new FileSystemInfo[cur.Count() + 1];
                                //for (int i = 0; i < newCur.Count() - 1; ++i)
                                //    newCur[i] = cur[i];
                                //newCur[newCur.Count() - 1] = Directory.CreateDirectory(pathTo);
                                //cur = newCur;
                                //Directory.CreateDirectory(pathTo);
                           
                        }
                        break;
                    case ConsoleKey.A:
                        {
                            /*Console.Clear();
                            //path = cur[index].FullName;
                            string fN = Console.ReadLine();
                            string createDirPath= cur[index].FullName;
                            //Console.WriteLine(path + "path bul");
                            createDirPath = createDirPath.Substring(0, createDirPath.Length - cur[index].Name.Length);

                            string dirPath = Path.Combine(path, fN);
                            Directory.CreateDirectory(dirPath);
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();*/
                            Console.Clear();
                            
                            Console.CursorVisible = true;
                            String newDirectory = Console.ReadLine();
                            String pathCreate = cur[index].FullName;
                            pathCreate = pathCreate.Substring(0, pathCreate.Length - cur[index].Name.Length);
                            string pathString = Path.Combine(pathCreate, newDirectory);
                            Directory.CreateDirectory(pathString);
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();


                        }
                        break;
                    case ConsoleKey.N:
                        {
                            /*Console.Clear();
                            string fN = Console.ReadLine();
                            string createDirPath = cur[index].FullName;
                            //Console.WriteLine(path + "path bul");
                            createDirPath = createDirPath.Substring(0, createDirPath.Length - cur[index].Name.Length);

                            string filePath = Path.Combine(path, fN);
                            File.Create(filePath);
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();*/
                            Console.Clear();
                            Console.WriteLine("Write File Name: ");
                            Console.CursorVisible = true;
                            String newFile = Console.ReadLine();
                            String pathCreate = cur[index].FullName;
                            pathCreate = pathCreate.Substring(0, pathCreate.Length - cur[index].Name.Length);
                            string pathString = Path.Combine(pathCreate, newFile);
                            File.Create(pathString);
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();




                        }
                        break;
                    case ConsoleKey.Backspace:
                        {
                            try
                            {
                                path = cur[index].FullName;
                                // Directory.Delete(path);
                                File.Delete(path);
                            }
                            catch
                            {
                                Directory.Delete(path);
                            }
                            
                            if (cur.Length > index + 1)
                                index++;
                            else index = 0;
                            // Console.Clear();
                            for (int i = index-1; i + 1 < cur.Count(); ++i)
                            {
                                cur[i] = cur[i + 1];
                            }
                            FileSystemInfo[] newCur = new FileSystemInfo[cur.Count() - 1];
                            for (int i = 0; i < newCur.Count(); ++i)
                                newCur[i] = cur[i];
                            cur = newCur;
                            //0 1 2  4 5 3
                            //0 1 2  4 5 bez 3 
                            Show(cur, index);
                        }
                        break;
                    case ConsoleKey.O:
                        {
                            path=cur[index].Name.ToString();
                        }
                        break;
                    case ConsoleKey.F5:
                        {
                           
                        }
                        break;
                        case ConsoleKey.I:
                        {
                            try
                            {
                                Bitmap m = new Bitmap(cur[index].FullName);
                                ConsoleWriteImage(m);
                                Console.ReadKey();

                                Console.WriteLine("Graphics in console window!");
                                Point location = new Point(10, 10);
                                Size imageSize = new Size(20, 10);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                        break;

          

                    
                    case ConsoleKey.DownArrow:
                        if (cur.Length > index + 1)
                            index++;
                        else index = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        else index = cur.Length - 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (parent.Count > 0)
                        {
                            index = indexhist.Pop();
                            cur = parent.Pop();
                        }

                        break;

                    case ConsoleKey.RightArrow:
                        if (cur[index] is DirectoryInfo)
                        {
                            try
                            {
                                DirectoryInfo dir = cur[index] as DirectoryInfo;
                                indexhist.Push(index);
                                parent.Push(cur);
                                index = 0;
                                cur = dir.GetFileSystemInfos();

                            }
                            catch (Exception e)
                            {

                            }
                        }
                        else System.Diagnostics.Process.Start(cur[index].FullName);
                        break;

                }
                Show(cur, index);
                pressed = Console.ReadKey(true);
            }

        }
        #region drawing
        static void Draw(string text, ConsoleColor fore, bool nl)
        {
            Console.ForegroundColor = fore;
            Console.Write(text);
            if (nl) Console.WriteLine();
        }
        static void Draw(string text, ConsoleColor fore, ConsoleColor back, bool nl)
        {
            Console.BackgroundColor = back;
            Draw(text, fore, nl);

        }
        #endregion 
        static void Show(FileSystemInfo[] cur, int index)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int ind = 0;
            foreach (FileSystemInfo fsi in cur)
            {
                if (fsi == null) continue;
                Console.BackgroundColor = ConsoleColor.Black;
                if (ind++ == index) Console.BackgroundColor = ConsoleColor.Red;
                String disp = fsi.Name.Length < 20 ? fsi.Name : fsi.Name.Substring(0, 20);
                if (fsi is DirectoryInfo)
                {
                    Draw("[+]", ConsoleColor.Green, false);
                    Draw(disp, ConsoleColor.Gray, true);
                }

                else {

                    Draw(disp, ConsoleColor.White, true);
                }
            }

        }
        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore;  //ForeColor
                                bestHit[1] = cBack;  //BackColor
                                bestHit[2] = rChar;  //Symbol
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = (ConsoleColor)bestHit[0];
            Console.BackgroundColor = (ConsoleColor)bestHit[1];
            Console.Write(rList[bestHit[2] - 1]);
        }



        public static void ConsoleWriteImage(Bitmap source)
        {
            Bitmap bmpMax = new Bitmap(source, 48, 28);
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 48; j++)
                {
                    Console.SetCursorPosition(j + 1, i + 1);
                    ConsoleWritePixel(bmpMax.GetPixel(j, i));
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    

    }
}
