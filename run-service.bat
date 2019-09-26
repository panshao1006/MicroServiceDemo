set currentDirecotry=%cd%

echo ASPNETCORE_ENVIRONMENT=Development
cd %currentDirecotry%\gateway\Gateway.API\bin\Debug\netcoreapp2.2
start "Gateway.API" dotnet Gateway.API.dll

cd %currentDirecotry%\services\user\User.API\bin\Debug\netcoreapp2.2
start "User.API" dotnet User.API.dll

cd %currentDirecotry%\services\organization\Organization.API\bin\Debug\netcoreapp2.2
start "Organizaiton.API" dotnet Organization.API.dll

cd %currentDirecotry%\services\configcenter\ConfigCenter.API\bin\Debug\netcoreapp2.2
start "ConfigCenter.API" dotnet ConfigCenter.API.dll

::start "Go.API" dotnet F:\work\github\MicroServiceDemo\services\user\User.API\bin\Debug\netcoreapp2.2\User.API.dll
pause
exit