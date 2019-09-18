set currentDirecotry=%cd%

echo ASPNETCORE_ENVIRONMENT=Development
cd %currentDirecotry%\gateway\Gateway.API\bin\Debug\netcoreapp2.2
start "Gateway.API" dotnet Gateway.API.dll

cd %currentDirecotry%\services\user\User.API\bin\Debug\netcoreapp2.2
start "User.API" dotnet User.API.dll

cd %currentDirecotry%\website\login\Login.UI\bin\Debug\netcoreapp2.1\publish\
start "Login.API" dotnet Login.UI.dll

cd %currentDirecotry%\website\my\My.UI\bin\Debug\netcoreapp2.1\publish\
start "My.API" dotnet My.UI.dll

cd %currentDirecotry%\website\static\Static.UI\bin\Debug\netcoreapp2.1\publish
start "Static.API" dotnet Static.UI.dll

::start "Go.API" dotnet F:\work\github\MicroServiceDemo\services\user\User.API\bin\Debug\netcoreapp2.2\User.API.dll
pause
exit