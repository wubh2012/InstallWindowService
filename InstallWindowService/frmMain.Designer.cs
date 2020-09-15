namespace InstallWindowService
{
    partial class frmMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUnInstall = new System.Windows.Forms.Button();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInstallByCmd = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnGetServiceName = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(273, 83);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 25);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "路径:";
            // 
            // txtPath
            // 
            this.txtPath.AllowDrop = true;
            this.txtPath.Location = new System.Drawing.Point(73, 37);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(506, 40);
            this.txtPath.TabIndex = 0;
            this.txtPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(369, 83);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(72, 83);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(87, 25);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "安装";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.Location = new System.Drawing.Point(173, 83);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(87, 25);
            this.btnUnInstall.TabIndex = 2;
            this.btnUnInstall.Text = "卸载";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // txtTip
            // 
            this.txtTip.Location = new System.Drawing.Point(72, 289);
            this.txtTip.Multiline = true;
            this.txtTip.Name = "txtTip";
            this.txtTip.ReadOnly = true;
            this.txtTip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTip.Size = new System.Drawing.Size(624, 289);
            this.txtTip.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(71, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "请使用管理员身份运行！";
            // 
            // btnInstallByCmd
            // 
            this.btnInstallByCmd.Location = new System.Drawing.Point(72, 116);
            this.btnInstallByCmd.Name = "btnInstallByCmd";
            this.btnInstallByCmd.Size = new System.Drawing.Size(116, 25);
            this.btnInstallByCmd.TabIndex = 10;
            this.btnInstallByCmd.Text = "使用命令行安装";
            this.btnInstallByCmd.UseVisualStyleBackColor = true;
            this.btnInstallByCmd.Click += new System.EventHandler(this.btnInstallByCmd_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 196);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(506, 87);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "提示：\r\n删除服务 sc delete 服务名 \r\n启动服务 net start 服务名 \r\n停止服务 net stop 服务名\r\n\r\n%SystemRoot%/" +
    "Microsoft.NET/Framework/v4.0.30319/InstallUtil.exe";
            // 
            // btnGetServiceName
            // 
            this.btnGetServiceName.Location = new System.Drawing.Point(205, 116);
            this.btnGetServiceName.Name = "btnGetServiceName";
            this.btnGetServiceName.Size = new System.Drawing.Size(116, 25);
            this.btnGetServiceName.TabIndex = 12;
            this.btnGetServiceName.Text = "获取服务名";
            this.btnGetServiceName.UseVisualStyleBackColor = true;
            this.btnGetServiceName.Click += new System.EventHandler(this.btnGetServiceName_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "日志:";
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Courier New", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(72, 152);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(506, 22);
            this.txtCommand.TabIndex = 14;
            this.txtCommand.Text = "net start mssqlserver";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(609, 149);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(87, 25);
            this.btnExecute.TabIndex = 15;
            this.btnExecute.Text = "执行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "CMD命令:";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnExecute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 592);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetServiceName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnInstallByCmd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnInstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows服务安装助手";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInstallByCmd;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnGetServiceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label4;
    }
}

