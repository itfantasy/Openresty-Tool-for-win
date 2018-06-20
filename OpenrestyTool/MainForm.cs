using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OpenrestyTool
{
    public partial class MainForm : Form
    {
        AboutForm aboutForm;

        string confPath
        {
            get
            {
                return OS.exePath + "conf\\";
            }
        }

        string luaPath
        {
            get
            {
                return OS.exePath + "lua\\";
            }
        }

        string logPath
        {
            get
            {
                return OS.exePath + "logs\\";
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region ------------> 窗体初始化

            Form.CheckForIllegalCrossThreadCalls = false;
            this.Hide();
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;
            this.aboutForm = new AboutForm();

            if (OS.CheckProcessExist("nginx"))
            {
                startServerMenuItem.Enabled = false;
                stopServerMenuItem.Enabled = true;
            }
            else
            {
                stopServerMenuItem.Enabled = false;
                startServerMenuItem.Enabled = true;
            }

            #endregion
        }

        private void startServerMenuItem_Click(object sender, EventArgs e)
        {
            startNginxService();
        }

        private void stopServerMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                //OS.Execute("nginx -s quit");
                OS.Execute("taskkill /im nginx.exe /f");
                int count = 0;
                while (true)
                {
                    if (!OS.CheckProcessExist("nginx"))
                    {
                        MessageBox.Show("服务已成功关停!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stopServerMenuItem.Enabled = false;
                        startServerMenuItem.Enabled = true;
                        return;
                    }
                    Thread.Sleep(1000);
                    count++;
                    if (count >= 30)
                    {
                        MessageBox.Show("服务未能成功关停!请检测相关配置...", "ERR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }).Start();
        }

        private void showLogMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                OS.Execute(String.Format("start {0}bin_tools\\baretail\\baretail.exe {0}logs\\access.log {0}logs\\error.log", OS.exePath));
            }).Start();
        }

        private void configServerMenuItem_Click(object sender, EventArgs e)
        {
            OS.ExeFile(confPath);
        }

        private void lusMenuItem_Click(object sender, EventArgs e)
        {
            OS.ExeFile(luaPath);
        }

        private void clearLogMenuItem_Click(object sender, EventArgs e)
        {
            if (!OS.CheckProcessExist("nginx"))
            {
                if (MessageBox.Show("确定要清空日志吗?该操作不可恢复!", "警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    FileIOUtil.CreateFile(logPath + "access.log", "");
                    FileIOUtil.CreateFile(logPath + "error.log", "");
                }
            }
            else
            {
                MessageBox.Show("请先关停服务!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            OS.KillProcess("OpenrestyTool");
            Application.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void restartMenuItem_Click(object sender, EventArgs e)
        {
            if (OS.CheckProcessExist("nginx"))
            {
                //OS.Execute("nginx -s quit");
                OS.Execute("taskkill /im nginx.exe /f");
            }
            startNginxService(1);
        }

        private void startNginxService(int mod=0)
        {
            new Thread(() =>
            {
                int count = 0;
                while (true)
                {
                    if (OS.CheckProcessExist("nginx"))
                    {
                        if (mod == 0)
                        {
                            MessageBox.Show("服务已成功启动!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("服务已成功重启!", "提示!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        startServerMenuItem.Enabled = false;
                        stopServerMenuItem.Enabled = true;
                        return;
                    }
                    Thread.Sleep(1000);
                    count++;
                    if (count >= 10)
                    {
                        MessageBox.Show("服务未能成功启动!请检测相关配置...", "ERR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }).Start();

            new Thread(() =>
            {
                OS.Execute("nginx");
            }).Start();
        }

        
    }
}
