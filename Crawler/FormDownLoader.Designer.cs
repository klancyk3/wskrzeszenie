namespace Crawler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.inBox = new System.Windows.Forms.TextBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.textLog = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.textResults = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxPathRunner = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.tabLog.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inBox
            // 
            this.inBox.Location = new System.Drawing.Point(12, 8);
            this.inBox.Name = "inBox";
            this.inBox.Size = new System.Drawing.Size(506, 20);
            this.inBox.TabIndex = 1;
            // 
            // textYear
            // 
            this.textYear.Location = new System.Drawing.Point(607, 7);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(49, 20);
            this.textYear.TabIndex = 7;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.textLog);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(873, 319);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLog.Location = new System.Drawing.Point(3, 3);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLog.Size = new System.Drawing.Size(867, 313);
            this.textLog.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Controls.Add(this.tabResult);
            this.tabControl1.Location = new System.Drawing.Point(0, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 345);
            this.tabControl1.TabIndex = 5;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.textResults);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(873, 319);
            this.tabResult.TabIndex = 2;
            this.tabResult.Text = "results";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // textResults
            // 
            this.textResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResults.HideSelection = false;
            this.textResults.Location = new System.Drawing.Point(3, 3);
            this.textResults.Multiline = true;
            this.textResults.Name = "textResults";
            this.textResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textResults.Size = new System.Drawing.Size(867, 313);
            this.textResults.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "download starty";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxPathRunner
            // 
            this.textBoxPathRunner.Location = new System.Drawing.Point(12, 35);
            this.textBoxPathRunner.Name = "textBoxPathRunner";
            this.textBoxPathRunner.Size = new System.Drawing.Size(506, 20);
            this.textBoxPathRunner.TabIndex = 9;
            this.textBoxPathRunner.Text = "https://www.maratonypolskie.pl/mp_index.php?dzial=2&action=72";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(620, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Download Traces";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 403);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxPathRunner);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textYear);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.inBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inBox;
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TextBox textResults;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxPathRunner;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
    }
}

