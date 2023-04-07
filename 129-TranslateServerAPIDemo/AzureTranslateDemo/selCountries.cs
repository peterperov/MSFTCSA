using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTranslateDemo
{
    public partial class selCountries : UserControl
    {

        List<Item> _countries = new List<Item>()
        {
            new Item{ Text = "English", Value = "en" },
            new Item{ Text = "Deutch", Value = "de" },
            new Item{ Text = "French", Value = "fr" },
            new Item{ Text = "Spanish", Value = "es" },
            new Item{ Text = "Italian", Value = "it" }
        };

        public selCountries()
        {
            InitializeComponent();

            InitUI();


        }

        public void InitUI()
        {
            comboBox1.DataSource = _countries;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
        }

        public string SelectedValue
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }

        public string SelectedText
        {
            get
            {
                return comboBox1.SelectedText.ToString();
            }
        }

    }


    public class Item
    {
        public Item() { }

        public string Value { set; get; }
        public string Text { set; get; }
    }
}
