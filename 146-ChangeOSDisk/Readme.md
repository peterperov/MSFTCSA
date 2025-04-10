
#Swap Virtual Machine OS disk 

Prototype PS script to swap the disk on a running Virtual machine. 

Steps: 

1. create and configure snapshot
2. create a new disk from snapshot 
3. stop the vm 
4. attach a disk to VM 
5. start the VM



#Links

[Change the OS disk used by an Azure VM using PowerShell](https://learn.microsoft.com/en-us/azure/virtual-machines/windows/os-disk-swap)


[Create a snapshot of a virtual hard disk](https://learn.microsoft.com/en-us/azure/virtual-machines/snapshot-copy-managed-disk?tabs=powershell)


[Create a managed disk from a snapshot with PowerShell](https://learn.microsoft.com/en-us/azure/virtual-machines/scripts/virtual-machines-powershell-sample-create-managed-disk-from-snapshot)


