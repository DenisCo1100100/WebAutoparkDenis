using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly DbConnection DataBase;

        protected BaseRepository(string connectionString)
        {
            DataBase = new SqlConnection(connectionString);
        }

        public void Dispose() => DataBase.Dispose();
    }
}