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
           
            try
            {
                string Action = "";
                if (args.Length != 0)
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
                            FileTool.MoveFile(Args[1], Args[2]);
                            break;
                        case "copyfile":
                            FileTool.CopyFile(Args[1], Args[2]);
                            break;
                        case "readfile":
                            FileTool.ReadFile(Args[1]);
                            break;
                        case "deletefile":
                            FileTool.DeleteFile(Args.ToArray());
                            break;
                        case "createfolder":
                            FileTool.CreateFolder(Args[1]);
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
                    Console.WriteLine("檔案處理，第一個參數為指令，後續參數為指定位置檔案或資料夾。");
                    Console.WriteLine("指令：MoveFile  CopyFile    ReadFile    DeleteFile  CreateFolder    DeleteFolder");
                    string[] Args = GetArgs().ToArray();
                    if (Args.Length >= 2)
                    {
                        Action = Args[0].ToLower();
                        switch (Action)
                        {
                            case "movefile":
                                FileTool.MoveFile(Args[1], Args[2]);
                                break;
                            case "copyfile":
                                FileTool.CopyFile(Args[1], Args[2]);
                                break;
                            case "readfile":
                                FileTool.ReadFile(Args[1]);
                                break;
                            case "deletefile":
                                FileTool.DeleteFile(Args);
                                break;
                            case "createfolder":
                                FileTool.CreateFolder(Args[1]);
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
          
            catch (Exception ex)
            {
                Console.WriteLine($"錯誤訊息{ex}，請聯繫開發人員");
                throw;
            }
            Console.Read();
        }
    }
}
