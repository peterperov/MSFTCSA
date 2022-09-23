

Write-Output "Logging into Azure subscription using Az cmdlets..."
    
$connectionName = "AzureRunAsConnection"

try
{
    # Get the connection "AzureRunAsConnection "
    $servicePrincipalConnection=Get-AutomationConnection -Name $connectionName         

    Add-AzAccount `
        -ServicePrincipal `
        -TenantId $servicePrincipalConnection.TenantId `
        -ApplicationId $servicePrincipalConnection.ApplicationId `
        -CertificateThumbprint $servicePrincipalConnection.CertificateThumbprint 
    
    Write-Output "Successfully logged into Azure subscription using Az cmdlets..."
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


#Get all VMs that should be part of the Schedule:
$VMs = Get-AzResource -ResourceType "Microsoft.Compute/VirtualMachines" -TagName "Operational-Schedule" -TagValue "Yes"


foreach ($vm in $VMs) {

    Write-Output "Found $($VM.Name)..."

}


