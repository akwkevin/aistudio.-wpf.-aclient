using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CustomBA
{
    public class RunHelper
    {
        /// <summary>
        /// 运行安装程序
        /// </summary>
        /// <param name="path"></param>
        public static void RunInstaller(string path)
        {
           
            var fileinfo=new FileInfo(path);
            if (fileinfo.Length ==0)
            {
                MessageBox.Show("文件读取失败，可能是因为文件下载错误,请检查文件 "+path, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            var s = Path.GetExtension(path);
            if (s == null) return;
            var extension = s.ToLower();

            switch (extension)
            {
                case ".msi":
                case ".msp":
                    RunMs(path, extension);
                    break;
                case ".exe":
                    RunEXE(path);
                    break;
            }
        }

        private static void RunMs(string path, string extension)
        {
            try
            {
                var start = extension == ".msi"
                    ? new ProcessStartInfo("msiexec.exe", "/i  " + path)
                    : new ProcessStartInfo("msiexec.exe", "/update  " + path);
                start.WindowStyle = ProcessWindowStyle.Normal;
                start.CreateNoWindow = true;
                Process.Start(start);//.WaitForExit()
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private static void RunEXE(string path)
        {
            var prc = new Process();
            try
            {
                //prc.StartInfo.FileName = path;
                //prc.StartInfo.UseShellExecute = false;
                //prc.StartInfo.RedirectStandardError = true;
                //prc.StartInfo.RedirectStandardOutput = true;
                //prc.StartInfo.RedirectStandardInput = true;
                //prc.StartInfo.CreateNoWindow = false;
                //prc.Start();
               prc.StartInfo=new ProcessStartInfo(path);
               prc.Start();


            }
            catch (Exception exU)
            {
                if (!prc.HasExited)
                {
                    prc.Close();
                }
                MessageBox.Show(exU.ToString(), "错误");
            }
        }
    }
}
