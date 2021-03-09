using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHW_WeekOne
{
    class Program
    {
        static List<string> GetArgs()
        {
            //利用迴圈重複詢問使用者輸入數值，並將數值放入集合，最後傳回集合
            List<string> args = new List<string>();
            string YN = ""; 
            int num = 1;
            do
            {
                Console.WriteLine($"請輸入參數{num}:");
                args.Add(Console.ReadLine());
                num++;
                Console.WriteLine($"是否繼續輸入? Y/N");
                YN=Console.ReadLine().ToUpper();
            } while (YN=="Y" | YN=="YES");
            return args;
        }


        static void Main(string[] args)
        {
           //try,catch
            try
            {
                string Action = "";
                if (args.Length != 0)       //若是外部有傳入數值，將傳入的數值放入集合，再將集合轉為陣列做執行判斷
                {
                    List<string> Args = new List<string>();
                    foreach (var item in args)
                    {
                        Args.Add(item);
                    }
                    Action = Args.ToArray()[0].ToLower();
                    switch (Action)
                    {
                        case "movefile":
                            if (Args.ToArray().Length == 3)         //陣列長度必須符合方法所需要的參數
                            {
                                FileTool.MoveFile(Args[1], Args[2]);
                            }
                            else
                                Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                            break;
                        case "copyfile":
                            if (Args.ToArray().Length == 3)
                            {
                                FileTool.CopyFile(Args[1], Args[2]);
                            }
                            else
                                Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                            break;
                        case "readfile":
                            if (Args.ToArray().Length == 2)
                            {
                                FileTool.ReadFile(Args[1]);
                            }
                            else
                                Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                            break;
                        case "deletefile":
                            FileTool.DeleteFile(Args.ToArray());
                            break;
                        case "createfolder":
                            if (Args.ToArray().Length == 2)
                            {
                                FileTool.CreateFolder(Args[1]);
                            }
                            else
                                Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                    break;
                        case "deletefolder":
                            FileTool.DeleteFolder(Args.ToArray());
                            break;
                        default:
                            Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                            break;
                    }
                }
                else if (args.Length == 0)
                {
                    //若是內部執行則向使用者詢問參數以執行程式
                    Console.WriteLine("檔案處理，第一個參數為指令，後續參數為指定位置檔案或資料夾。");
                    Console.WriteLine("指令：MoveFile  CopyFile    ReadFile    DeleteFile  CreateFolder    DeleteFolder");
                    string[] Args = GetArgs().ToArray();   //呼叫方法並將獲得的集合轉為陣列
                    if (Args.Length != 0)
                    {
                        Action = Args[0].ToLower();
                        switch (Action)
                        {
                            case "movefile":
                                if (Args.Length == 3)                   //陣列長度必須符合方法所需要的參數
                                {
                                    FileTool.MoveFile(Args[1], Args[2]);
                                }
                                else
                                    Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                                break;
                            case "copyfile":
                                if (Args.Length == 3)
                                {
                                    FileTool.CopyFile(Args[1], Args[2]);
                                }
                                else
                                    Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                                break;
                            case "readfile":
                                if (Args.Length == 2)
                                {
                                    FileTool.ReadFile(Args[1]);
                                }
                                else
                                    Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                                break;
                            case "deletefile":
                                FileTool.DeleteFile(Args);
                                break;
                            case "createfolder":
                                if (Args.Length == 2)
                                {
                                    FileTool.CreateFolder(Args[1]);
                                }
                                else
                                    Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                                break;
                            case "deletefolder":
                                FileTool.DeleteFolder(Args);
                                break;
                            default:
                                Console.WriteLine("必須是正確的參數，按ENTER鍵繼續");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("必須有參數或輸入正確的參數，按ENTER鍵繼續");
                    }
                }
                else
                {
                    Console.WriteLine("必須有參數或輸入正確的參數，按ENTER鍵繼續");
                }
            }
                //try,catch 拋出例外狀況
            catch (Exception ex)
            {
                Console.WriteLine($"錯誤訊息{ex}，請聯繫開發人員");
                throw;
            }
            Console.Read();
        }
    }
}
