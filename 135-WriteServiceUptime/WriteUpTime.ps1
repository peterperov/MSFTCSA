#Set Variables
$ServiceName = 'SQLSERVER'
$EventSource = 'MSSQL$SQL2022'
$EventID = "1000"

#  | select name, starttime
$process = Get-Process | where {$_.ProcessName -eq "sqlservr"} 
$uptime = New-Timespan -Start $process.StartTime -End (GET-DATE)

# Write-Host $Uptime
# "The $ServiceName service has been running for $Uptime"
Write-EventLog -LogName Application -Source $EventSource -EventId $EventID -Message $Uptime

