set currentDirecotry=%cd%

echo ASPNETCORE_ENVIRONMENT=Development

cd %currentDirecotry%\website\login\Login.UI\bin\Debug\netcoreapp2.1\publish\
start "Login.Site" dotnet Login.UI.dll

cd %currentDirecotry%\website\my\My.UI\bin\Debug\netcoreapp2.1\publish\
start "My.Site" dotnet My.UI.dll

cd %currentDirecotry%\website\static\Static.UI\bin\Debug\netcoreapp2.1\publish
start "Static.Site" dotnet Static.UI.dll

cd %currentDirecotry%\website\go\Go.UI\bin\Debug\netcoreapp2.2\publish
start "Go.Site" dotnet Go.UI.dll

exit