.NET Core

##building and publishing your application console

$ dotnet publish -c Release -r win10-x64

##Creating the service

$ sc create netcoreservico binpath= "C:\Lab\dotnet\WindowsServiceNetCore\Console\bin\Release\netcoreapp2.2\win10-x64\Console.exe"

##Removing the service

$ sc delete netcoreservico
