using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security;

namespace UHVClient
{
    /// 
    /// 压缩类
    /// 
    static class ZipUtil
    {
        public static bool Exists()
        {

            RegistryKey the_Reg =
                Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");

            return !string.IsNullOrEmpty(the_Reg.GetValue("").ToString());

        }

        public static string unCompressRAR(string unRarPatch, string rarPatch, string rarName)
        {
            string the_rar;
            RegistryKey the_Reg;
            object the_Obj;
            string the_Info;
            try
            {
                the_Reg =
                    Registry.LocalMachine.OpenSubKey(
                         @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");

                the_Obj = the_Reg.GetValue("");
                the_rar = the_Obj.ToString();
                the_Reg.Close();
                //the_rar = the_rar.Substring(1, the_rar.Length - 7);
                if (Directory.Exists(unRarPatch) == false)

                {
                    Directory.CreateDirectory(unRarPatch);
                }

                the_Info = "x " + rarName + " " + unRarPatch + " -y";
                ProcessStartInfo the_StartInfo = new ProcessStartInfo();
                the_StartInfo.FileName = the_rar;
                the_StartInfo.Password = StringToSecureString("123456");
                the_StartInfo.Arguments = the_Info;
                the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                the_StartInfo.WorkingDirectory = rarPatch;//获取压缩包路径

                Process the_Process = new Process();
                the_Process.StartInfo = the_StartInfo;

                the_Process.StartInfo.UseShellExecute = false;
                the_Process.Start();
                the_Process.WaitForExit();
                the_Process.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unRarPatch;
        }

        static SecureString StringToSecureString(String value)
        {
            SecureString password = new SecureString();
            char[] pass = value.ToCharArray();
            for (int i = 0; i < pass.Length; i++)
            {
                password.AppendChar(pass[i]);
            }
            return password;
        }
    }
}