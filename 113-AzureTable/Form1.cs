using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTableWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdAccessTable_Click(object sender, EventArgs e)
        {


            // string connectionString = ConfigurationManager.AppSettings.Get("TableStorageConnectionString");

            // primary table
            // https://ppreplicated01.table.core.windows.net/

            // secondary
            // https://ppreplicated01-secondary.table.core.windows.net/


            var connectionString = "DefaultEndpointsProtocol=https;AccountName=ppreplicated01;AccountKey=/NX5ayUr5EjUgNhwWRjXVSUqEWr/eaQ2LN4vimX47I1xB8syqqaO3ecOqEXGemven3Im7/9bwlS1Xfh0QBnFVQ==;EndpointSuffix=core.windows.net";

            ReadEntity("ppreplicated01"); 

            // cloudTable.CreateIfNotExists();
            // Console.ReadKey();

        }





        private void ReadEntity( string url )
        {
            var accessKey = "DefaultEndpointsProtocol=https;AccountName={0};AccountKey=/NX5ayUr5EjUgNhwWRjXVSUqEWr/eaQ2LN4vimX47I1xB8syqqaO3ecOqEXGemven3Im7/9bwlS1Xfh0QBnFVQ==;EndpointSuffix=core.windows.net";

            string conn = string.Format(accessKey, url);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(conn);

            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

            CloudTable cloudTable = cloudTableClient.GetTableReference("testtable");

            TableOperation tableOp = TableOperation.Retrieve<TempEntity>("part01-01", "row-001");
            TableResult tr = cloudTable.Execute(tableOp);
            var data = tr.Result as TempEntity;

            Console.WriteLine(" PartitionKey {0} RowKey {1}  Value: {2}",
                data.PartitionKey, data.RowKey,
                data.Val);
        }

        private void cmdReadSecondary_Click(object sender, EventArgs e)
        {
            var url = "ppreplicated01";

            var accessKey = "DefaultEndpointsProtocol=https;AccountName={0};AccountKey=/NX5ayUr5EjUgNhwWRjXVSUqEWr/eaQ2LN4vimX47I1xB8syqqaO3ecOqEXGemven3Im7/9bwlS1Xfh0QBnFVQ==;EndpointSuffix=core.windows.net";

            string conn = string.Format(accessKey, url);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(conn);

            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

            CloudTable cloudTable = cloudTableClient.GetTableReference("testtable");

            var options = new TableRequestOptions();
            options.LocationMode = Microsoft.WindowsAzure.Storage.RetryPolicies.LocationMode.SecondaryOnly; 

            TableOperation tableOp = TableOperation.Retrieve<TempEntity>("part01-01", "row-001");
            TableResult tr = cloudTable.Execute(tableOp, options);

            var data = tr.Result as TempEntity;

            Console.WriteLine(" PartitionKey {0} RowKey {1}  Value: {2}",
                data.PartitionKey, data.RowKey,
                data.Val);


        }
    }
    public class TempEntity : TableEntity
    {

        public TempEntity()
        {

        }

        public TempEntity(string id, string rowkey, string value)
        {
            PartitionKey = id;
            RowKey = rowkey;
            Val = value;
        }

        public string Val { get; set; }
    }


}
