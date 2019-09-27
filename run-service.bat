set currentDirecotry=%cd%

cd %currentDirecotry%\services\configcenter\ConfigCenter.API\bin\Debug\netcoreapp2.2
start "ConfigCenter.API" dotnet ConfigCenter.API.dll

::这个地方等待一下，防止配置中心还没起来，就有应用开始读配置信息
::TIMEOUT /T 30 /NOBREAK

echo ASPNETCORE_ENVIRONMENT=Development
cd %currentDirecotry%\gateway\Gateway.API\bin\Debug\netcoreapp2.2
start "Gateway.API" dotnet Gateway.API.dll

cd %currentDirecotry%\services\user\User.API\bin\Debug\netcoreapp2.2
start "User.API" dotnet User.API.dll

cd %currentDirecotry%\services\organization\Organization.API\bin\Debug\netcoreapp2.2
start "Organizaiton.API" dotnet Organization.API.dll

exit