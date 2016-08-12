namespace OpenrestyTool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mainMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "OpenrestyTool for win";
            this.notifyIcon.Visible = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem,
            this.toolStripSeparator1,
            this.startServerMenuItem,
            this.stopServerMenuItem,
            this.restartMenuItem,
            this.configServerMenuItem,
            this.toolStripSeparator2,
            this.showLogMenuItem,
            this.clearLogMenuItem,
            this.toolStripSeparator3,
            this.exitMenuItem});
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(153, 220);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutMenuItem.Text = "关 于";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // startServerMenuItem
            // 
            this.startServerMenuItem.Name = "startServerMenuItem";
            this.startServerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startServerMenuItem.Text = "启动 Nginx";
            this.startServerMenuItem.Click += new System.EventHandler(this.startServerMenuItem_Click);
            // 
            // stopServerMenuItem
            // 
            this.stopServerMenuItem.Name = "stopServerMenuItem";
            this.stopServerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopServerMenuItem.Text = "关停 Nginx";
            this.stopServerMenuItem.Click += new System.EventHandler(this.stopServerMenuItem_Click);
            // 
            // configServerMenuItem
            // 
            this.configServerMenuItem.Name = "configServerMenuItem";
            this.configServerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configServerMenuItem.Text = "打开配置目录";
            this.configServerMenuItem.Click += new System.EventHandler(this.configServerMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // showLogMenuItem
            // 
            this.showLogMenuItem.Name = "showLogMenuItem";
            this.showLogMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showLogMenuItem.Text = "查看日志";
            this.showLogMenuItem.Click += new System.EventHandler(this.showLogMenuItem_Click);
            // 
            // clearLogMenuItem
            // 
            this.clearLogMenuItem.Name = "clearLogMenuItem";
            this.clearLogMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearLogMenuItem.Text = "清空日志";
            this.clearLogMenuItem.Click += new System.EventHandler(this.clearLogMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "退 出";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // restartMenuItem
            // 
            this.restartMenuItem.Name = "restartMenuItem";
            this.restartMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartMenuItem.Text = "重启 Nginx";
            this.restartMenuItem.Click += new System.EventHandler(this.restartMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Openresty工具";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showLogMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartMenuItem;
    }
}

