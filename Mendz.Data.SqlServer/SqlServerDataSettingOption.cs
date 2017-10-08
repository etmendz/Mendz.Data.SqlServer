namespace Mendz.Data.SqlServer
{
    /// <summary>
    /// Provides the data setting options for SQL Server access.
    /// </summary>
    public static class SqlServerDataSettingOption
    {
        /// <summary>
        /// Gets or sets the connection string name.
        /// </summary>
        public static string Name { get; set;  } = "SqlServerConnectionString";

        /// <summary>
        /// Gets or sets the alternative connection string name.
        /// </summary>
        public static string AlternativeName { get; set; }  = "SqlServerExpressConnectionString";
    }
}
