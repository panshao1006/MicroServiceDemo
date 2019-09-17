echo ASPNETCORE_ENVIRONMENT=Development
cd F:\work\github\MicroServiceDemo\gateway\Gateway.API\bin\Debug\netcoreapp2.2
start "Gateway.API" dotnet Gateway.API.dll

cd F:\work\github\MicroServiceDemo\services\user\User.API\bin\Debug\netcoreapp2.2
start "User.API" dotnet User.API.dll

cd F:\work\github\MicroServiceDemo\website\login\Login.UI\bin\Release\netcoreapp2.1\publish\
start "Login.API" dotnet Login.UI.dll

cd F:/work/github/MicroServiceDemo/website/my/My.UI/bin/Release/netcoreapp2.1/publish/
start "My.API" dotnet My.UI.dll

cd F:\work\github\MicroServiceDemo\website\static\Static.UI\bin\Debug\netcoreapp2.1\publish
start "Static.API" dotnet Static.UI.dll

::start "Go.API" dotnet F:\work\github\MicroServiceDemo\services\user\User.API\bin\Debug\netcoreapp2.2\User.API.dll

exit