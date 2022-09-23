

$fileName = [string]::"output.txt"

$date = [DateTime]::Parse("01/01/2020")
$stopDate = [DateTime]::Parse("01/01/2025")

Write-Output (Get-Date -Format "MM/dd/yyyy")


while ($date -lt $stopDate)
{

    $date = $date.AddDays(1)

    # Write-Output  "$($date -Format 'MM/dd/yyyy')" 
    Write-Output ("{0:MM/dd/yyyy}" -f $date) | Out-File -FilePath "output.txt" -Append

}





