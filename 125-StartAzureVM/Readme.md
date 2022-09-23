


PowerShell Modules Location 



$env:PSModulePath -split ';'


Get list of *Authentication assemblies and locations: 

[System.AppDomain]::CurrentDomain.GetAssemblies() | ForEach-object { if($_.location -like "*Authentication*") {write-host $_.location}}



Get installed Az Modules: 


(Get-InstalledModule -Name 'Az' -AllVersions -ErrorAction SilentlyContinue)


Uninstall bunch of modules

Get-Module -ListAvailable | Where-Object {$_.Name -like 'AzureRM*'} | Uninstall-Module


