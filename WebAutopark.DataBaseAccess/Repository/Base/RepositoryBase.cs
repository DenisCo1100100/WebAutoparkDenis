using System;
using System.Data.Common;
using System.Data.SqlClient;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public abstract class RepositoryBase : IDisposable
    {
        protected readonly DbConnection Connection;

        protected RepositoryBase(IConnectionStringProvider connectionStringProvider)
        {
            Connection = new SqlConnection(connectionStringProvider.GetConnectionString());
        }

        public void Dispose() => Connection.Dispose();
    }
}