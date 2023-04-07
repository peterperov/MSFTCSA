
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AzureTranslateDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitUI();
        }


        public void InitUI()
        {

            var str = @"
Mont-Saint-Michel[3] (French pronunciation: ​[lə mɔ̃ sɛ̃ miʃɛl]; Norman: Mont Saint Miché; English: Saint Michael's Mount) is a tidal island and mainland commune in Normandy, France.

The island[4] lies approximately one kilometre (one-half nautical mile) off the country's north-western coast, at the mouth of the Couesnon River near Avranches and is 7 hectares (17 acres) in area. The mainland part of the commune is 393 hectares (971 acres) in area so that the total surface of the commune is 400 hectares (990 acres).[5][6] As of 2019, the island had a population of 29.[7]

The commune's position—on an island just a few hundred metres from land—made it accessible at low tide to the many pilgrims to its abbey, but defensible as an incoming tide stranded, drove off, or drowned would-be assailants. The island remained unconquered during the Hundred Years' War; a small garrison fended off a full attack by the English in 1433.[8] Louis XI recognised the reverse benefits of its natural defence and turned it into a prison. The abbey was used regularly as a prison during the Ancien Régime.

Mont-Saint-Michel and its surrounding bay were inscribed on the UNESCO list of World Heritage Sites in 1979 for its unique aesthetic and importance as a Catholic site.[9] It is visited by more than three million people each year. Over 60 buildings within the commune are protected in France as monuments historiques.[10]
";
            txtInput.Text = str;
        }


        private async void cmdTranslate_Click(object sender, EventArgs e)
        {
            cmdTranslate.Enabled = false;

            string text = txtInput.Text;

            string to = selTo.SelectedValue;
            string from = selFrom.SelectedValue;

            Debug.WriteLine("from {0}, to {1}", from, to); 


            var task = TranslateWorker.Translate(text, from, to);
            string output = await task;

            var str = output.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });

            var document = JObject.Parse(str);


            // document.RootElement.TryGetProperty("text", out var translated); 

            string translated = (string)document.SelectToken("translations[0].text");

            txtOutput.Text = translated;

            cmdTranslate.Enabled = true;

        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            JObject o = JObject.Parse(@"{
  'Stores': [
    'Lambton Quay',
    'Willis Street'
  ],
  'Manufacturers': [
    {
      'Name': 'Acme Co',
      'Products': [
        {
          'Name': 'Anvil',
          'Price': 50
        }
      ]
    },
    {
      'Name': 'Contoso',
      'Products': [
        {
          'Name': 'Elbow Grease',
          'Price': 99.95
        },
        {
          'Name': 'Headlight Fluid',
          'Price': 4
        }
      ]
    }
  ]
}");

            string name = (string)o.SelectToken("Manufacturers[0].Name");

            Debug.WriteLine(name);
            // Acme Co

            decimal productPrice = (decimal)o.SelectToken("Manufacturers[0].Products[0].Price");

            Debug.WriteLine(productPrice);
            // 50

            string productName = (string)o.SelectToken("Manufacturers[1].Products[0].Name");

            Debug.WriteLine(productName);
            // Elbow Grease
        }
    }
}