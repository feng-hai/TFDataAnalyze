using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Installation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmInstallation frmInstallation = new FrmInstallation();
            try
            {
                RegistryKey regFather = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UnInstallation\\" + frmInstallation.strProductNameEnglish,false);
                if (regFather != null)
                {
                    string str = regFather.GetValue("DisplayVersion", "").ToString();
                    if (str.Length == 0)
                    {
                        //注册表信息不完整，无法验证版本，强制安装
                    }
                    else if (Int32.Parse(str.Replace(".", "")) == Int32.Parse(Application.ProductVersion.Replace(".", "")))
                    {
                        if (new FrmMsg("系统提示", "当前计算机中已安装了本产品的相同版本，你确定以修复方式重新安装？", true).ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (Int32.Parse(str.Replace(".", "")) > Int32.Parse(Application.ProductVersion.Replace(".", "")))
                    {
                        if (new FrmMsg("系统提示", "当前计算机中安装的产品版本高于当前安装程序的版本，你确定要使用旧版本替换新版本吗？", true).ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
            }
            catch { }
            Application.Run(frmInstallation);
        }
    }
}
