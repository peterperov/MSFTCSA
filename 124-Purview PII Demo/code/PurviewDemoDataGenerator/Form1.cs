using PurviewDemoDataGenerator.Worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurviewDemoDataGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGenerateNames_Click(object sender, EventArgs e)
        {
            var worker = new NamesGenerator(); 

            var list = worker.LoadData();

            worker.GenerateInserts(list); 
        }
    }
}
