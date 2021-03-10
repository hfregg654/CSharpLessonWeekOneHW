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
        //所有方法若遇到任何參數上的錯誤都輸出"未輸入正確指令，已結束程式，按ENTER鍵繼續"並等待程式結束
        public static void MoveFile(string  sourceFile,string destinationFile)              //搬移檔案，先檢查檔案存在與否，再檢查目標地是否有同名檔案
        {
            if (!File.Exists(sourceFile))                                                   //若目標地有同名檔案且使用者執意執行則將搬移的檔案改名後搬移
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");         //並在開始搬移前後紀錄時間最後做程式執行的時間
                return;
            }
            else if (File.Exists(destinationFile))
            {
                Console.WriteLine($"{destinationFile} 此路徑已存在相同名稱檔案，是否繼續搬移? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N"|| YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在搬移...");
                    DateTime startTime = DateTime.Now;
                    string Newname = Path.GetDirectoryName(destinationFile) + "\\" + Path.GetFileNameWithoutExtension(destinationFile) + "(1)" + Path.GetExtension(destinationFile);
                    if (File.Exists(Newname))
                    {
                        do
                        {
                            Newname = Path.GetDirectoryName(Newname) + "\\" + Path.GetFileNameWithoutExtension(Newname) + "(1)" + Path.GetExtension(Newname);
                        } while (File.Exists(Newname));
                    }
                    File.Move(sourceFile, Newname);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已搬移檔案至{Newname}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");
            }
            else
            {
                Console.WriteLine($"{destinationFile} 確定將檔案搬入此路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在搬移...");
                    DateTime startTime = DateTime.Now;
                    File.Move(sourceFile, destinationFile);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已搬移檔案至{destinationFile}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void CopyFile(string sourceFile, string destinationFile)              //複製檔案，先檢查檔案存在與否，再檢查目標地是否有同名檔案            
        {
            if (!File.Exists(sourceFile))                                                   //若目標地有同名檔案則詢問是否覆蓋，若選擇覆蓋照常執行
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");         //若不覆蓋且使用者執意執行則將檔案改名後複製
                return;
            }                                                                               //並在開始複製前後紀錄時間最後做程式執行的時間
            else if (File.Exists(destinationFile))                                         
            {
                Console.WriteLine($"{destinationFile} 此路徑已存在相同名稱檔案，是否繼續複製? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    Console.WriteLine($"{destinationFile} 希望覆寫此路徑相同名稱的檔案嗎? Y/N");
                    YN = Console.ReadLine();
                    if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                    {
                        Console.WriteLine("正在複製...");
                        DateTime startTime = DateTime.Now;
                        string Newname = Path.GetDirectoryName(destinationFile) + "\\" + Path.GetFileNameWithoutExtension(destinationFile) + "(1)" + Path.GetExtension(destinationFile);
                        if (File.Exists(Newname))
                        {
                            do
                            {
                                Newname = Path.GetDirectoryName(Newname) + "\\" + Path.GetFileNameWithoutExtension(Newname) + "(1)" + Path.GetExtension(Newname);
                            } while (File.Exists(Newname));
                        }
                        File.Copy(sourceFile, Newname);
                        DateTime endTime = DateTime.Now;
                        TimeSpan ts = endTime - startTime;
                        Console.WriteLine($"已複製檔案至{Newname}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                    }
                    else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                    {
                        Console.WriteLine("正在複製...");
                        DateTime startTime = DateTime.Now;
                        File.Copy(sourceFile, destinationFile,true);
                        DateTime endTime = DateTime.Now;
                        TimeSpan ts = endTime - startTime;
                        Console.WriteLine($"已複製檔案至{destinationFile}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                    }
                    else
                        Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸正確入指令，已結束程式，按ENTER鍵繼續");
            }
            else
            {
                Console.WriteLine($"{destinationFile} 確定將檔案複製至此路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if(YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在複製...");
                    DateTime startTime = DateTime.Now;
                    File.Copy(sourceFile, destinationFile);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已複製檔案至{destinationFile}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void ReadFile(string sourceFile)                                      //讀取檔案，先檢查檔案存在與否
        {
            if (!File.Exists(sourceFile))                                                   //並在開始讀取前後紀錄時間最後做程式執行的時間
            {
                Console.WriteLine($"{sourceFile} 此路徑檔案不存在，按ENTER鍵繼續");
                return;
            }
            else
            {
                Console.WriteLine($"{sourceFile} 確定讀取此檔案路徑? Y/N");
                string YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    Console.WriteLine("正在讀取...");
                    DateTime startTime = DateTime.Now;
                    Console.WriteLine("檔案內容：");
                    Console.WriteLine(File.ReadAllText(sourceFile));
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"讀取完成，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");

            }
        }
        public static void DeleteFile(string[] sourceFile)                                  //刪除檔案，先檢查檔案存在與否，並向使用者做二次確認
        {
            List<string> NotExists = new List<string>();                                    //另外創建一個集合收集無法辨認的檔案位置，並在最後做輸出
            Console.WriteLine($"確定刪除上述檔案路徑? Y/N");
            string YN = Console.ReadLine();                                                 //並在開始刪除前後紀錄時間最後做程式執行的時間
            if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
            {
                Console.WriteLine($"真的確定刪除上述檔案路徑? Y/N");
                 YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
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
                        Console.WriteLine($"刪除完成，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                    }
                    else
                    {
                        Console.WriteLine($"刪除完成，部分檔案無法刪除或是不存在，共花費{ts}秒");
                        Console.WriteLine($"無法刪除或不存在的檔案：{string.Join(",",NotExists.ToArray())}，按ENTER鍵繼續");
                    }
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");
            }
        }
        public static void CreateFolder(string path)                                        //創建資料夾，向使用者確認執行後檢查目標地是否有同名資料夾
        {
            Console.WriteLine($"{path} 確定在此路徑創建資料夾? Y/N");                       //若目標地有同名資料夾且使用者執意執行則將檔案改名後創建
            string YN = Console.ReadLine();
            if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")                                //並在開始創建前後紀錄時間最後做程式執行的時間
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine($"{path}此路徑已存在相同名稱資料夾，是否繼續創建? Y/N");
                    YN = Console.ReadLine();
                    if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                    {
                        Console.WriteLine("已結束程式，按ENTER鍵繼續");
                        return;
                    }
                    else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                    {
                        Console.WriteLine("正在創建...");
                        DateTime startTime = DateTime.Now;
                        string Newname = path + "(1)";
                        if (Directory.Exists(Newname))
                        {
                            do
                            {
                                Newname = Newname + "(1)";
                            } while (Directory.Exists(Newname));
                        }
                        Directory.CreateDirectory(Newname);
                        DateTime endTime = DateTime.Now;
                        TimeSpan ts = endTime - startTime;
                        Console.WriteLine($"已創建路徑資料夾{Newname}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                    }
                }
                else
                {
                    Console.WriteLine("正在創建...");
                    DateTime startTime = DateTime.Now;
                    Directory.CreateDirectory(path);
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts = endTime - startTime;
                    Console.WriteLine($"已創建路徑資料夾{path}，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                }
            }
            else
                Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");
        }
        public static void DeleteFolder(string[] path)                                      //刪除資料夾，先檢查檔案存在與否，並向使用者做二次確認
        {
            List<string> NotExists = new List<string>();                                    //另外創建一個集合收集無法辨認的檔案位置，並在最後做輸出
            TimeSpan ts = new TimeSpan();                                                   
            Console.WriteLine($"確定刪除上述路徑資料夾? Y/N");                              //創建一個時間單位儲存每個處理經過的時間，每次處理後輸出並在最後輸出總時間
            string YN = Console.ReadLine();                                                 
            if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
            {
                Console.WriteLine("已結束程式，按ENTER鍵繼續");
                return;
            }
            else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
            {
                Console.WriteLine($"真的確定刪除上述路徑資料夾? Y/N");
                YN = Console.ReadLine();
                if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                {
                    Console.WriteLine("已結束程式，按ENTER鍵繼續");
                    return;
                }
                else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                {
                    foreach (var item in path)
                    {
                        if (!Directory.Exists(item))
                            NotExists.Add(item);
                        else
                        {
                            List<string> AllFolder = new List<string>();
                            foreach (string f in Directory.GetFileSystemEntries(item))
                            {
                                AllFolder.Add(f);
                            }
                            if (AllFolder.ToArray().Length != 0)
                            {
                                if (File.Exists(AllFolder.ToArray()[0]) || Directory.Exists(AllFolder.ToArray()[0]))
                                {
                                    Console.WriteLine($"偵測到{item}路徑資料夾內有其他檔案，是否繼續刪除? Y/N");
                                    YN = Console.ReadLine();
                                    if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                                    {
                                        Console.WriteLine("進入下一個資料夾");
                                        continue;
                                    }
                                    else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                                    {
                                        Console.WriteLine($"真的確定刪除{item}路徑資料夾內所有檔案? Y/N");
                                        YN = Console.ReadLine();
                                        if (YN.ToUpper() == "N" || YN.ToUpper() == "NO")
                                        {
                                            Console.WriteLine("進入下一個資料夾");
                                            continue;
                                        }
                                        else if (YN.ToUpper() == "Y" || YN.ToUpper() == "YES")
                                        {
                                            Console.WriteLine("正在刪除...");
                                            DateTime startTime = DateTime.Now;
                                            foreach (string iteminfolder in AllFolder)
                                            {
                                                if (File.Exists(iteminfolder))
                                                {
                                                    File.Delete(iteminfolder);
                                                }
                                                else
                                                {
                                                    //迴圈遞迴刪除子資料夾 
                                                    DeleteSrcFolder(iteminfolder);
                                                }
                                            }
                                            DateTime endTime = DateTime.Now;
                                            ts += endTime - startTime;
                                            Console.WriteLine($"已刪除{item}花費{ts.TotalSeconds}秒");
                                        }
                                        Directory.Delete(item);
                                    }
                                }
                            }
                            else
                            {
                                DateTime startTime = DateTime.Now;
                                Directory.Delete(item);
                                DateTime endTime = DateTime.Now;
                                ts += endTime - startTime;
                                Console.WriteLine($"已刪除{item}花費{ts.TotalSeconds}秒");
                            }
                        }
                    }
                    NotExists.RemoveAt(0);
                    if (NotExists.ToArray().Length == 0)
                    {
                        Console.WriteLine($"刪除完成，共花費{ts.TotalSeconds}秒，按ENTER鍵繼續");
                    }
                    else
                    {
                        Console.WriteLine($"刪除完成，部分資料夾無法刪除或是不存在，共花費{ts}秒");
                        Console.WriteLine($"無法刪除或不存在的資料夾：{string.Join(",", NotExists.ToArray())}，按ENTER鍵繼續");
                    }
                }
                else
                    Console.WriteLine("未輸入正確指令，已結束程式，按ENTER鍵繼續");
            }
        }
        public static void DeleteSrcFolder(string file)
        {
            //去除資料夾和子檔案的只讀屬性
            //去除資料夾的只讀屬性
            System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
            fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
            //去除檔案的只讀屬性
            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
            //判斷資料夾是否還存在
            if (Directory.Exists(file))
            {
                foreach (string f in Directory.GetFileSystemEntries(file))
                {
                    if (File.Exists(f))
                    {
                        //如果有子檔案刪除檔案
                        File.Delete(f);
                    }
                    else
                    {
                        //迴圈遞迴刪除子資料夾 
                        DeleteSrcFolder(f);
                    }
                }
                //刪除空資料夾
                Directory.Delete(file);
            }
        }
    }


}
