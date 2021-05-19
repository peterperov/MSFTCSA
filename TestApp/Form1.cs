using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdAccessBlobFile_Click(object sender, EventArgs e)
        {
            var url = "https://msftcsa.blob.core.windows.net/functiontest/README.md";

            var client = new WebClient(); 

            var str = client.DownloadString(url);

            // Console.Clear(); 
            Debug.WriteLine(str); 


        }

        private void cmdWriteConsole_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LINE!!!!");

            System.Diagnostics.Debug.WriteLine("Debug.WriteLine !!!!"); 
        }
    }
}
