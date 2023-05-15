using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVEnvironmentVariableEasy
{
    public partial class MainForm : Form
    {
        Config pathConfig;
        string opencvPath;
        List<string> pathList;
        public MainForm()
        {
            InitializeComponent();
        }

        public string[] GetPathArray(EnvironmentVariableTarget evt)
        {
            return Environment.GetEnvironmentVariable("PATH", evt).Split(';');
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pathConfig = new Config("config.txt");
            pathList = pathConfig.GetDirectories();

            opencvPath = Application.StartupPath;
            opencvPathTextBox.Text = opencvPath;

            foreach(var i in pathList)
            {
                string targetPath = opencvPath + i;
                if (!Directory.Exists(targetPath) && !File.Exists(targetPath))
                {
                    MessageBox.Show(string.Format("路径 {0} 不存在！\n请检查是否未经解压便运行本程序，或本程序同目录下不存在该目录。\n\n路径错误，程序即将退出。", targetPath), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void initializationButton_Click(object sender, EventArgs e)
        {
            try
            {
                initializationButton.Enabled = false;
                initializationButton.Text = "正在配置 PATH 环境变量中，请稍等...";
                Application.DoEvents();

                List<string> PATHuser = new List<string>(this.GetPathArray(EnvironmentVariableTarget.User));

                Application.DoEvents();
                List<string> PATHmach = new List<string>(this.GetPathArray(EnvironmentVariableTarget.Machine));

                foreach (var i in pathList)
                {
                    string targetPath = opencvPath + i;
                    PATHuser.Add(targetPath);
                    PATHmach.Add(targetPath);
                    Application.DoEvents();
                }

                PATHuser = PATHuser.Distinct().ToList(); // 去重
                PATHuser.RemoveAll(string.IsNullOrEmpty); // 去空 
                Application.DoEvents();

                PATHmach = PATHmach.Distinct().ToList(); // 去重
                PATHmach.RemoveAll(string.IsNullOrEmpty); // 去空 
                Application.DoEvents();

                string PATHUserString = "";
                string PATHMachString = "";

                foreach (var i in PATHuser)
                {
                    PATHUserString += i + ";";
                    Application.DoEvents();
                }

                foreach (var i in PATHmach)
                {
                    PATHMachString += i + ";";
                    Application.DoEvents();
                }

                Environment.SetEnvironmentVariable("PATH", PATHUserString, EnvironmentVariableTarget.User);
                Application.DoEvents();
                Environment.SetEnvironmentVariable("PATH", PATHMachString, EnvironmentVariableTarget.Machine);

                initializationButton.Text = "正在执行自动化配置脚本中，请稍等...";
                Application.DoEvents();

                List<string> commands = pathConfig.GetCommands();
                foreach (var i in commands)
                {
                    System.Diagnostics.Process.Start("cmd.exe", " /c " + i);
                    Application.DoEvents();
                }

                this.Text = "Author 255(GitHub @255doesnotexist)";
                initializationButton.Text = "配置成功！重启您的计算机以应用更改。";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("在配置过程中发生致命错误。\n\n{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
