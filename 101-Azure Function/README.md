#101-Azure Function

##Overview

Small test project to showcase Azure Function creation. 

Second step is to allow function to access blob storage content over the private network endpoint. 


##Steps

1. Create Storage Account 
2. Create Blob Container in Storage Acc
3. Upload .txt file to storage
4. Create Azure Function with VS Community Edition 2019
5. Create Function in the portal (after that function will be available in as VS deployment option)

[How to configure Azure Functions with a virtual network](https://docs.microsoft.com/en-us/azure/azure-functions/configure-networking-how-to)


##Preparations 

1. Create Resource Group 
2. Create VNet: pprs101vnet
3. Create Storage account. Add private endpoint to pprs101vnet
4. Create FileShare on storage account
5. Added storage account VNet integration to default subnet 
6. Added my own IP address to access storage account 
7. Created Blob Storage container, and uploaded text file there
8. Tried to create Azure Function on Storage Account
    Request was failing with 403 (Forbidden)





#Further links 

[Azure-Samples/Azure-Functions-Private-Endpoints](https://github.com/Azure-Samples/Azure-Functions-Private-Endpoints)