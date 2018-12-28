[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
$form=New-Object -TypeName "System.Windows.Forms.Form"
$form.FormBorderStyle=[System.Windows.Forms.FormBorderStyle]::None
$form.StartPosition=[System.Windows.Forms.FormStartPosition]::CenterScreen
$form.Size=New-Object -TypeName "System.Drawing.Size" -ArgumentList 600,400
$form.ShowDialog()