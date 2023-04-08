using System.Configuration;
using System.Diagnostics;

namespace AIPlaygroundForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmd_Click(object sender, EventArgs e)
        {

            var value = GetValue("CognitiveSearchKey"); 

            Debug.WriteLine(String.Format("value: {0}", value));
        }


        public static string GetValue(string key)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = @"w:\github\github.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var value = config.AppSettings.Settings[key].Value;
            return value;
        }


    }
}