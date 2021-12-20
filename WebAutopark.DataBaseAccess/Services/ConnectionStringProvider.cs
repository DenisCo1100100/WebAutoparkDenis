using Microsoft.Extensions.Configuration;

namespace WebAutopark.DataBaseAccess.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSqlConnection");
        }

        public string GetConnectionString() => _connectionString;
    }
}