$nativeTimer = [System.Diagnostics.Stopwatch]::StartNew()
for ($i = 1; $i -le 100; $i++) {
	helloworld-native\HelloWorld.exe
}
$nativeTimer.Stop()

$dotnetTimer = [System.Diagnostics.Stopwatch]::StartNew()
for ($i = 1; $i -le 100; $i++) {
	helloworld-runtime\HelloWorld.exe
}
$dotnetTimer.Stop()

Write-Host "Native AOT total: $($nativeTimer.Elapsed)"
Write-Host "Average run time: $($nativeTimer.ElapsedMilliseconds / 100)ms"

Write-Host ".NET Runtime total: $($dotnetTimer.Elapsed)"
Write-Host "Average run time: $($dotnetTimer.ElapsedMilliseconds / 100)ms"




