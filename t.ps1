Function Test()
{
$t = Get-Process | Where {$_.Name -eq "firefox"}
Stop-Process $t
}

Test