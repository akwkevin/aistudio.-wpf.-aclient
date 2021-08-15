using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceMonitor
{
    public class CmdHelper
    {
        //private void btnPort_Click(object sender, RoutedEventArgs e)
        //{
        //    int port = 5000;
        //    //bool b = int.TryParse(t_txt_guardport.Text, out port);
        //    //if (!b)
        //    //{
        //    //    MessageBox.Show("请输入正确的监听端口");
        //    //    return;
        //    //}
        //    Process p = new Process();
        //    p.StartInfo.FileName = "cmd.exe";
        //    p.StartInfo.UseShellExecute = false;
        //    p.StartInfo.RedirectStandardError = true;
        //    p.StartInfo.RedirectStandardInput = true;
        //    p.StartInfo.RedirectStandardOutput = true;
        //    p.StartInfo.CreateNoWindow = true;
        //    List<int> list_pid = GetPidByPort(p, port);
        //    if (list_pid.Count == 0)
        //    {
        //        MessageBox.Show("操作完成");
        //        return;
        //    }
        //    List<string> list_process = GetProcessNameByPid(p, list_pid);
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("占用" + port + "端口的进程有:");
        //    foreach (var item in list_process)
        //    {
        //        sb.Append(item + "\r\n");
        //    }
        //    sb.AppendLine("是否要结束这些进程？");

        //    if (MessageBox.Show(sb.ToString(), "系统提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
        //        return;
        //    PidKill(p, list_pid);
        //    MessageBox.Show("操作完成");
        //}

        public static void PidKill(List<int> list_pid)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            foreach (var item in list_pid)
            {
                p.StandardInput.WriteLine("taskkill /pid " + item + " /f");
                p.StandardInput.WriteLine("exit");
            }

            Task.Delay(1000).GetAwaiter().GetResult();
            p.Close();
            p.Dispose();
        }

        public static List<int> GetPidByPort(int port)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;           
            p.Start();

            p.StandardInput.WriteLine(string.Format("netstat -ano|find \"{0}\"", port));
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();
            List<int> list_pid = new List<int>();
            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                if (strLine.Length > 0 && ((strLine.Contains("TCP") || strLine.Contains("UDP"))))
                {
                    Regex r = new Regex(@"\s+");
                    string[] strArr = r.Split(strLine);
                    if (strArr.Length >= 4)
                    {
                        if (strArr[1].EndsWith($":{port}"))
                        {
                            int result;
                            bool b = int.TryParse(strArr[4], out result);
                            if (b && !list_pid.Contains(result))
                                list_pid.Add(result);
                        }
                    }
                }
                strLine = reader.ReadLine();
            }
            p.WaitForExit();
            reader.Close();
            p.Close();
            p.Dispose();
            return list_pid;
        }

        public static List<string> GetProcessNameByPid(List<int> list_pid)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            List<string> list_process = new List<string>();
            foreach (var pid in list_pid)
            {
                p.StandardInput.WriteLine(string.Format("tasklist |find \"{0}\"", pid));
                p.StandardInput.WriteLine("exit");
                StreamReader reader = p.StandardOutput;//截取输出流
                string strLine = reader.ReadLine();//每次读取一行

                while (!reader.EndOfStream)
                {
                    strLine = strLine.Trim();
                    if (strLine.Length > 0 && ((strLine.Contains(".exe"))))
                    {
                        Regex r = new Regex(@"\s+");
                        string[] strArr = r.Split(strLine);
                        if (strArr.Length > 0)
                        {
                            list_process.Add(strArr[0]);
                        }
                    }
                    strLine = reader.ReadLine();
                }
                p.WaitForExit();
                reader.Close();
            }
            p.Close();
            p.Dispose();
            return list_process;
        }
    }
}
