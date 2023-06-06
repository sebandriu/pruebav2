# pruebav2
Segundo commit con cambio a EntityFramework y trabajando con C#

A)	Agregamos las siguientes dependencias desde NuGet Package Manager: 
1.	dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.16
2.	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.16
3.	dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.16
4.	dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.16
5.	dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.10

B)	Realizamos la instalación de las herramientas de EntityFramework
1.	dotnet tool install --global dotnet-ef --version 6.0.4
2.	dotnet tool install -g dotnet-aspnet-codegenerator --version 6.0.4
