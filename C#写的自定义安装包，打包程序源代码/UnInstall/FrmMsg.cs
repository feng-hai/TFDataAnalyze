using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace UnInstall
{
    public partial class FrmMsg : Form
    {
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

        public FrmMsg(string title,string msg,bool bCancel)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMSG.Text = msg;
            if (bCancel)
            {
                lblOK.Visible = lblCancel.Visible = true;
                lblOK.Location = new Point(230, 137);
                lblCancel.Location = new Point(292, 137);
            }
            else
            {
                lblOK.Visible = true;
                lblCancel.Visible = false;
                lblOK.Location = new Point(292, 137);
            }
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
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
            lblClose.Image = UnInstall.Properties.Resources.MSGClose_Ent;
        }

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.Image = UnInstall.Properties.Resources.MSGClose_Dwn;
            lblClose.Location = new Point(lblClose.Location.X + 1, lblClose.Location.Y + 1);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.Image = UnInstall.Properties.Resources.MSGClose_Nor;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.Location = new Point(lblClose.Location.X - 1, lblClose.Location.Y - 1);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblCancel_MouseEnter(object sender, EventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn2_Ent;
        }

        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn2_Nor;
        }

        private void lblCancel_MouseDown(object sender, MouseEventArgs e)
        {
            lblCancel.Image = UnInstall.Properties.Resources.btn2_Dwn;
            lblCancel.Location = new Point(lblCancel.Location.X + 1, lblCancel.Location.Y + 1);
        }

        private void lblCancel_MouseUp(object sender, MouseEventArgs e)
        {
            lblCancel.Location = new Point(lblCancel.Location.X - 1, lblCancel.Location.Y - 1);
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblOK_MouseDown(object sender, MouseEventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn_Dwn;
            lblOK.Location = new Point(lblOK.Location.X + 1, lblOK.Location.Y + 1);
        }

        private void lblOK_MouseEnter(object sender, EventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn_Ent;
        }

        private void lblOK_MouseLeave(object sender, EventArgs e)
        {
            lblOK.Image = UnInstall.Properties.Resources.btn_Nor;
        }

        private void lblOK_MouseUp(object sender, MouseEventArgs e)
        {
            lblOK.Location = new Point(lblOK.Location.X - 1, lblOK.Location.Y - 1);
        }

        private void FrmMsg_Load(object sender, EventArgs e)
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
    }
}
