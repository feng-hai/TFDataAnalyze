namespace UnInstall
{
    partial class FrmUnInstall
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
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblDeleteConfig = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.lblLoadingBack = new System.Windows.Forms.Label();
            this.lblLoadingTxt = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblMark = new System.Windows.Forms.Label();
            this.lblLoadingDoing = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.lblMainTitle.Location = new System.Drawing.Point(121, 59);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(293, 30);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "测试卸载程序";
            this.lblMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.LightGray;
            this.lblClose.Image = global::UnInstall.Properties.Resources.Close2_Nor;
            this.lblClose.Location = new System.Drawing.Point(604, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(27, 27);
            this.lblClose.TabIndex = 3;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseDown);
            this.lblClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseUp);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            // 
            // lblDeleteConfig
            // 
            this.lblDeleteConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblDeleteConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeleteConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeleteConfig.Image = global::UnInstall.Properties.Resources.chk_unchecked_nor;
            this.lblDeleteConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeleteConfig.Location = new System.Drawing.Point(59, 232);
            this.lblDeleteConfig.Name = "lblDeleteConfig";
            this.lblDeleteConfig.Size = new System.Drawing.Size(356, 20);
            this.lblDeleteConfig.TabIndex = 4;
            this.lblDeleteConfig.Tag = "";
            this.lblDeleteConfig.Text = "     同时删除电脑中的用户数据和设置";
            this.lblDeleteConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeleteConfig.MouseLeave += new System.EventHandler(this.lblDeleteConfig_MouseLeave);
            this.lblDeleteConfig.Click += new System.EventHandler(this.lblDeleteConfig_Click);
            this.lblDeleteConfig.MouseEnter += new System.EventHandler(this.lblDeleteConfig_MouseEnter);
            // 
            // lblTag
            // 
            this.lblTag.BackColor = System.Drawing.Color.Transparent;
            this.lblTag.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTag.Location = new System.Drawing.Point(362, 65);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(50, 22);
            this.lblTag.TabIndex = 7;
            this.lblTag.Tag = "";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblLoadingBack
            // 
            this.lblLoadingBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lblLoadingBack.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoadingBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoadingBack.Location = new System.Drawing.Point(63, 292);
            this.lblLoadingBack.Name = "lblLoadingBack";
            this.lblLoadingBack.Size = new System.Drawing.Size(510, 8);
            this.lblLoadingBack.TabIndex = 9;
            this.lblLoadingBack.Tag = "";
            this.lblLoadingBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoadingBack.Visible = false;
            // 
            // lblLoadingTxt
            // 
            this.lblLoadingTxt.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoadingTxt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoadingTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoadingTxt.Location = new System.Drawing.Point(60, 261);
            this.lblLoadingTxt.Name = "lblLoadingTxt";
            this.lblLoadingTxt.Size = new System.Drawing.Size(180, 21);
            this.lblLoadingTxt.TabIndex = 14;
            this.lblLoadingTxt.Tag = "";
            this.lblLoadingTxt.Text = "正在卸载，请稍后...";
            this.lblLoadingTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoadingTxt.Visible = false;
            // 
            // lblOK
            // 
            this.lblOK.BackColor = System.Drawing.Color.Transparent;
            this.lblOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblOK.Image = global::UnInstall.Properties.Resources.btn3_Nor;
            this.lblOK.Location = new System.Drawing.Point(473, 363);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(76, 46);
            this.lblOK.TabIndex = 18;
            this.lblOK.Tag = "";
            this.lblOK.Text = "卸载";
            this.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOK.MouseLeave += new System.EventHandler(this.lblOK_MouseLeave);
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            this.lblOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseDown);
            this.lblOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseUp);
            this.lblOK.MouseEnter += new System.EventHandler(this.lblOK_MouseEnter);
            // 
            // lblMark
            // 
            this.lblMark.BackColor = System.Drawing.Color.Transparent;
            this.lblMark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMark.Location = new System.Drawing.Point(60, 195);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(527, 24);
            this.lblMark.TabIndex = 19;
            this.lblMark.Tag = "";
            this.lblMark.Text = "成功XXXXXXXXXXXX";
            this.lblMark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoadingDoing
            // 
            this.lblLoadingDoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblLoadingDoing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoadingDoing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoadingDoing.Location = new System.Drawing.Point(63, 292);
            this.lblLoadingDoing.Name = "lblLoadingDoing";
            this.lblLoadingDoing.Size = new System.Drawing.Size(5, 8);
            this.lblLoadingDoing.TabIndex = 20;
            this.lblLoadingDoing.Tag = "";
            this.lblLoadingDoing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoadingDoing.Visible = false;
            // 
            // lblCancel
            // 
            this.lblCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblCancel.Image = global::UnInstall.Properties.Resources.btn4_Nor;
            this.lblCancel.Location = new System.Drawing.Point(555, 363);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(76, 46);
            this.lblCancel.TabIndex = 21;
            this.lblCancel.Tag = "";
            this.lblCancel.Text = "取消";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            this.lblCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseDown);
            this.lblCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblCancel_MouseUp);
            this.lblCancel.MouseEnter += new System.EventHandler(this.lblCancel_MouseEnter);
            // 
            // lblSuccess
            // 
            this.lblSuccess.BackColor = System.Drawing.Color.Transparent;
            this.lblSuccess.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSuccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSuccess.Location = new System.Drawing.Point(0, 259);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(640, 59);
            this.lblSuccess.TabIndex = 22;
            this.lblSuccess.Tag = "";
            this.lblSuccess.Text = "你已成功卸载了产品XX。\r\n感谢你对xx的支持，欢迎下次使用。";
            this.lblSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSuccess.Visible = false;
            // 
            // FrmUnInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UnInstall.Properties.Resources.UnInstallBack;
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.ControlBox = false;
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.lblLoadingDoing);
            this.Controls.Add(this.lblLoadingBack);
            this.Controls.Add(this.lblMark);
            this.Controls.Add(this.lblLoadingTxt);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblDeleteConfig);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.lblSuccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUnInstall";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblDeleteConfig;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Label lblLoadingBack;
        private System.Windows.Forms.Label lblLoadingTxt;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.Label lblLoadingDoing;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblSuccess;
    }
}

