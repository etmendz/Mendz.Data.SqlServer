using Mendz.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Mendz.Data.SqlServer
{
    public class SqlServerDbDataContext : DbDataContextBase
    {
        /// <summary>
        /// Provides the database context for an SQL Server database.
        /// </summary>
        protected override IDbConnection BuildContext()
        {
            string name = SqlServerDataSettingOption.Name;
            if (!DataSettingOptions.ConnectionStrings.ContainsKey(SqlServerDataSettingOption.Name))
            {
                if (DataSettingOptions.ConnectionStrings.ContainsKey(SqlServerDataSettingOption.AlternativeName)) name = DataSettingOptions.ConnectionStrings[SqlServerDataSettingOption.AlternativeName];
            }
            return new SqlConnection(DataSettingOptions.ConnectionStrings[name]);
        }

        /// <summary>
        /// Creates a context asynchronously.
        /// </summary>
        /// <remarks>This method must be called explicity before accessing the Context property.
        /// By default, Context calls the synchronous CreateContext() method.
        /// </remarks>
        public async void CreateContextAsync()
        {
            if (Context == null)
            {
                Context = BuildContext();
                await ((SqlConnection)Context).OpenAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates a context asynchronously with a cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>This method must be called explicity before accessing the Context property.
        /// By default, Context calls the synchronous CreateContext() method.
        /// </remarks>
        public async void CreateContextAsync(CancellationToken cancellationToken)
        {
            if (Context == null)
            {
                Context = BuildContext();
                await ((SqlConnection)Context).OpenAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
