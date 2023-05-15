namespace OpenCVEnvironmentVariableEasy
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.initializationButton = new System.Windows.Forms.Button();
            this.opencvPathTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // initializationButton
            // 
            this.initializationButton.Location = new System.Drawing.Point(12, 39);
            this.initializationButton.Name = "initializationButton";
            this.initializationButton.Size = new System.Drawing.Size(462, 33);
            this.initializationButton.TabIndex = 0;
            this.initializationButton.Text = "点此自动配置环境变量";
            this.initializationButton.UseVisualStyleBackColor = true;
            this.initializationButton.Click += new System.EventHandler(this.initializationButton_Click);
            // 
            // opencvPathTextBox
            // 
            this.opencvPathTextBox.Location = new System.Drawing.Point(12, 12);
            this.opencvPathTextBox.Name = "opencvPathTextBox";
            this.opencvPathTextBox.Size = new System.Drawing.Size(462, 21);
            this.opencvPathTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 77);
            this.Controls.Add(this.opencvPathTextBox);
            this.Controls.Add(this.initializationButton);
            this.Name = "MainForm";
            this.Text = "OpenCV 文件夹应在下方文件夹中";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button initializationButton;
        private System.Windows.Forms.TextBox opencvPathTextBox;
    }
}

