$1 = 1
$2 = 2
if ($1 -eq $2 - 1) {
    explorer /e,/select,c:\
}
write-host $2
Get-Alias