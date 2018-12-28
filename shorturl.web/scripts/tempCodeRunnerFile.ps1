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