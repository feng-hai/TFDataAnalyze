namespace Installation
{
    partial class FrmMsg
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMSG = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "系统提示";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.LightGray;
            this.lblClose.Image = global::Installation.Properties.Resources.MSGClose_Nor;
            this.lblClose.Location = new System.Drawing.Point(331, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(17, 17);
            this.lblClose.TabIndex = 3;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseDown);
            this.lblClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseUp);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            // 
            // lblMSG
            // 
            this.lblMSG.BackColor = System.Drawing.Color.Transparent;
            this.lblMSG.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMSG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lblMSG.Location = new System.Drawing.Point(78, 81);
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(270, 37);
            this.lblMSG.TabIndex = 4;
            this.lblMSG.Tag = "";
            this.lblMSG.Text = "你确定要取消安装并退出安装向导？";
            this.lblMSG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblOK
            // 
            this.lblOK.BackColor = System.Drawing.Color.Transparent;
            this.lblOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblOK.Image = global::Installation.Properties.Resources.btn_Nor;
            this.lblOK.Location = new System.Drawing.Point(230, 137);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(56, 41);
            this.lblOK.TabIndex = 6;
            this.lblOK.Tag = "";
            this.lblOK.Text = "确定";
            this.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOK.MouseLeave += new System.EventHandler(this.lblOK_MouseLeave);
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            this.lblOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseDown);
            this.lblOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseUp);
            this.lblOK.MouseEnter += new System.EventHandler(this.lblOK_MouseEnter);
            // 
            // lblCancel
            // 
            this.lblCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblCancel.Image = global::Installation.Properties.Resources.btn2_Nor;
            this.lblCancel.Location = new System.Drawing.Point(292, 137);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(56, 41);
            this.lblCancel.TabIndex = 9;
            this.lblCancel.Tag = "";
            this.lblCancel.Text = "取消";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            this.lblCancel.Click += new System.EventHandler(this.lblClose_Click);
            this.lblCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseDown);
            this.lblCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseUp);
            this.lblCancel.MouseEnter += new System.EventHandler(this.lblCancel_MouseEnter);
            // 
            // FrmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Installation.Properties.Resources.MSGBack;
            this.ClientSize = new System.Drawing.Size(360, 187);
            this.ControlBox = false;
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.lblMSG);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMsg";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMsg_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMSG;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblCancel;
    }
}

