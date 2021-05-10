# ReCapProject

> What's mean ReCapProject<br>

ReCapProject is a backend side of rent a car project.

> Which framework and programming languages were used ?

Back-end : .NET CORE <br>
Database : SQL Server <br>
Front-end : Angular [recap-angular](https://github.com/mertcancetinok/recap-angular) <br>

> How can you install ? <br>

### Setup for back-side <br>
git clone https://github.com/mertcancetinok/ReCapProject.git <br> <br>
Open project with .sln <br> <br>
Find the DataAccess/Concrete/EntityFramework/ReCapContext.cs <br> <br>

```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      optionsBuilder.UseSqlServer(@"<your connection string>);
  }
```
### Setup for database <br>

You can import database.sql to your sql server

### Setup for front-end <br> [recap-angular](https://github.com/mertcancetinok/recap-angular)
