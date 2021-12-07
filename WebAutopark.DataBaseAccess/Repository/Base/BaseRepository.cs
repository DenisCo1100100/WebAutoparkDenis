using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public abstract class BaseRepository
    {
        protected readonly DbConnection DataBase;

        protected BaseRepository(string connectionString)
        {
            DataBase = new SqlConnection(connectionString);
        }
    }
}