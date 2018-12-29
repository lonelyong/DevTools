[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
$form=New-Object -TypeName "System.Windows.Forms.Form"
$form.FormBorderStyle=[System.Windows.Forms.FormBorderStyle]::None
$form.StartPosition=[System.Windows.Forms.FormStartPosition]::CenterScreen
$form.Size=New-Object -TypeName "System.Drawing.Size" -ArgumentList 600,400
$form.Padding=New-Object -TypeName "System.Windows.Forms.Padding" -ArgumentList 3,1,3,3
$form.BackColor=[System.Drawing.Color]::Green
$txt=New-Object -TypeName "System.Windows.Forms.TextBox"
$txt.Parent=$form
$txt.Dock = [System.Windows.Forms.DockStyle]::Bottom
$txt.Multiline=$true
$txt.Height=380
$txt.Text="hello powershell!"
$txt.TextAlign=[System.Windows.Forms.HorizontalAlignment]::Center
#$txt.Font=New-Object -TypeName "System.Drawing.Font" -ArgumentList 
$txt.BorderStyle=[System.Windows.Forms.BorderStyle]::None
$form.ShowDialog()