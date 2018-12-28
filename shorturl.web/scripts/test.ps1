$1=1;$2=2;$3=3;$4=0x4;
Write-Host (1kb / 1mb)
Write-Host $env:Path
Write-Host (0xfff)
if ($1 + 1 -eq $2) {
    Write-Host "$1 + 1 = $2"
}
get-alias | where {$_.Definition.StartsWith("Remove")} | group Definition | sort -Descending Name | ft Name,Definition
function sayhello {
    [CmdletBinding(DefaultParameterSetName="A")]
    param (
        [Parameter(ParameterSetName="A", Mandatory=$true)]
        $name
    )
    Write-Host hello, $name
}
sayhello  -name where
function average([double[]]$args) {

    if($args.Count -eq 0){
        Write-Host "至少需要一个参数"
        return
    }
    $sum = 0
    $args | foreach{$sum += $_}
    Write-Host ($sum / $args.Length)
}
average(1,2,3)
$obj = New-Object -TypeName System.DateTime
Write-Host $obj.ToString("yyyy-MM-dd hh:mm:ss")
$sb = New-Object -TypeName System.Text.StringBuilder
$sb.Append("i").Append("am").Append("stringbuilder")
Write-Host($sb.ToString())
Write-Host ([System.Text.RegularExpressions.Regex]::IsMatch("123","\d"))
[System.Text.RegularExpressions.Regex].GetConstructors() | foreach{Write-Host $_ }
[System.DateTime] | Get-Member -MemberType method -Static | foreach{Write-Host $_ }
$chrome = Get-Process -Name chrome
$chrome | foreach { Write-Host $_.CPU }
Get-Command -Name "get-*"
Get-Alias | % {$_ -eq "?"; Write-Host $_}
Get-Alias | where {$_.Name -eq "ac"}|foreach{Write-Host $_.GetType().Name}
Get-FileHash -Path "C:\kamo\WxPaycert\1336019501.p12" -Algorithm MD5
Get-Variable
New-Variable num -Value 100 -Force -Option readonly
#variable:虚拟驱动器
Test-Path variable:$_
ls variable:
$false
