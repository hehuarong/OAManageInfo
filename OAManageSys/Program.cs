using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace OAManageSys
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            if (args.Length > 0)
            {
                string id = "";
                try
                {
                    id =  Common2.JSRSA.Decrypt(args[0].ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show("解析ID失败！" + ex.Message);
                }
                frm_login login = new frm_login(id);
                if (login.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    FlushMemory();
                    Application.Run(new frm_main());
                }
            }
            else
            {
                object uid = Common2.CacheHelper.GetCache("uid");
                if (uid != null)
                {
                    frm_login login = new frm_login(uid.ToString());
                    if (login.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        FlushMemory();
                        Application.Run(new frm_main());
                    }
                }
                else
                {
                    frm_login login = new frm_login();
                    FlushMemory();
                    if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FlushMemory();
                        Application.Run(new frm_main());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }



        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string path = "C://OAManageSys.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                File.WriteAllText(path, e.ExceptionObject.ToString(), Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(path, e.ExceptionObject.ToString(), Encoding.UTF8);
            }
            MessageBox.Show(e.ExceptionObject.ToString());
        }
        /// <summary>
        /// 使程序前端显示
        /// </summary>
        /// <param name="instance"></param>
        private static void SetForegroud(Process instance)
        {
            IntPtr mainFormHandle = instance.MainWindowHandle;
            if (mainFormHandle != IntPtr.Zero)
            {
                ShowWindowAsync(mainFormHandle, 1);
                SetForegroundWindow(mainFormHandle);
            }
        }
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary>
        /// 查看程序是否已经运行
        /// </summary>
        /// <returns></returns>
        private static Process GetExistProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if ((process.Id != currentProcess.Id) &&
                    (Assembly.GetExecutingAssembly().Location == currentProcess.MainModule.FileName))
                {
                    return process;
                }
            }
            return null;
        }
        /// <summary>
        /// 清理内存
        /// </summary>
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(
            IntPtr process,
            int minSize,
            int maxSize);

    }
}
