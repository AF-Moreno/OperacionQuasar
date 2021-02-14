namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="SqlDataAccess" />.
    /// </summary>
    internal class SqlDataAccess : ISqlDataAccess
    {
        /// <summary>
        /// Defines the CONNECTION_STRING_KEY.
        /// </summary>
        private const string CONNECTION_STRING_KEY = "DefaultConnection";

        /// <summary>
        /// Defines the _disposed.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Defines the _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Defines the _dbConnection.
        /// </summary>
        private SqlConnection _dbConnection;

        /// <summary>
        /// Defines the _connectionStringBuilder.
        /// </summary>
        private SqlConnectionStringBuilder _connectionStringBuilder;

        /// <summary>
        /// Gets the ConnectionStringTimeout.
        /// </summary>
        private int ConnectionStringTimeout => _connectionStringBuilder?.ConnectTimeout ?? 600;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataAccess"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            SetConnectionString();
        }

        /// <summary>
        /// The ExecuteQueryAsync.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/>.</param>
        /// <param name="parameters">The parameters<see cref="object"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{T}}"/>.</returns>
        public Task<IEnumerable<T>> ExecuteQueryAsync<T>(string storedProcedure, object parameters = null)
        {
            return _dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionStringTimeout);
        }

        /// <summary>
        /// The ExecuteSingleQueryAsync.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/>.</param>
        /// <param name="parameters">The parameters<see cref="object"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public Task<T> ExecuteSingleQueryAsync<T>(string storedProcedure, object parameters = null)
        {
            return _dbConnection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: ConnectionStringTimeout);
        }

        /// <summary>
        /// The SetConnectionString.
        /// </summary>
        private void SetConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(CONNECTION_STRING_KEY);

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                _dbConnection = new SqlConnection(connectionString);
            }
        }

        /// <summary>
        /// The Dispose.
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/>.</param>
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

        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
