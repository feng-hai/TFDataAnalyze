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

namespace Installation
{
    public partial class FrmInstallation : Form
    {
        /// <summary>
        /// 可填充区域，用户可根据实际安装需求更改此项
        /// </summary>
        public string strCompanyNameEnglish = "XYBarcode";
        public string strProductNameEnglish = "MESBarcodeServer";
        public string strServiceNameEnglish = "MES Barcode Server";
        public string strCompanyURL = "http://www.xybarcode.com";

        /// <summary>
        /// 程序变量，请勿更改
        /// </summary>
        private string strInstallationPath = "";
        private bool bExpansion = false, bDesktopLink = true, bStartMenuLink = true, bStartBarLink = true, bUserExperience = true;
        private int iFormSizeHeightNor = 360, iFormSizeHeightExp = 470;
        private string strResult = "";
        private FolderBrowserDialog fbd = new FolderBrowserDialog();

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

        public FrmInstallation()
        {
            InitializeComponent();
            fbd.RootFolder = System.Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            fbd.ShowNewFolderButton = true;
            txtPath.Text = fbd.SelectedPath + "\\" + strCompanyNameEnglish + "\\" + strProductNameEnglish;

            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
            lblMainTitle.Text = Application.ProductName;
            this.Text = Application.ProductName + "安装程序";
            this.Icon = Installation.Properties.Resources.Installation;
            lblCompanyName.Text = Application.CompanyName;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowMain), null);
        }

        private void ShowMain(object obj)
        {
            while (this.Opacity!=1)
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
            lblClose.Image = Installation.Properties.Resources.Close_Ent;
        }

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.Image = Installation.Properties.Resources.Close_Dwn;
            lblClose.Location = new Point(lblClose.Location.X + 1, lblClose.Location.Y + 1);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.Image = Installation.Properties.Resources.Close_Nor;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.Location = new Point(lblClose.Location.X - 1, lblClose.Location.Y - 1);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            lblOK_Click(sender, e);
        }

        private void lblLicense_MouseEnter(object sender, EventArgs e)
        {
            if (((Label)sender).Tag.ToString().Length == 0)
            {
                ((Label)sender).Image = Installation.Properties.Resources.chk_unchecked_ent;
            }
            else
            {
                ((Label)sender).Image = Installation.Properties.Resources.chk_checked_ent;
            }
        }

        private void lblLicense_MouseLeave(object sender, EventArgs e)
        {
            if (((Label)sender).Tag.ToString().Length == 0)
            {
                ((Label)sender).Image = Installation.Properties.Resources.chk_unchecked_nor;
            }
            else
            {
                ((Label)sender).Image = Installation.Properties.Resources.chk_checked_nor;
            }
        }

        private void lblLicense_Click(object sender, EventArgs e)
        {
            if (lblLicense.Tag.ToString().Length == 0)
            {
                lblLicense.Image = Installation.Properties.Resources.chk_checked_ent;
                lblLicense.Tag = "CHK";
                lblGO.Enabled = true;
            }
            else
            {
                lblLicense.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblLicense.Tag = "";
                lblGO.Enabled = false;
            }
        }

        private void lblPath_MouseDown(object sender, MouseEventArgs e)
        {
            lblPath.Image = Installation.Properties.Resources.OpenDialog_Dwn;
            lblPath.Location = new Point(lblPath.Location.X + 1, lblPath.Location.Y + 1);
        }

        private void lblPath_MouseEnter(object sender, EventArgs e)
        {
            lblPath.Image = Installation.Properties.Resources.OpenDialog_Ent;
        }

        private void lblPath_MouseLeave(object sender, EventArgs e)
        {
            lblPath.Image = Installation.Properties.Resources.OpenDialog_Nor;
        }

        private void lblPath_MouseUp(object sender, MouseEventArgs e)
        {
            lblPath.Location = new Point(lblPath.Location.X - 1, lblPath.Location.Y - 1);
        }

        private void lblPath_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath + "\\" + strCompanyNameEnglish + "\\" + strProductNameEnglish;
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            strInstallationPath = txtPath.Text;
        }

        private void txtPath_MouseEnter(object sender, EventArgs e)
        {
            lblTXTBorder.Visible = true;
        }

        private void txtPath_MouseLeave(object sender, EventArgs e)
        {
            lblTXTBorder.Visible = false;
        }
        
        private void lblGO_Click(object sender, EventArgs e)
        {
            if (bExpansion)
            {
                lblHighLevel_Click(sender, e);
                while (this.Size.Height != iFormSizeHeightNor)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
            }

            try
            {
                DirectoryInfo di = new DirectoryInfo(strInstallationPath);
                strInstallationPath = di.FullName.Substring(0, di.FullName.LastIndexOf(di.Name) + di.Name.Length);
                Directory.CreateDirectory(strInstallationPath);
            }
            catch
            {
                new FrmMsg("系统提示", "无法将文件安装到你选定的目录，请检查路径或者是否拥有写权限。", false).ShowDialog();
                return;
            }
            
            lblLicense.Visible = llnkLicense.Visible = lblPath.Visible = lblTXTBorder.Visible = txtPath.Visible = lblGO.Visible = lblHighLevel.Visible = lblCompanyName.Visible = false;
            lblLoading.Visible = lblDoing.Visible = true;

            lblDoing.Text = "正在检测相关服务是否在运行...";
            Application.DoEvents(); 
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
            
            lblDoing.Text = "正在检测相关程序是否在运行...";
            Application.DoEvents();
            Process[] proArr = Process.GetProcessesByName(strProductNameEnglish);
            for (int i = 0; i < proArr.Length; i++)
            {
                proArr[i].Kill();
            }

            lblDoing.Text = "正在检测是否安装有旧版本...";
            Application.DoEvents();
            try
            {
                RegistryKey regFather = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UnInstallation", true);
                regFather.DeleteSubKey(strProductNameEnglish, false);
                regFather.Close();
            }
            catch { }

            try
            {
                lblDoing.Text = "提取文件:InstallationUtil.exe";
                Application.DoEvents();
                File.WriteAllBytes(strInstallationPath + "\\InstallationUtil.exe", Installation.Properties.InstallFiles.InstallUtil);

                lblDoing.Text = "提取文件:MESBarcodeServerService.exe";
                Application.DoEvents();
                File.WriteAllBytes(strInstallationPath + "\\MESBarcodeServerService.exe", Installation.Properties.InstallFiles.MESBarcodeServerService);

                lblDoing.Text = "提取文件:MESBarcodeServer.exe";
                Application.DoEvents();
                File.WriteAllBytes(strInstallationPath + "\\MESBarcodeServer.exe", Installation.Properties.InstallFiles.MESBarcodeServer);

                lblDoing.Text = "提取文件:UnInstallation.exe";
                Application.DoEvents();
                File.WriteAllBytes(strInstallationPath + "\\UnInstallation.exe", Installation.Properties.InstallFiles.UnInstall);

                lblDoing.Text = "正在提取服务所需的组件...";
                Application.DoEvents();
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.StartInfo.RedirectStandardInput = true;//可能接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.Start();//启动程序

                p.StandardInput.WriteLine("\"" + strInstallationPath + "\\InstallationUtil.exe\" /u \"" + strInstallationPath + "\\MESBarcodeServerService.exe\"");//卸载服务
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

                lblDoing.Text = "正在注册服务 " + strServiceNameEnglish + " ...";
                p.StandardInput.WriteLine("\"" + strInstallationPath + "\\InstallationUtil.exe\" \"" + strInstallationPath + "\\MESBarcodeServerService.exe\"");//重新安装服务
            RECHECKTWO:
                strResult = "";
                sControllerArr = ServiceController.GetServices();
                foreach (ServiceController item in sControllerArr)
                {
                    Application.DoEvents();
                    if (item.ServiceName.Equals(strServiceNameEnglish))
                    {
                        strResult = "SUCCESS";
                        break;
                    }
                }
                if (!strResult.Equals("SUCCESS"))
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                    goto RECHECKTWO;
                }

                lblDoing.Text = "正在启动服务 " + strServiceNameEnglish + " ...";
                Application.DoEvents();
                p.StandardInput.WriteLine("sc config Service1 start=auto");//配置服务
            RESTART:
                try
                {
                    new ServiceController(strServiceNameEnglish).Start();//启动服务
                    if (!new ServiceController(strServiceNameEnglish).Status.Equals(ServiceControllerStatus.Running))
                    {
                        Thread.Sleep(10);
                        Application.DoEvents();
                        goto RESTART;
                    }
                }
                catch
                {
                    if (!new ServiceController(strServiceNameEnglish).Status.Equals(ServiceControllerStatus.Running))
                    {
                        Thread.Sleep(10);
                        Application.DoEvents();
                        goto RESTART;
                    }
                }
                p.Close();//关闭CMD进程

                lblDoing.Text = "正在向系统注册程序...";
                Application.DoEvents();
                RegistryKey regFather = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UnInstallation",true);
                regFather.CreateSubKey(strProductNameEnglish);
                regFather = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UnInstallation\\" + strProductNameEnglish,true);
                regFather.SetValue("DisplayIcon", strInstallationPath + "\\MESBarcodeServer.exe");
                regFather.SetValue("DisplayName", Application.ProductName);
                regFather.SetValue("DisplayVersion", Application.ProductVersion);
                regFather.SetValue("Publisher", Application.CompanyName);
                regFather.SetValue("UnInstallationString", strInstallationPath + "\\UnInstallation.exe");
                regFather.SetValue("URLInfoAbout", strCompanyURL);
                
                if (bDesktopLink || bStartBarLink || bStartMenuLink)
                {
                    Common.Shortcut sc = new Installation.Common.Shortcut();
                    sc.Path = strInstallationPath + "\\MESBarcodeServer.exe";
                    sc.Arguments = "";
                    sc.WorkingDirectory = strInstallationPath;
                    sc.Description = "";
                    if (bDesktopLink)
                    {
                        lblDoing.Text = "正在创建桌面快捷方式...";
                        Application.DoEvents();
                        sc.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Application.ProductName + ".lnk");
                    }

                    //快速启动栏创建不进去....

                    if (bStartMenuLink)
                    {
                        lblDoing.Text = "正在创建开始菜单快捷方式...";
                        Application.DoEvents();
                        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName + "\\"))
                        {
                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName + "\\");
                        }
                        sc.Save(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName + "\\" + Application.ProductName + ".lnk");
                        sc = new Installation.Common.Shortcut();
                        sc.Path = strInstallationPath + "\\UnInstallation.exe";
                        sc.Arguments = "";
                        sc.WorkingDirectory = strInstallationPath;
                        sc.Description = "";
                        sc.Save(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + Application.ProductName + "\\卸载.lnk");
                    }
                }
               
                lblDoing.Text = "正在清理安装时释放的临时文件...";
                Application.DoEvents();
            REDELETE:
                try
                {
                    File.Delete(strInstallationPath + "\\InstallationUtil.exe");
                    File.Delete("InstallationUtil.InstallationLog");
                }
                catch 
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                    goto REDELETE;
                }

                lblLoading.Visible = false;
                lblDoing.Text = "安装完成。";
                lblSuccess.Text = "恭喜！你已成功安装产品 " + Application.ProductName+" ，接下来即可体验该产品为您提供的服务。";
                pSuccess.Location = new Point(0, 141);
                pSuccess.Size = new Size(640, 180);
                pSuccess.Visible = lblCompanyName.Visible = true;
            }
            catch
            {
                new FrmMsg("系统提示", "安装程序无法写入组件，安装将被中断，请重新运行安装程序。", false).ShowDialog();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void lblGO_MouseDown(object sender, MouseEventArgs e)
        {
            lblGO.Image = Installation.Properties.Resources.go_Dwn;
            lblGO.Location = new Point(lblGO.Location.X + 1, lblGO.Location.Y + 1);
        }

        private void lblGO_MouseEnter(object sender, EventArgs e)
        {
            lblGO.Image = Installation.Properties.Resources.go_Ent;
        }

        private void lblGO_MouseLeave(object sender, EventArgs e)
        {
            lblGO.Image = Installation.Properties.Resources.go_Nor;
        }

        private void lblGO_MouseUp(object sender, MouseEventArgs e)
        {
            lblGO.Location = new Point(lblGO.Location.X - 1, lblGO.Location.Y - 1);
        }

        private void llnkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmMsg("系统提示", "安装程序未找到最终用户许可协议文件。",false).ShowDialog();
        }

        private void lblHighLevel_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Expansion), null);
        }

        private void Expansion(object obj)
        {
            Invoke((Action)delegate()
            {
                while (true)
                {
                    if (!bExpansion)
                    {
                        this.Size = new Size(this.Size.Width, this.Size.Height + 10);
                        if (this.Size.Height == iFormSizeHeightExp)
                        {
                            lblCompanyName.Visible = false;
                            bExpansion = true;
                            lblHighLevel.Image = Installation.Properties.Resources.up;
                            break;
                        }
                    }
                    else
                    {
                        this.Size = new Size(this.Size.Width, this.Size.Height - 10);
                        if (this.Size.Height == iFormSizeHeightNor)
                        {
                            bExpansion = false;
                            lblCompanyName.Visible = true;
                            lblHighLevel.Image = Installation.Properties.Resources.dwn;
                            break;
                        }
                    }
                    Application.DoEvents();
                } 
            });
        }

        private void lblDesktopLink_Click(object sender, EventArgs e)
        {
            if (lblDesktopLink.Tag.ToString().Length == 0)
            {
                lblDesktopLink.Image = Installation.Properties.Resources.chk_checked_ent;
                lblDesktopLink.Tag = "CHK";
                bDesktopLink = true;
            }
            else
            {
                lblDesktopLink.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblDesktopLink.Tag = "";
                bDesktopLink = false;
            }
        }

        private void lblStartMenuLink_Click(object sender, EventArgs e)
        {
            if (lblStartMenuLink.Tag.ToString().Length == 0)
            {
                lblStartMenuLink.Image = Installation.Properties.Resources.chk_checked_ent;
                lblStartMenuLink.Tag = "CHK";
                bStartMenuLink = true;
            }
            else
            {
                lblStartMenuLink.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblStartMenuLink.Tag = "";
                bStartMenuLink = false;
            }
        }

        private void lblStartBarLink_Click(object sender, EventArgs e)
        {
            if (lblStartBarLink.Tag.ToString().Length == 0)
            {
                lblStartBarLink.Image = Installation.Properties.Resources.chk_checked_ent;
                lblStartBarLink.Tag = "CHK";
                bStartBarLink = true;
            }
            else
            {
                lblStartBarLink.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblStartBarLink.Tag = "";
                bStartBarLink = false;
            }
        }

        private void lblUserExperience_Click(object sender, EventArgs e)
        {
            if (lblUserExperience.Tag.ToString().Length == 0)
            {
                lblUserExperience.Image = Installation.Properties.Resources.chk_checked_ent;
                lblUserExperience.Tag = "CHK";
                bUserExperience = true;
            }
            else
            {
                lblUserExperience.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblUserExperience.Tag = "";
                bUserExperience = false;
            }
        }

        private void lblStartProduct_Click(object sender, EventArgs e)
        {
            if (lblStartProduct.Tag.ToString().Length == 0)
            {
                lblStartProduct.Image = Installation.Properties.Resources.chk_checked_ent;
                lblStartProduct.Tag = "CHK";
            }
            else
            {
                lblStartProduct.Image = Installation.Properties.Resources.chk_unchecked_ent;
                lblStartProduct.Tag = "";
            }
        }

        private void lblOK_MouseDown(object sender, MouseEventArgs e)
        {
            lblOK.Image = Installation.Properties.Resources.btn_Dwn;
            lblOK.Location = new Point(lblOK.Location.X + 1, lblOK.Location.Y + 1);
        }

        private void lblOK_MouseEnter(object sender, EventArgs e)
        {
            lblOK.Image = Installation.Properties.Resources.btn_Ent;
        }

        private void lblOK_MouseLeave(object sender, EventArgs e)
        {
            lblOK.Image = Installation.Properties.Resources.btn_Nor;
        }

        private void lblOK_MouseUp(object sender, MouseEventArgs e)
        {
            lblOK.Location = new Point(lblOK.Location.X - 1, lblOK.Location.Y - 1);
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            if (lblStartProduct.Tag.ToString().Length != 0 && pSuccess.Visible)
            {
                Process.Start(strInstallationPath + "\\MESBarcodeServer.exe");
            }
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!pSuccess.Visible)
            {
                if (new FrmMsg("系统提示", "你确定要取消安装并退出安装向导？", true).ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}