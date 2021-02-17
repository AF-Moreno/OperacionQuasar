namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ISqlDataAccess" />.
    /// </summary>
    internal interface ISqlDataAccess : IDisposable
    {
        /// <summary>
        /// The ExecuteQueryAsync.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/>.</param>
        /// <param name="parameters">The parameters<see cref="object"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{T}}"/>.</returns>
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string storedProcedure, object parameters = null);

        /// <summary>
        /// The ExecuteSingleQueryAsync.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/>.</param>
        /// <param name="parameters">The parameters<see cref="object"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        Task<T> ExecuteSingleQueryAsync<T>(string storedProcedure, object parameters = null);
    }
}
