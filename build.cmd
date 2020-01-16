
set version=%1
set key=%2

cd %~dp0
dotnet build magic.lambda.validators/magic.lambda.validators.csproj --configuration Release --source https://api.nuget.org/v3/index.json
dotnet nuget push magic.lambda.validators/bin/Release/magic.lambda.validators.%version%.nupkg -k %key% -s https://api.nuget.org/v3/index.json
