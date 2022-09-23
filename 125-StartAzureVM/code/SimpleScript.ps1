Import-Module Az.Compute
Import-Module Az.Accounts


$ErrorActionPreference = "Stop"
try {
    # Connect-AZAccount

    Login-AzAccount

    # peterperov@captainazure.net Microsoft Azure Sponsorship 2 898202d7-d82b-41e1-9345-591f0901ad82 AzureCloud
    # Set-AzContext

}
catch {
    Write-Host "$($_.Exception.Message)" -BackgroundColor DarkRed
}

Write-Output "getting VMs"

#Get all VMs that should be part of the Schedule:
$VMs = Get-AzResource -ResourceType "Microsoft.Compute/VirtualMachines" `
     -TagName "demo" -TagValue "true"


foreach ($vm in $VMs) {

    Write-Output "Starting $($VM.Name)..."

    Start-AzureVM $vm

}


