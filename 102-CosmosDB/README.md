
# CosmosDB playground 

(Sample data for CosmosDB)[https://github.com/Azure-Samples/azure-cosmos-db-sample-data]


(Importing data)[https://docs.microsoft.com/en-us/azure/cosmos-db/import-data]


Sample Queries in Notebooks: 

    %%sql --database SampleDB --container SampleDb
    SELECT * from c

Note the syntax for fields that got whitespace in the name 

    %%sql --database SampleDB --container SampleDb
    SELECT c["Volcano Name"] from c

