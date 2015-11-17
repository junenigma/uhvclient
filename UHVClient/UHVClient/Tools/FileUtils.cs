using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace UHVClient
{
    static class FileUtils
    {
        /// <summary> 
        /// 递归列举出指定目录的所有文件         /// </summary> 
        public static void ListFiles(FileSystemInfo info, string _rex)
        {
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;                 //不是目录 
            if (dir == null) return;
            string _filePath = string.Empty;
            Dictionary<DateTime, string> _fs = new Dictionary<DateTime, string>();
            FileSystemInfo[] files = dir.GetFileSystemInfos(_rex + "_*.rar");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo f = files[i] as FileInfo;                     //是文件 
                if (f != null)
                {
                    //string _fn = f.Name;
                    //Regex r = new Regex("epis_.*_");
                    //string _t = r.Replace(_fn, "").Replace(".rar", "");

                    DateTime _dt = f.CreationTimeUtc;
                    _fs.Add(_dt, f.FullName);
                }
            }
            Dictionary<DateTime, string> dic1 = _fs.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            _filePath = dic1[dic1.Keys.Max()];
            FileInfo file = new FileInfo(_filePath);
            if (file != null)
            {
                AddFileSecurity(file.FullName, "Everyone", FileSystemRights.FullControl, AccessControlType.Allow);
                Config.DatabaseFile = file.FullName;

                System.Diagnostics.Process p = new System.Diagnostics.Process();

                try
                {
                    System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
                    startinfo.FileName = @"WinRAR.exe";//需要启动的程序名 
                    string rarPath = file.Directory.FullName;
                    startinfo.Arguments = string.Format("x -p0x00000000025203a0 {0} {1}", file.FullName, rarPath);//启动参数                         
                                                                                                                  //设置命令参数  
                                                                                                                  //startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;  //隐藏 WinRAR 窗口
                    p.StartInfo = startinfo;
                    p.Start();//启动
                    p.WaitForExit(); //无限期等待进程 winrar.exe 退出
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    p.Dispose();
                    p.Close();
                }
            }
        }

        public static void AddFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType contorlType)
        {
            FileSecurity _fs = File.GetAccessControl(fileName);
            _fs.AddAccessRule(new FileSystemAccessRule(account, rights, contorlType));
            File.SetAccessControl(fileName, _fs);
        }
    }
}
