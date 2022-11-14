
# git hub page
# https://github.com/tfitzmac/resource-capabilities

$filePath = "move-support-resources.csv"

Invoke-WebRequest -Uri "https://raw.githubusercontent.com/tfitzmac/resource-capabilities/master/move-support-resources.csv" -OutFile $filePath


$mytable = Import-CSV -Path $filePath | Group-Object -AsHashTable -Property "Resource"

$mytable["Microsoft.ApiManagement/reportfeedback"]


