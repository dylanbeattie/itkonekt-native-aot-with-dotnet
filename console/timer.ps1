# native\HelloWorld.exe

# $winTimer = [System.Diagnostics.Stopwatch]::StartNew()

# for ($i = 1; $i -le 100; $i++) {
# 	native\HelloWorld.exe
# }
# $winTimer.Stop()
osx-arm64/HelloWorld

$macTimer = [System.Diagnostics.Stopwatch]::StartNew()

for ($i = 1; $i -le 100; $i++) {
	osx-arm64/HelloWorld
}
$macTimer.Stop()

dotnet runtime/HelloWorld.exe

$runtimeTimer = [System.Diagnostics.Stopwatch]::StartNew()

for ($i = 1; $i -le 100; $i++) {
	dotnet runtime/HelloWorld.dll
}
$runtimeTimer.Stop()

# Write-Host "Native AOT total: $($winTimer.Elapsed)"
# Write-Host "Average run time: $($winTimer.ElapsedMilliseconds / 100)ms"

Write-Host ".NET Runtime total: $($runtimeTimer.Elapsed)"
Write-Host "Average run time: $($runtimeTimer.ElapsedMilliseconds / 100)ms"

Write-Host "Native AOT total: $($macTimer.Elapsed)"
Write-Host "Average run time: $($macTimer.ElapsedMilliseconds / 100)ms"

