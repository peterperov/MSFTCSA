
namespace TestApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAccessBlobFile = new System.Windows.Forms.Button();
            this.cmdWriteConsole = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdWriteConsole);
            this.groupBox1.Controls.Add(this.cmdAccessBlobFile);
            this.groupBox1.Location = new System.Drawing.Point(36, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cmdAccessBlobFile
            // 
            this.cmdAccessBlobFile.Location = new System.Drawing.Point(20, 95);
            this.cmdAccessBlobFile.Name = "cmdAccessBlobFile";
            this.cmdAccessBlobFile.Size = new System.Drawing.Size(159, 29);
            this.cmdAccessBlobFile.TabIndex = 0;
            this.cmdAccessBlobFile.Text = "Access Blob";
            this.cmdAccessBlobFile.UseVisualStyleBackColor = true;
            this.cmdAccessBlobFile.Click += new System.EventHandler(this.cmdAccessBlobFile_Click);
            // 
            // cmdWriteConsole
            // 
            this.cmdWriteConsole.Location = new System.Drawing.Point(20, 50);
            this.cmdWriteConsole.Name = "cmdWriteConsole";
            this.cmdWriteConsole.Size = new System.Drawing.Size(159, 29);
            this.cmdWriteConsole.TabIndex = 1;
            this.cmdWriteConsole.Text = "Write Console";
            this.cmdWriteConsole.UseVisualStyleBackColor = true;
            this.cmdWriteConsole.Click += new System.EventHandler(this.cmdWriteConsole_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAccessBlobFile;
        private System.Windows.Forms.Button cmdWriteConsole;
    }
}

