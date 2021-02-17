namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    internal class SqlDataAccess : ISqlDataAccess
    {
        private const string CONNECTION_STRING_KEY = "DefaultConnection";

        private bool _disposed = false;

        private readonly IConfiguration _configuration;

        private SqlConnection _dbConnection;

        private SqlConnectionStringBuilder _connectionStringBuilder;

        private int ConnectionStringTimeout => _connectionStringBuilder?.ConnectTimeout ?? 600;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            SetConnectionString();
        }

        public Task<IEnumerable<T>> ExecuteQueryAsync<T>(string storedProcedure, object parameters = null)
        {
            return _dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionStringTimeout);
        }

        public Task<T> ExecuteSingleQueryAsync<T>(string storedProcedure, object parameters = null)
        {
            return _dbConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionStringTimeout);
        }

        private void SetConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(CONNECTION_STRING_KEY);

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                _dbConnection = new SqlConnection(connectionString);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbConnection?.Close();
                    _dbConnection?.Dispose();
                }

                _connectionStringBuilder = null;
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
