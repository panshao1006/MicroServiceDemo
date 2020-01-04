set currentDirecotry=%cd%

echo ASPNETCORE_ENVIRONMENT=Development
cd %currentDirecotry%\services\basicdata\BasicData.Interfaces\bin\Debug\netcoreapp2.2
start "BasicData.API" dotnet BasicData.Interfaces.dll
pause
exit