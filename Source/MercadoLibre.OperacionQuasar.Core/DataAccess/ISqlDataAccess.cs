using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    internal interface ISqlDataAccess : IDisposable
    {
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string storedProcedure, object parameters = null);

        Task<T> ExecuteSingleQueryAsync<T>(string storedProcedure, object parameters = null);
    }
}
