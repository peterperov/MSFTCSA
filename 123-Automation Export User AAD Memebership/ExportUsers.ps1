# storage acc acccess key 

$connectionName = "AzureRunAsConnection" 

try
{
    # Get the connection "AzureRunAsConnection "
    $servicePrincipalConnection=Get-AutomationConnection -Name $connectionName         
    "Logging in to Azure..."

	Connect-AzureAD -TenantId $servicePrincipalConnection.TenantId -ApplicationId $servicePrincipalConnection.ApplicationId -CertificateThumbprint $servicePrincipalConnection.CertificateThumbprint 

#	Connect-AzAccount `
#        -ServicePrincipal `
#        -TenantId $servicePrincipalConnection.TenantId `
#        -ApplicationId $servicePrincipalConnection.ApplicationId `
#        -CertificateThumbprint $servicePrincipalConnection.CertificateThumbprint 

}
catch {
    if (!$servicePrincipalConnection)
    {
        $ErrorMessage = "Connection $connectionName not found."
        throw $ErrorMessage
    } else{
        Write-Error -Message $_.Exception
        throw $_.Exception
    }
}


# Import-Module -Name AzureAD -Force

# Import-Module 

$key = "..."
$context = New-AzStorageContext -StorageAccountName "ppscriptstorage" -StorageAccountKey $key
$date = Get-Date -Format "yyyy-MM-dd"

"Begin Read Groups"

# export azure ad groups and members to csv (also output empty groups with 'No Members' value) 
# assumes existing connection to Azure AD using Connect-AzureAD (or use a runbook)

$allgroups = Get-AzureADGroup | select ObjectId,DisplayName

"Begin For-EACH"

foreach ( $group in $allgroups ) 
{

    $hash = @{GroupName=$group.DisplayName;Member=''}
    $groupid = $group.ObjectId
	$name = $group.DisplayName

	$filename = $name + ".csv"

	"filename: " + $filename

	# export csv into local storage
	Get-AzureADGroupMember -ObjectId $groupid | Export-csv -path $filename

	$blobfile = $date + "\" + $filename
	$blobfile

	Set-AzStorageBlobContent -Container "files" -Blob $blobfile -Context $context -File $filename
}
