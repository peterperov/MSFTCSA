
namespace AzureTableWinForm
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
            this.cmdAccessTable = new System.Windows.Forms.Button();
            this.cmdReadSecondary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdAccessTable
            // 
            this.cmdAccessTable.Location = new System.Drawing.Point(30, 36);
            this.cmdAccessTable.Name = "cmdAccessTable";
            this.cmdAccessTable.Size = new System.Drawing.Size(174, 64);
            this.cmdAccessTable.TabIndex = 0;
            this.cmdAccessTable.Text = "Read Primary";
            this.cmdAccessTable.UseVisualStyleBackColor = true;
            this.cmdAccessTable.Click += new System.EventHandler(this.cmdAccessTable_Click);
            // 
            // cmdReadSecondary
            // 
            this.cmdReadSecondary.Location = new System.Drawing.Point(30, 130);
            this.cmdReadSecondary.Name = "cmdReadSecondary";
            this.cmdReadSecondary.Size = new System.Drawing.Size(174, 64);
            this.cmdReadSecondary.TabIndex = 1;
            this.cmdReadSecondary.Text = "Read Secondary";
            this.cmdReadSecondary.UseVisualStyleBackColor = true;
            this.cmdReadSecondary.Click += new System.EventHandler(this.cmdReadSecondary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdReadSecondary);
            this.Controls.Add(this.cmdAccessTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAccessTable;
        private System.Windows.Forms.Button cmdReadSecondary;
    }
}

