using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            far();
        }
        static void far()
        {
            //for(int i = 0;i < )
            Console.CursorVisible = false;
            Stack<FileSystemInfo[]> parent = new Stack<FileSystemInfo[]>();
            Stack<int> indexhist = new Stack<int>();
            string[] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] cur = new FileSystemInfo[drives.Length];
            for (int i = 0; i < cur.Length; i++)
                cur[i] = new DirectoryInfo(drives[i]);
            int index = 0;
            Show(cur, index);
            String moveString = "", moveName = "", moveStringTo = "", copyName = "", copyString = "", copyStringTo = "";
            int k = 1;
            ConsoleKeyInfo pressed = Console.ReadKey(true);
            while (pressed.Key != ConsoleKey.Escape)
            {
                switch (pressed.Key)
                {
                    case ConsoleKey.F2:
                        {
                            String pathString = cur[index].FullName;
                            pathString = pathString.Substring(0, pathString.Length - cur[index].Name.Length);
                            Console.Clear();
                            Console.WriteLine("Write the new File or Directory name");
                            string newName = Console.ReadLine();
                            try
                            {
                                Directory.Move(cur[index].FullName, pathString + newName);
                            }
                            catch
                            {
                                File.Move(cur[index].FullName, pathString + newName);
                            }
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();
                        }
                        break;
                    case ConsoleKey.F4:
                        {
                            Console.Clear();
                            Console.WriteLine("Write Directory Name: ");
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
                    case ConsoleKey.F5:
                        {
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
                    case ConsoleKey.M:
                        {
                            moveString = cur[index].FullName;
                            moveName = cur[index].Name;
                        }
                        break;
                    case ConsoleKey.T:
                        if (moveString.Length != 0)
                        {
                            moveStringTo = cur[index].FullName;
                            moveStringTo = moveStringTo.Substring(0, moveStringTo.Length - cur[index].Name.Length);
                            moveStringTo += moveName;
                            try
                            {
                                Directory.Move(moveString, moveStringTo);
                            }
                            catch
                            {
                                File.Move(moveString, moveStringTo);
                            }
                            moveString = "";
                            moveStringTo = "";
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();
                        }
                        break;
                    case ConsoleKey.C:
                        {
                            copyName = cur[index].Name;
                            copyString = cur[index].FullName;
                        }
                        break;
                    case ConsoleKey.V:
                        {
                            copyStringTo = cur[index].FullName;
                            copyStringTo = copyStringTo.Substring(0, copyStringTo.Length - cur[index].Name.Length);
                            copyStringTo += copyName;
                            if (copyString != copyStringTo)
                            {
                                File.Copy(copyString, copyStringTo);
                            }
                            else
                            {
                                copyStringTo += " (" + k + ")";
                                k++;
                                File.Copy(copyString, copyStringTo);
                            }
                            //Show(cur, index);
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();
                        }
                        break;
                    case ConsoleKey.Delete:
                        {
                            try
                            {
                                File.Delete(cur[index].FullName);
                            }
                            catch
                            {
                                Directory.Delete(cur[index].FullName);
                            }
                            DirectoryInfo dir = parent.First()[indexhist.First()] as DirectoryInfo;
                            cur = dir.GetFileSystemInfos();
                            //File.Delete(cur[index].FullName) || Directory.Delete(cur[index].FullName);
                            k = 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cur.Length > index + 1)
                            index++;
                        else index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            index--;
                        }
                        else index = cur.Length - 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (parent.Count > 0)
                        {
                            index = indexhist.Pop();
                            cur = parent.Pop();
                        }
                        break;
                    case ConsoleKey.O:
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
                    case ConsoleKey.RightArrow:
                        if (cur[index] is DirectoryInfo)
                        {
                            try
                            {
                                DirectoryInfo dire = cur[index] as DirectoryInfo;
                                indexhist.Push(index);
                                parent.Push(cur);
                                index = 0;
                                cur = dire.GetFileSystemInfos();
                            }
                            catch (Exception e)
                            {
                            }
                        }
                        else Process.Start(cur[index].FullName);
                        break;
                    case ConsoleKey.Enter:
                        Process.Start(cur[index].FullName);
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
                Console.BackgroundColor = ConsoleColor.Black;
                String disp = fsi.Name.Length < 20 ? fsi.Name : fsi.Name.Substring(0, 20);
                string s = "";
                for (int i = 0; i < disp.Length + 3; i++)
                {
                    s += " ";
                }
                if (ind++ == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                if (fsi is DirectoryInfo)
                {
                    Draw("[+]", ConsoleColor.Green, false);
                    Draw(disp, ConsoleColor.Gray, true);
                }
                else
                {
                    Draw(disp, ConsoleColor.White, true);
                }
                if (Console.BackgroundColor == ConsoleColor.Red)
                {
                    Console.WriteLine(s + "> Path: " + fsi.FullName);
                    Console.WriteLine(s + "> Modified Time: " + fsi.LastWriteTime.ToString());
                    Console.WriteLine(s + "> Creation Time: " + fsi.CreationTime.ToString());
                }
            }
        }
        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };
        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 };
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue };
            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - 😎 *(cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000))
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore;
                                bestHit[0] = cFore;
                                bestHit[1] = cBack;
                                bestHit[2] = rChar;
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