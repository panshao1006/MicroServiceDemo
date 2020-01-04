set currentDirecotry=%cd%

cd %currentDirecotry%\services\configcenter\ConfigCenter.API\bin\Debug\netcoreapp2.2
start "ConfigCenter.API" dotnet ConfigCenter.API.dll

echo ASPNETCORE_ENVIRONMENT=Development
cd %currentDirecotry%\gateway\Gateway.API\bin\Debug\netcoreapp2.2
start "Gateway.API" dotnet Gateway.API.dll

cd %currentDirecotry%\services\user\User.API\bin\Debug\netcoreapp2.2
start "User.API" dotnet User.API.dll

cd %currentDirecotry%\services\organization\Organization.API\bin\Debug\netcoreapp2.2
start "Organizaiton.API" dotnet Organization.API.dll

cd %currentDirecotry%\services\log\Log.API\bin\Debug\netcoreapp2.2
start "Log.API" dotnet Log.API.dll

cd %currentDirecotry%\services\basicdata\BasicData.Interfaces\bin\Debug\netcoreapp2.2
start "BasicData.API" dotnet BasicData.Interfaces.dll

exit