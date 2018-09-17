namespace MyMsg
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ipAddressText = new System.Windows.Forms.TextBox();
            this.socketText = new System.Windows.Forms.TextBox();
            this.ipPortText = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipAddressText
            // 
            this.ipAddressText.Location = new System.Drawing.Point(12, 13);
            this.ipAddressText.Name = "ipAddressText";
            this.ipAddressText.Size = new System.Drawing.Size(324, 25);
            this.ipAddressText.TabIndex = 1;
            this.ipAddressText.Text = "127.0.0.1";
            // 
            // socketText
            // 
            this.socketText.Location = new System.Drawing.Point(12, 101);
            this.socketText.Multiline = true;
            this.socketText.Name = "socketText";
            this.socketText.Size = new System.Drawing.Size(461, 252);
            this.socketText.TabIndex = 2;
            // 
            // ipPortText
            // 
            this.ipPortText.Location = new System.Drawing.Point(342, 14);
            this.ipPortText.Name = "ipPortText";
            this.ipPortText.Size = new System.Drawing.Size(131, 25);
            this.ipPortText.TabIndex = 3;
            this.ipPortText.Text = "9050";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 53);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(461, 25);
            this.txtContent.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(479, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.ipPortText);
            this.Controls.Add(this.socketText);
            this.Controls.Add(this.ipAddressText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ipAddressText;
        private System.Windows.Forms.TextBox socketText;
        private System.Windows.Forms.TextBox ipPortText;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button button2;
    }
}

