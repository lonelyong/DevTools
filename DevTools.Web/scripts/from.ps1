[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
$form=New-Object -TypeName "System.Windows.Forms.Form"
$form.FormBorderStyle=[System.Windows.Forms.FormBorderStyle]::None
$form.StartPosition=[System.Windows.Forms.FormStartPosition]::CenterScreen
$form.Size=New-Object -TypeName "System.Drawing.Size" -ArgumentList 600,400
$form.Padding=New-Object -TypeName "System.Windows.Forms.Padding" -ArgumentList 3,1,3,3
$form.BackColor=[System.Drawing.Color]::Green
$form.Text="PowerShell With DotNet"
$form.add_DoubleClick([EventHandler]{
    if ($form.WindowState -eq 'Maximized'){
        $form.WindowState='Normal'
    }
    elseif($form.WindowState -eq 'Normal'){
        $form.WindowState='Maximized'
    }
})
$form.add_SizeChanged([System.EventHandler]{
    $dgv.Height = $form.Height - 22;
});
$txt=New-Object -TypeName "System.Windows.Forms.TextBox"
#$txt.Parent=$form
$txt.Dock = [System.Windows.Forms.DockStyle]::Bottom
$txt.Multiline=$true
$txt.Height=380
$txt.Text="hello powershell!"
$txt.TextAlign=[System.Windows.Forms.HorizontalAlignment]::Center
$txt.Font=New-Object -TypeName "System.Drawing.Font" -ArgumentList "SimSun",12,'Bold','Point',134,$false
$txt.BorderStyle=[System.Windows.Forms.BorderStyle]::None

$dgv=New-Object -TypeName "System.Windows.Forms.DataGridView"
$dgv.Dock='Bottom'
$dgv.Height=380
$dgv.Parent=$form
$dgv.Dock = [System.Windows.Forms.DockStyle]::Fill

$sql="select * from tb_short_url";
$con=New-Object -TypeName "System.Data.SqlClient.SqlConnection" -ArgumentList "server=wetest.fun;database=sharing;user=sa;pwd=Lucky_2017"
$sqlcmd=New-Object -TypeName "System.Data.SqlClient.SqlCommand" -ArgumentList $sql,$con
$sqldataAdapter = New-Object -TypeName "System.Data.SqlClient.SqlDataAdapter" -ArgumentList $sqlcmd
$datatable = New-Object -TypeName "System.Data.DataTable"
$sqldataAdapter.Fill($datatable)
$dgv.DataSource=$datatable
$form.ShowDialog()