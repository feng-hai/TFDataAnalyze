using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Diagnostics;
using System.Reflection;

namespace UnInstall
{
    public partial class FrmUnInstall : Form
    {
        /// <summary>
        /// 可填充区域，用户可根据实际安装需求更改此项
        /// </summary>
        public string strProductNameEnglish = "MESBarcodeServer";
        public string strServiceNameEnglish = "MES Barcode Server";
        

        #region 拖动无边框窗体
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();//改变窗体大小
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);//发送windows消息
        #endregion

        #region 窗体边框阴影效果变量申明
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        #endregion

        public FrmUnInstall()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
            lblMainTitle.Text = Application.ProductName;
            this.Text = Application.ProductName + "卸载程序";
            this.Icon = UnInstall.Properties.Resources.UnInstall;
            lblMark.Text = "你确定要卸载产品 " + Application.ProductName + " 吗？";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowMain), null);
        }

        private void ShowMain(object obj)
        {
            while (this.Opacity != 1)
            {
                Invoke((Action)delegate()
                {
                    this.Opacity += 0.1;
                    Thread.Sleep(2);
                    Application.DoEvents();
                });
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 274, 61449, 0);
            }
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.Image = UnInstall.Properties.Resources.Close_Ent;
        }

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.Image = UnInstall.Properties.Resources.Close2_Dwn;
            lblClose.Location = new Point(lblClose.Location.X + 1, lblClose.Location.Y + 1);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.Image = UnInstall.Properties.Resources.Close2_Nor;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.Location = new Point(lblClose.Location.X - 1, lblClose.Location.Y - 1);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblOK_MouseDown(object sender, MouseEventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn3_Dwn;
            lblOK.Location = new Point(lblOK.Location.X + 1, lblOK.Location.Y + 1);
        }

        private void lblOK_MouseEnter(object sender, EventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn3_Ent;
        }

        private void lblOK_MouseLeave(object sender, EventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn3_Nor;
        }

        private void lblOK_MouseUp(object sender, MouseEventArgs e)
        {
            lblOK.Location = new Point(lblOK.Location.X - 1, lblOK.Location.Y - 1);
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            lblDeleteConfig.Visible = lblMark.Visible = lblOK.Visible = lblCancel.Visible = false;
            lblLoadingTxt.Visible = lblLoadingBack.Visible = lblLoadingDoing.Visible = true;

            lblLoadingTxt.Text = "正在停止服务...";
            ServiceController[] sControllerArr = ServiceController.GetServices();
            foreach (ServiceController item in sControllerArr)
            {
                if (item.ServiceName.Equals(strServiceNameEnglish))
                {
                RESTOP:
                    try
                    {
                        if (new ServiceController(strServiceNameEnglish).Status.Equals(ServiceControllerStatus.Running))
                        {
                            new ServiceController(strServiceNameEnglish).Stop();//停止服务
                            if (!new ServiceController(strServiceNameEnglish).Status.Equals(ServiceControllerStatus.Stopped))
                            {
                                Thread.Sleep(10);
                                Application.DoEvents();
                                goto RESTOP;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        if (!new ServiceController(strServiceNameEnglish).Status.Equals(ServiceControllerStatus.Stopped))
                        {
                            Thread.Sleep(10);
                            Application.DoEvents();
                            goto RESTOP;
                        }
                    }
                }
            }
            lblLoadingDoing.Size = new Size(lblLoadingDoing.Size.Width + 100, lblLoadingDoing.Size.Height);

            lblLoadingTxt.Text = "正在停止配置中心...";
            Application.DoEvents();
            Process[] proArr = Process.GetProcessesByName(strProductNameEnglish);
            for (int i = 0; i < proArr.Length; i++)
            {
                proArr[i].Kill();
            }
            lblLoadingDoing.Size = new Size(lblLoadingDoing.Size.Width + 100, lblLoadingDoing.Size.Height);

            lblLoadingTxt.Text = "正在卸载注册表项...";
            Application.DoEvents();
            try
            {
                RegistryKey regFather = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
                regFather.DeleteSubKey(strProductNameEnglish, false);
                regFather.Close();
            }
            catch { }
            lblLoadingDoing.Size = new Size(lblLoadingDoing.Size.Width + 100, lblLoadingDoing.Size.Height);

            lblLoadingTxt.Text = "正在提取卸载组件...";
            Application.DoEvents();
            File.WriteAllBytes(Application.StartupPath + "\\InstallUtil.exe", UnInstall.Properties.InstallFiles.InstallUtil);
            lblLoadingDoing.Size = new Size(lblLoadingDoing.Size.Width + 100, lblLoadingDoing.Size.Height);

            lblLoadingTxt.Text = "正在卸载服务...";
            Application.DoEvents();
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.StartInfo.RedirectStandardInput = true;//可能接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.Start();//启动程序
            p.StandardInput.WriteLine("\"" + Application.StartupPath + "\\InstallUtil.exe\" /u \"" + Application.StartupPath + "\\MESBarcodeServerService.exe\"");//卸载服务
        RECHECK:
            sControllerArr = ServiceController.GetServices();
            foreach (ServiceController item in sControllerArr)
            {
                Application.DoEvents();
                if (item.ServiceName.Equals(strServiceNameEnglish))
                {
                    Thread.Sleep(10);
                    goto RECHECK;
                }
            }
            p.Close();//关闭CMD进程

            lblLoadingTxt.Text = "正在清理服务组件...";
            Application.DoEvents();
        REDELETE:
            try
            {
                File.Delete(Application.StartupPath + "\\InstallUtil.exe");
            }
            catch
            {
                Thread.Sleep(10);
                Application.DoEvents();
                goto REDELETE;
            }
            lblLoadingDoing.Size = new Size(lblLoadingDoing.Size.Width + 100, lblLoadingDoing.Size.Height);

            lblLoadingTxt.Text = "正在删除快捷方式...";
            Application.DoEvents();
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Application.ProductName + ".lnk");
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName))
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName, true);
            }

            lblLoadingTxt.Visible = lblLoadingBack.Visible = lblLoadingDoing.Visible = false;
            lblSuccess.Text = "你已成功卸载了产品 " + Application.ProductName + " 。\r\n感谢你对 " + Application.ProductName + " 的支持，欢迎下次使用。";
            lblSuccess.Visible = lblCancel.Visible = true;
            lblCancel.Text = "完成";
        }

        private void lblDeleteConfig_MouseEnter(object sender, EventArgs e)
        {
            if (((Label)sender).Tag.ToString().Length == 0)
            {
                ((Label)sender).Image = UnInstall.Properties.Resources.chk_unchecked_ent;
            }
            else
            {
                ((Label)sender).Image = UnInstall.Properties.Resources.chk_checked_ent;
            }
        }

        private void lblDeleteConfig_MouseLeave(object sender, EventArgs e)
        {
            if (((Label)sender).Tag.ToString().Length == 0)
            {
                ((Label)sender).Image = UnInstall.Properties.Resources.chk_unchecked_nor;
            }
            else
            {
                ((Label)sender).Image = UnInstall.Properties.Resources.chk_checked_nor;
            }
        }

        private void lblDeleteConfig_Click(object sender, EventArgs e)
        {
            if (lblDeleteConfig.Tag.ToString().Length == 0)
            {
                lblDeleteConfig.Image = UnInstall.Properties.Resources.chk_checked_ent;
                lblDeleteConfig.Tag = "CHK";
            }
            else
            {
                lblDeleteConfig.Image = UnInstall.Properties.Resources.chk_unchecked_ent;
                lblDeleteConfig.Tag = "";
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCancel_MouseDown(object sender, MouseEventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn4_Dwn;
            lblCancel.Location = new Point(lblCancel.Location.X + 1, lblCancel.Location.Y + 1);
        }

        private void lblCancel_MouseEnter(object sender, EventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn4_Ent;
        }

        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn4_Nor;
        }

        private void lblCancel_MouseUp(object sender, MouseEventArgs e)
        {
            lblCancel.Location = new Point(lblCancel.Location.X - 1, lblCancel.Location.Y - 1);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!lblSuccess.Visible)
            {
                if (new FrmMsg("系统提示", "你确定退出卸载程序，不继续卸载本产品吗？", true).ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\~del.bat", false, Encoding.Default);
                sw.WriteLine("del /F /S /Q \"" + new DirectoryInfo(Application.StartupPath).FullName + "\"");
                sw.Close();

                ProcessStartInfo psi = new ProcessStartInfo(Application.StartupPath + "\\~del.bat");
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
