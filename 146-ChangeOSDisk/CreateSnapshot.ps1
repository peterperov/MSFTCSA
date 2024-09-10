# *****************
# Create snapshot
# *****************

$resourceGroupName = 'pp-rs-VHDChange' 
$location = 'northeurope' 
$vmName = 'ppvhd'
$snapshotName = 'mySnapshot'  


$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName

$snapshot =  New-AzSnapshotConfig -SourceUri $vm.StorageProfile.OsDisk.ManagedDisk.Id -Location $location -CreateOption copy

New-AzSnapshot -Snapshot $snapshot -SnapshotName $snapshotName -ResourceGroupName $resourceGroupName 

$snapshot = Get-AzSnapshot -ResourceGroupName $resourceGroupName


# *****************
# Create disk from snapshot
# *****************

#Provide the name of the Managed Disk
$diskName = 'ppvmnewdisk01'
$diskSize = '128'
$location = 'northeurope'

# Standard_LRS
# Premium_LRS
# StandardSSD_LRS
# UltraSSD_LRS
# Premium_ZRS
# StandardSSD_ZRS
$skuName = 'StandardSSD_LRS'


#If you're creating a Premium SSD v2 or an Ultra Disk, add "-Zone $zone" to the end of the command
$diskConfig = New-AzDiskConfig -SkuName $skuName -Location $location -CreateOption Copy -SourceResourceId $snapshot[0].Id -DiskSizeGB $diskSize -Zone $vm.Zones[0] 
 
$newdisk = New-AzDisk -Disk $diskConfig -ResourceGroupName $resourceGroupName -DiskName $diskName


# ****************
# swap the vm disk
# ****************

$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName 

Stop-AzVM -ResourceGroupName $resourceGroupName -Name $vm.Name -Force

Set-AzVMOSDisk -VM $vm -ManagedDiskId $newdisk.Id -Name $newdisk.Name 

Update-AzVM -ResourceGroupName $resourceGroupName -VM $vm 


# ****************
# Start vm
# ****************

Start-AzVM -Name $vm.Name -ResourceGroupName $resourceGroupName