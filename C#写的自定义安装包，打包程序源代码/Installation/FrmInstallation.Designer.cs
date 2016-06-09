namespace Installation
{
    partial class FrmInstallation
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.llnkLicense = new System.Windows.Forms.LinkLabel();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblTXTBorder = new System.Windows.Forms.Label();
            this.lblGO = new System.Windows.Forms.Label();
            this.lblHighLevel = new System.Windows.Forms.Label();
            this.lblDesktopLink = new System.Windows.Forms.Label();
            this.lblStartMenuLink = new System.Windows.Forms.Label();
            this.lblStartBarLink = new System.Windows.Forms.Label();
            this.lblUserExperience = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblDoing = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.pSuccess = new System.Windows.Forms.Panel();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblStartProduct = new System.Windows.Forms.Label();
            this.pSuccess.SuspendLayout();
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
            this.lblMainTitle.Text = "测试安装程序";
            this.lblMainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblCompanyName.Location = new System.Drawing.Point(240, 331);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(394, 20);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "TEST公司";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCompanyName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.LightGray;
            this.lblClose.Image = global::Installation.Properties.Resources.Close_Nor;
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
            // lblLicense
            // 
            this.lblLicense.BackColor = System.Drawing.Color.Transparent;
            this.lblLicense.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLicense.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLicense.Location = new System.Drawing.Point(58, 168);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(356, 20);
            this.lblLicense.TabIndex = 4;
            this.lblLicense.Tag = "CHK";
            this.lblLicense.Text = "     接受                         ，请仔细阅读本软件的安装许可协议。";
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLicense.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblLicense.Click += new System.EventHandler(this.lblLicense_Click);
            this.lblLicense.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // llnkLicense
            // 
            this.llnkLicense.AutoSize = true;
            this.llnkLicense.BackColor = System.Drawing.Color.Transparent;
            this.llnkLicense.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llnkLicense.Location = new System.Drawing.Point(104, 170);
            this.llnkLicense.Name = "llnkLicense";
            this.llnkLicense.Size = new System.Drawing.Size(104, 17);
            this.llnkLicense.TabIndex = 5;
            this.llnkLicense.TabStop = true;
            this.llnkLicense.Text = "最终用户许可协议";
            this.llnkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llnkLicense_LinkClicked);
            // 
            // lblPath
            // 
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPath.Image = global::Installation.Properties.Resources.OpenDialog_Nor;
            this.lblPath.Location = new System.Drawing.Point(57, 197);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(30, 30);
            this.lblPath.TabIndex = 6;
            this.lblPath.Tag = "";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPath.MouseLeave += new System.EventHandler(this.lblPath_MouseLeave);
            this.lblPath.Click += new System.EventHandler(this.lblPath_Click);
            this.lblPath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPath_MouseDown);
            this.lblPath.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblPath_MouseUp);
            this.lblPath.MouseEnter += new System.EventHandler(this.lblPath_MouseEnter);
            // 
            // lblTag
            // 
            this.lblTag.BackColor = System.Drawing.Color.Transparent;
            this.lblTag.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTag.Image = global::Installation.Properties.Resources.tag;
            this.lblTag.Location = new System.Drawing.Point(362, 65);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(50, 22);
            this.lblTag.TabIndex = 7;
            this.lblTag.Tag = "";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.Location = new System.Drawing.Point(92, 204);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(490, 16);
            this.txtPath.TabIndex = 8;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            this.txtPath.MouseLeave += new System.EventHandler(this.txtPath_MouseLeave);
            this.txtPath.MouseEnter += new System.EventHandler(this.txtPath_MouseEnter);
            // 
            // lblTXTBorder
            // 
            this.lblTXTBorder.BackColor = System.Drawing.Color.Transparent;
            this.lblTXTBorder.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTXTBorder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTXTBorder.Image = global::Installation.Properties.Resources.txtBorder;
            this.lblTXTBorder.Location = new System.Drawing.Point(89, 198);
            this.lblTXTBorder.Name = "lblTXTBorder";
            this.lblTXTBorder.Size = new System.Drawing.Size(496, 29);
            this.lblTXTBorder.TabIndex = 9;
            this.lblTXTBorder.Tag = "";
            this.lblTXTBorder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTXTBorder.Visible = false;
            // 
            // lblGO
            // 
            this.lblGO.BackColor = System.Drawing.Color.Transparent;
            this.lblGO.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGO.Image = global::Installation.Properties.Resources.go_Nor;
            this.lblGO.Location = new System.Drawing.Point(237, 250);
            this.lblGO.Name = "lblGO";
            this.lblGO.Size = new System.Drawing.Size(155, 53);
            this.lblGO.TabIndex = 10;
            this.lblGO.Tag = "";
            this.lblGO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGO.MouseLeave += new System.EventHandler(this.lblGO_MouseLeave);
            this.lblGO.Click += new System.EventHandler(this.lblGO_Click);
            this.lblGO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblGO_MouseDown);
            this.lblGO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblGO_MouseUp);
            this.lblGO.MouseEnter += new System.EventHandler(this.lblGO_MouseEnter);
            // 
            // lblHighLevel
            // 
            this.lblHighLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblHighLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHighLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHighLevel.ForeColor = System.Drawing.Color.Blue;
            this.lblHighLevel.Image = global::Installation.Properties.Resources.dwn;
            this.lblHighLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHighLevel.Location = new System.Drawing.Point(12, 331);
            this.lblHighLevel.Name = "lblHighLevel";
            this.lblHighLevel.Size = new System.Drawing.Size(70, 20);
            this.lblHighLevel.TabIndex = 11;
            this.lblHighLevel.Text = "高级选项";
            this.lblHighLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHighLevel.Click += new System.EventHandler(this.lblHighLevel_Click);
            // 
            // lblDesktopLink
            // 
            this.lblDesktopLink.BackColor = System.Drawing.Color.Transparent;
            this.lblDesktopLink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesktopLink.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDesktopLink.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblDesktopLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDesktopLink.Location = new System.Drawing.Point(36, 375);
            this.lblDesktopLink.Name = "lblDesktopLink";
            this.lblDesktopLink.Size = new System.Drawing.Size(133, 20);
            this.lblDesktopLink.TabIndex = 12;
            this.lblDesktopLink.Tag = "CHK";
            this.lblDesktopLink.Text = "     创建桌面快捷方式";
            this.lblDesktopLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDesktopLink.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblDesktopLink.Click += new System.EventHandler(this.lblDesktopLink_Click);
            this.lblDesktopLink.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // lblStartMenuLink
            // 
            this.lblStartMenuLink.BackColor = System.Drawing.Color.Transparent;
            this.lblStartMenuLink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartMenuLink.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartMenuLink.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblStartMenuLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartMenuLink.Location = new System.Drawing.Point(36, 397);
            this.lblStartMenuLink.Name = "lblStartMenuLink";
            this.lblStartMenuLink.Size = new System.Drawing.Size(152, 20);
            this.lblStartMenuLink.TabIndex = 12;
            this.lblStartMenuLink.Tag = "CHK";
            this.lblStartMenuLink.Text = "     创建开始菜单快捷方式";
            this.lblStartMenuLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartMenuLink.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblStartMenuLink.Click += new System.EventHandler(this.lblStartMenuLink_Click);
            this.lblStartMenuLink.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // lblStartBarLink
            // 
            this.lblStartBarLink.BackColor = System.Drawing.Color.Transparent;
            this.lblStartBarLink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartBarLink.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartBarLink.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblStartBarLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartBarLink.Location = new System.Drawing.Point(36, 420);
            this.lblStartBarLink.Name = "lblStartBarLink";
            this.lblStartBarLink.Size = new System.Drawing.Size(172, 20);
            this.lblStartBarLink.TabIndex = 12;
            this.lblStartBarLink.Tag = "CHK";
            this.lblStartBarLink.Text = "     创建快速启动栏快捷方式";
            this.lblStartBarLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartBarLink.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblStartBarLink.Click += new System.EventHandler(this.lblStartBarLink_Click);
            this.lblStartBarLink.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // lblUserExperience
            // 
            this.lblUserExperience.BackColor = System.Drawing.Color.Transparent;
            this.lblUserExperience.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserExperience.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserExperience.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblUserExperience.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserExperience.Location = new System.Drawing.Point(323, 375);
            this.lblUserExperience.Name = "lblUserExperience";
            this.lblUserExperience.Size = new System.Drawing.Size(153, 20);
            this.lblUserExperience.TabIndex = 13;
            this.lblUserExperience.Tag = "CHK";
            this.lblUserExperience.Text = "     加入用户体验计划(&?)";
            this.lblUserExperience.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserExperience.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblUserExperience.Click += new System.EventHandler(this.lblUserExperience_Click);
            this.lblUserExperience.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // lblLoading
            // 
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoading.Image = global::Installation.Properties.Resources.loading;
            this.lblLoading.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoading.Location = new System.Drawing.Point(214, 220);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(180, 30);
            this.lblLoading.TabIndex = 14;
            this.lblLoading.Tag = "";
            this.lblLoading.Text = "         正在安装程序，请稍后...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoading.Visible = false;
            // 
            // lblDoing
            // 
            this.lblDoing.BackColor = System.Drawing.Color.Transparent;
            this.lblDoing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDoing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoing.Location = new System.Drawing.Point(12, 332);
            this.lblDoing.Name = "lblDoing";
            this.lblDoing.Size = new System.Drawing.Size(616, 19);
            this.lblDoing.TabIndex = 15;
            this.lblDoing.Tag = "";
            this.lblDoing.Text = "正在安装文件，请稍后...";
            this.lblDoing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoing.Visible = false;
            this.lblDoing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblSuccess
            // 
            this.lblSuccess.BackColor = System.Drawing.Color.Transparent;
            this.lblSuccess.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSuccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSuccess.Location = new System.Drawing.Point(55, 23);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(527, 24);
            this.lblSuccess.TabIndex = 16;
            this.lblSuccess.Tag = "";
            this.lblSuccess.Text = "成功XXXXXXXXXXXX";
            this.lblSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pSuccess
            // 
            this.pSuccess.BackColor = System.Drawing.Color.Transparent;
            this.pSuccess.Controls.Add(this.lblOK);
            this.pSuccess.Controls.Add(this.lblStartProduct);
            this.pSuccess.Controls.Add(this.lblSuccess);
            this.pSuccess.Location = new System.Drawing.Point(516, 59);
            this.pSuccess.Name = "pSuccess";
            this.pSuccess.Size = new System.Drawing.Size(83, 58);
            this.pSuccess.TabIndex = 17;
            this.pSuccess.Visible = false;
            this.pSuccess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // lblOK
            // 
            this.lblOK.BackColor = System.Drawing.Color.Transparent;
            this.lblOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblOK.Image = global::Installation.Properties.Resources.btn_Nor;
            this.lblOK.Location = new System.Drawing.Point(554, 125);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(56, 41);
            this.lblOK.TabIndex = 18;
            this.lblOK.Tag = "";
            this.lblOK.Text = "使用";
            this.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOK.MouseLeave += new System.EventHandler(this.lblOK_MouseLeave);
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            this.lblOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseDown);
            this.lblOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblOK_MouseUp);
            this.lblOK.MouseEnter += new System.EventHandler(this.lblOK_MouseEnter);
            // 
            // lblStartProduct
            // 
            this.lblStartProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblStartProduct.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartProduct.Image = global::Installation.Properties.Resources.chk_checked_nor;
            this.lblStartProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartProduct.Location = new System.Drawing.Point(54, 62);
            this.lblStartProduct.Name = "lblStartProduct";
            this.lblStartProduct.Size = new System.Drawing.Size(117, 20);
            this.lblStartProduct.TabIndex = 17;
            this.lblStartProduct.Tag = "CHK";
            this.lblStartProduct.Text = "     启动配置中心";
            this.lblStartProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStartProduct.MouseLeave += new System.EventHandler(this.lblLicense_MouseLeave);
            this.lblStartProduct.Click += new System.EventHandler(this.lblStartProduct_Click);
            this.lblStartProduct.MouseEnter += new System.EventHandler(this.lblLicense_MouseEnter);
            // 
            // FrmInstallation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Installation.Properties.Resources.SelectBack;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.ControlBox = false;
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.pSuccess);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.lblUserExperience);
            this.Controls.Add(this.lblStartBarLink);
            this.Controls.Add(this.lblStartMenuLink);
            this.Controls.Add(this.lblDesktopLink);
            this.Controls.Add(this.lblHighLevel);
            this.Controls.Add(this.lblGO);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.llnkLicense);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.lblTXTBorder);
            this.Controls.Add(this.lblDoing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInstallation";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.pSuccess.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.LinkLabel llnkLicense;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblTXTBorder;
        private System.Windows.Forms.Label lblGO;
        private System.Windows.Forms.Label lblHighLevel;
        private System.Windows.Forms.Label lblDesktopLink;
        private System.Windows.Forms.Label lblStartMenuLink;
        private System.Windows.Forms.Label lblStartBarLink;
        private System.Windows.Forms.Label lblUserExperience;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblDoing;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Panel pSuccess;
        private System.Windows.Forms.Label lblStartProduct;
        private System.Windows.Forms.Label lblOK;
    }
}

