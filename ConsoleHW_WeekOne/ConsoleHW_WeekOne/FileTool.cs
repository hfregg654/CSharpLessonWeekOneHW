using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace ConsoleHW_WeekOne
{
    public class FileTool
    {
        public static void MoveFile(string  sourceFile,string destinationFile)
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");
                return;
            }
            else if (File.Exists(destinationFile))
            {
                Console.WriteLine($"{destinationFile} 此路徑已存在相同名稱檔案，是否繼續搬移? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N"| YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在搬移...");
                    DateTime startTime = DateTime.Now;
                    string Newname = Path.GetDirectoryName(destinationFile) + "\\" + Path.GetFileNameWithoutExtension(destinationFile) + "(1)" + Path.GetExtension(destinationFile);
                    File.Move(sourceFile, Newname);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已搬移檔案{Newname}，共花費{ts}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");
            }
            else
            {
                Console.WriteLine($"{destinationFile} 確定將檔案搬入此路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在搬移...");
                    DateTime startTime = DateTime.Now;
                    File.Move(sourceFile, destinationFile);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已搬移檔案{destinationFile}，共花費{ts}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void CopyFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");
                return;
            }
            else if (File.Exists(destinationFile))
            {
                Console.WriteLine($"{destinationFile} 此路徑已存在相同名稱檔案，是否繼續複製? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在複製...");
                    DateTime startTime = DateTime.Now;
                    string Newname = Path.GetDirectoryName(destinationFile) + "\\" + Path.GetFileNameWithoutExtension(destinationFile) + "(1)" + Path.GetExtension(destinationFile);
                    File.Copy(sourceFile, Newname);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已複製檔案{Newname}，共花費{ts}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");
            }
            else
            {
                Console.WriteLine($"{destinationFile} 確定將檔案複製至此路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if(YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在複製...");
                    DateTime startTime = DateTime.Now;
                    File.Copy(sourceFile, destinationFile);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已複製檔案{destinationFile}，共花費{ts}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void ReadFile(string sourceFile)
        {

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");
                return;
            }
            else
            {
                Console.WriteLine($"{sourceFile} 確定讀取此檔案路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在讀取...");
                    DateTime startTime = DateTime.Now;
                    Console.WriteLine("檔案內容：");
                    Console.WriteLine(File.ReadAllText(sourceFile));
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"讀取完成，共花費{ts}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void DeleteFile(string[] sourceFile)
        {
            List<string> NotExists = new List<string>();
            Console.WriteLine($"確定刪除上述檔案路徑? Y/N");
            string YN = Console.ReadLine();
            if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
            {
                Console.WriteLine($"真的確定刪除上述檔案路徑? Y/N");
                 YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在刪除...");
                    DateTime startTime = DateTime.Now;
                    foreach (var item in sourceFile)
                    {
                        if (!File.Exists(item))
                            NotExists.Add(item);
                        else
                            File.Delete(item);
                    }
                    NotExists.RemoveAt(0);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    if (NotExists.ToArray().Length == 0)
                    {
                        Console.WriteLine($"刪除完成，共花費{ts}秒，按ENTER鍵繼續");
                    }
                    else
                    {
                        Console.WriteLine($"刪除完成，部分檔案無法刪除或是不存在，共花費{ts}秒");
                        Console.WriteLine($"無法刪除或不存在的檔案：{string.Join(",",NotExists.ToArray())}");
                    }
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");
            }
        }
        public static void CreateFolder(string path)
        {
            Console.WriteLine($"{path} 確定在此路徑創建資料夾? Y/N");
            string YN = Console.ReadLine();
            if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine($"{path}此路徑已存在相同名稱資料夾，是否繼續創建? Y/N");
                    YN = Console.ReadLine();
                    if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                    {
                        Console.WriteLine("已結束程式，按ENTER鍵繼續");
                        return;
                    }
                    else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                    {
                        Console.WriteLine("正在創建...");
                        DateTime startTime = DateTime.Now;
                        string Newname = path + "(1)";
                        Directory.CreateDirectory(Newname);
                        DateTime endTime = DateTime.Now;
                        TimeSpan ts = endTime - startTime;
                        Console.WriteLine($"已創建路徑資料夾{Newname}，共花費{ts}秒，按ENTER鍵繼續");
                    }
                }
                else
                {
                    Console.WriteLine("正在創建...");
                    DateTime startTime = DateTime.Now;
                    Directory.CreateDirectory(path);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已創建路徑資料夾{path}，共花費{ts}秒，按ENTER鍵繼續");
                }
            }
            else
                Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");



            Directory.CreateDirectory(path);
        }
        public static void DeleteFolder(string[] path)
        {
            List<string> NotExists = new List<string>();
            Console.WriteLine($"確定刪除上述路徑資料夾? Y/N");
            string YN = Console.ReadLine();
            if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
            {
                Console.WriteLine($"真的確定刪除上述路徑資料夾? Y/N");
                YN = Console.ReadLine();
                if (YN.ToUpper() == "N" | YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" | YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在刪除...");
                    DateTime startTime = DateTime.Now;
                    foreach (var item in path)
                    {
                        if (!Directory.Exists(item))
                            NotExists.Add(item);
                        else
                            Directory.Delete(item);
                    }
                    NotExists.RemoveAt(0);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    if (NotExists.ToArray().Length == 0)
                    {
                        Console.WriteLine($"刪除完成，共花費{ts}秒，按ENTER鍵繼續");
                    }
                    else
                    {
                        Console.WriteLine($"刪除完成，部分資料夾無法刪除或是不存在，共花費{ts}秒");
                        Console.WriteLine($"無法刪除或不存在的資料夾：{string.Join(",", NotExists.ToArray())}");
                    }
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");
            }
        }

    }
}
