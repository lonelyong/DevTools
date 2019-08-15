param(
    # Parameter help description
    [Switch]
    [Parameter(Mandatory=$False)]
    [Alias('e')]$enc,
    # Parameter help description
    [Switch]
    [Parameter(Mandatory=$False)]
    [Alias('d')]$dec,    
    # Parameter help description
    [Switch]
    [Parameter(Mandatory=$False)]
    [Alias('cp')]$clip,
    # Parameter help description
    [Parameter(Mandatory=$True)]
    [Alias('f')]
    [string]$file=$(throw "Parameter missing: -f File")
)
Write-Host 'Encoding:UTF-8'
Write-Host 'CD：'$pwd
$ErrorActionPreference='Stop'
[System.Reflection.Assembly]::LoadWithPartialName('System');
if(![string]::IsNullOrEmpty($file)){
    $file=Resolve-Path -Path $file
    if([System.IO.File]::Exists($file)){
        Write-Host '输入文件路径：'$file
        if($enc){
            $efile = $file + '.base64'
            $fsr = New-Object -TypeName 'System.IO.FileStream' -ArgumentList $file,Open,Read
            $bytes = [byte[]]::new($fsr.Length)
            $fsr.Read($bytes, 0, $fsr.Length);
            $fsr.Dispose();
            $fsw = [System.IO.FileStream]::new($efile, [System.IO.FileMode]::CreateNew, [System.IO.FileAccess]::Write)
            $base64Str = [Convert]::ToBase64String($bytes);
            $bytes = [System.Text.Encoding]::UTF8.GetBytes($base64Str)
            $fsw.Write($bytes, 0, $bytes.Length)
            $fsw.Flush()
            $fsw.Dispose()
            if($clip){
                $base64Str | clip.exe
                Write-Host '已复制到剪切板'
            }
            Write-Host '输出文件路径'：$efile
        }
        elseif ($dec) {
            $bytes = [Convert]::FromBase64String([System.IO.File]::ReadAllText($file));
            $direcotry = [System.IO.Path]::GetDirectoryName($file);
            $fileName = [System.IO.Path]::GetFileNameWithoutExtension($file);
            $dfile = $direcotry + '\' + $fileName;
            $fs = New-Object -TypeName 'System.IO.FileStream' -ArgumentList $dfile,CreateNew,Write
            $fs.Write($bytes, 0, $bytes.Length);
            $fs.Flush();
            $fs.Dispose()
            if($clip){
                $base64Str = [System.Text.Encoding]::UTF8.GetString($bytes);
                $base64Str | clip.exe
                Write-Host '已复制到剪切板'
            }
            Write-Host '输出文件路径'：$dfile
        }
        else{
            Write-Output '未指定参数 -e 或 -d'
        }
    }
    else{
        Write-Host '指定的输入文件不存在'
    }
}
else{
    Write-Host '未指定输入文件路径'
}