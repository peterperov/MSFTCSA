namespace AzureTranslateDemo
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
            groupBox1 = new GroupBox();
            cmdTranslate = new Button();
            label2 = new Label();
            selTo = new selCountries();
            label1 = new Label();
            selFrom = new selCountries();
            cmdTest = new Button();
            txtInput = new TextBox();
            groupBox2 = new GroupBox();
            txtOutput = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdTranslate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(selTo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(selFrom);
            groupBox1.Controls.Add(cmdTest);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1031, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // cmdTranslate
            // 
            cmdTranslate.Location = new Point(528, 33);
            cmdTranslate.Name = "cmdTranslate";
            cmdTranslate.Size = new Size(115, 26);
            cmdTranslate.TabIndex = 8;
            cmdTranslate.Text = "Translate";
            cmdTranslate.UseVisualStyleBackColor = true;
            cmdTranslate.Click += cmdTranslate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 39);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 7;
            label2.Text = "To";
            // 
            // selTo
            // 
            selTo.Location = new Point(306, 33);
            selTo.Name = "selTo";
            selTo.Size = new Size(203, 28);
            selTo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 5;
            label1.Text = "From";
            // 
            // selFrom
            // 
            selFrom.Location = new Point(50, 33);
            selFrom.Name = "selFrom";
            selFrom.Size = new Size(203, 28);
            selFrom.TabIndex = 4;
            // 
            // cmdTest
            // 
            cmdTest.Location = new Point(1324, 72);
            cmdTest.Name = "cmdTest";
            cmdTest.Size = new Size(75, 23);
            cmdTest.TabIndex = 3;
            cmdTest.Text = "test";
            cmdTest.UseVisualStyleBackColor = true;
            cmdTest.Click += cmdTest_Click;
            // 
            // txtInput
            // 
            txtInput.Dock = DockStyle.Bottom;
            txtInput.Location = new Point(3, 76);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(1025, 221);
            txtInput.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtOutput);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 300);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1031, 308);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output";
            // 
            // txtOutput
            // 
            txtOutput.Dock = DockStyle.Bottom;
            txtOutput.Location = new Point(3, 47);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(1025, 258);
            txtOutput.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 608);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtInput;
        private GroupBox groupBox2;
        private TextBox txtOutput;
        private Button cmdTest;
        private selCountries selFrom;
        private Label label1;
        private Label label2;
        private selCountries selTo;
        private Button cmdTranslate;
    }
}