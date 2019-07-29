dotnet restore;
dotnet build -c Release;
dotnet pack --no-build -c Release WixSharp/WixSharp.csproj;

$nupkg = (Get-ChildItem WixSharp/bin/Release/*.nupkg)[0];

# Push the nuget package to AppVeyor's artifact list.
Push-AppveyorArtifact $nupkg.FullName -FileName $nupkg.Name -DeploymentName "PrimePenguin.WixSharp.nupkg";