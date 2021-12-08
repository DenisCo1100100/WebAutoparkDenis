using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public abstract class ConnectionRepository : IDisposable
    {
        protected readonly DbConnection DataBaseConnection;

        protected ConnectionRepository(string connectionString)
        {
            DataBaseConnection = new SqlConnection(connectionString);
        }

        public void Dispose() => DataBaseConnection.Dispose();
    }
}