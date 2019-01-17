namespace InstallWindowService
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(251, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.AllowDrop = true;
            this.txtPath.Location = new System.Drawing.Point(79, 22);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(434, 37);
            this.txtPath.TabIndex = 0;
            this.txtPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(333, 76);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(79, 76);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.Location = new System.Drawing.Point(165, 76);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnUnInstall.TabIndex = 2;
            this.btnUnInstall.Text = "UnInstall";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // txtTip
            // 
            this.txtTip.Location = new System.Drawing.Point(79, 116);
            this.txtTip.Multiline = true;
            this.txtTip.Name = "txtTip";
            this.txtTip.ReadOnly = true;
            this.txtTip.Size = new System.Drawing.Size(434, 140);
            this.txtTip.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 278);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnInstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Install Window Service";
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
    }
}

