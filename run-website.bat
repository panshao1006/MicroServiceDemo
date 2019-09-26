set currentDirecotry=%cd%

echo ASPNETCORE_ENVIRONMENT=Development

cd %currentDirecotry%\website\login\Login.UI\bin\Debug\netcoreapp2.1\publish\
start "Login.API" dotnet Login.UI.dll

cd %currentDirecotry%\website\my\My.UI\bin\Debug\netcoreapp2.1\publish\
start "My.API" dotnet My.UI.dll

cd %currentDirecotry%\website\static\Static.UI\bin\Debug\netcoreapp2.1\publish
start "Static.API" dotnet Static.UI.dll

exit