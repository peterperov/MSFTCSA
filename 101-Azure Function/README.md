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


## Setting up 

Web App with .Net Core 3.1 LTS


Storage Account
created blob container -> Public Access Level: Blob (anonymous read access)
upload a file to storage container

### Functions -> Configuration

Don't forget to click "Save" to save the values

PETER_KEY
FILE_URL - url to the file uploaded to the storage container
https://ppstorage101.blob.core.windows.net/filecontainer/README.md


## Testing

Function URL 

https://ppfunction101.azurewebsites.net/api/Function1?

### SEtting up private endpoints 

Storage Account -> Networking 
Configure Private Networking connection to VNet created earlier 
Add my own ip address just for lulz

### After

After setting up private endpoints 
The function is not accessible from public internet
Nor it is accessible from VM sitting on an integrated vnet

### Troubleshooting 

"Diagnose and solve problems" link on a function page
"Function down or reporting problems" link 

"Function Executions and Errors" chapter, down at the bottom prints Stack Trace of an error


Timestamp : 5/27/2021 4:39:48 PM
Inner Exception Type: System.Net.WebException
Total Occurrences: 10
Latest Exception Message: The remote server returned an error: (403) This request is not authorized to perform this operation..

Full Exception :
 Exception while executing function: Function1 
 System.Net.WebException : The remote server returned an error: (403) This request is not authorized to perform this operation..
   at System.Net.HttpWebRequest.GetResponse()
   at System.Net.WebClient.GetWebResponse(WebRequest request)
   at System.Net.WebClient.DownloadBits(WebRequest request,Stream writeStream)
   at System.Net.WebClient.DownloadDataInternal(Uri address,WebRequest& request)
   at System.Net.WebClient.DownloadString(Uri address)
   at async _101_Azure_Function.Function1.Run(HttpRequest req,ILogger log) at W:\GITHUB\MSFTCSA\101-Azure Function\Function1.cs : 33

33             var client = new WebClient();
34            var str = client.DownloadString(url);

Strangely enuff, breakpoint line is 33, not 34 as one would guess but ok. 



## Setting up ASE

