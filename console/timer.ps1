native\HelloWorld.exe

$nativeTimer = [System.Diagnostics.Stopwatch]::StartNew()

for ($i = 1; $i -le 100; $i++) {
	native\HelloWorld.exe
}
$nativeTimer.Stop()

runtime\HelloWorld.exe

$runtimeTimer = [System.Diagnostics.Stopwatch]::StartNew()

for ($i = 1; $i -le 100; $i++) {
	runtime\HelloWorld.exe
}
$runtimeTimer.Stop()

Write-Host "Native AOT total: $($nativeTimer.Elapsed)"
Write-Host "Average run time: $($nativeTimer.ElapsedMilliseconds / 100)ms"

Write-Host ".NET Runtime total: $($runtimeTimer.Elapsed)"
Write-Host "Average run time: $($runtimeTimer.ElapsedMilliseconds / 100)ms"