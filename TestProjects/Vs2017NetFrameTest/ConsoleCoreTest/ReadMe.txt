Nugets:
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.Json

To create the EXE file:
editing the *.csproj with notepad.
adding <RuntimeIdentifier>win10-x64</RuntimeIdentifier> in <PropertyGroup>, showed as below:
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <StartupObject>ConsoleCoreTest.Program</StartupObject>
	<RuntimeIdentifier>win10-x64</RuntimeIdentifier>
  </PropertyGroup>

EFCore for existing DB:

import Nugets:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools

run the next command line in 'NuGet Package Manager -> Package manager console'. as below shows.
Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DBCTXT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;user id=sa;password=sa" -Force -DataAnnotations Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels
Scaffold-DbContext "Server=.;Database=Food;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Scaffold-DbContext -?		/*To Get helps.*/
-Force	/*override the existing DB classes*/
-DataAnnotations
-Tables TableA, TableB		/*to create certain tables*/


Restore DB / Code first DB:
*When code first, making protected override void OnModelCreating(ModelBuilder modelBuilder) available.
*Config the DesignTime DbContext, as followed listed

*** FoundationContext is DbContext class ***
public class DesignTimeFoundationContextFactory : IDesignTimeDbContextFactory<FoundationContext>
    {
        public FoundationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FoundationContext>();
            optionsBuilder.UseSqlServer(@"AttachDbFilename=D:\ProjectsTest\App_Data\FoundationContext.mdf;Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=FoundationContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;user id=sa;password=sa");

            return new FoundationContext(optionsBuilder.Options);
        }
    }

Then run the next command in Package manager console.
Add-Migration AName
Update-Database

--Script-Migration to create the migration T-Sql scripts



