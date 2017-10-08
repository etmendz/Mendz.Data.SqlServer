# Mendz.Data.SqlServer
Provides a generic Mendz.Data-aware context for ADO.Net-compatible access to SQL Server databases.
## Namespace
Mendz.Data.SqlServer
### Contents
Name | Description
---- | -----------
SqlServerDbDataContext | Provides the database context for an SQL Server database.
SqlServerDataSettingOption | Provides the data setting options for SQL Server access.
#### SqlServerDbDataContext
Mendz.Data.Common defines an IDbDataContext interface, which is implemented as DbDataContextBase.
SqlServerDbDataContext derives from DbDataContextBase, which requires the abstract BuildContext() method to be implemented.
The internal implementation uses Mendz.Data.DataSettingOptions to build the data context.
SqlServerDbDataContext.BuildContext() will first look for SqlServerDataSettingOption.Name.
If it's not available, it will look for SqlServerDataSettingOption.AlternativeName.

SqlServerDbDataContext assumes that appsettings.json contains an entry/section for DataSettings.
```JSON
{
    "DataSettings": {
        "ConnectionStrings": {
            "SqlServerConnectionString" : "connection string to Sql Server",
            "SqlServerExpressConnectionString" : "connection string to Sql Server express (LocalDB)"
        }
    }
}
```
In the application startup or initialization routine, the DataSettings should be loaded into DataSettingOptions as follows:
```C#
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataSettingOptions.Initialize(Configuration.GetSection("DataSettings").Get<DataSettings>());
        }
```
Mendz.Data-aware repositories implement DbRepositoryBase, which expects a Mendz.Data-aware data context.
Using Mendz.Data.SqlServer.SqlServerDbDataContext, a repository skeleton can look like the following:
```C#
    public class TestRepository : DbRepositoryBase<SqlServerDbDataContext>
    {
        ...
    }
```
Using Mendz.Data can shield the application from "knowing" about the data context.
The application does not need to reference Mendz.Data.SqlServer.
The application can reference only Mendz.Data, and the models and repositories libraries.
## NuGet It...
https://www.nuget.org/packages/Mendz.Data.SqlServer/
