using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Library.Infra.Repository.DbConfiguration
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IOptions<DataSettings> dataSettings;

        protected string ConnectionString => !string.IsNullOrEmpty(dataSettings.Value.DefaultConnection) ?
                                                     dataSettings.Value.DefaultConnection :
                                                     DatabaseConnection.ConnectionConfiguration
                                                                       .GetConnectionString("DefaultConnection");

        public IDbConnection GetDbConnection => new SqlConnection(ConnectionString);

        public DatabaseFactory(IOptions<DataSettings> dataSettings)
        {
            this.dataSettings = dataSettings;
        }
    }
}