namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    /// <summary>
    /// Defines the <see cref="ICacheDataAccess" />.
    /// </summary>
    internal interface ICacheDataAccess
    {
        /// <summary>
        /// The TryGet.
        /// </summary>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryGet(string pKeyName, out object pCachedData);

        /// <summary>
        /// The TryGet.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="T"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryGet<T>(string pKeyName, out T pCachedData);

        /// <summary>
        /// The TryAdd.
        /// </summary>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryAdd(string pKeyName, object pCachedData);

        /// <summary>
        /// The TryAdd.
        /// </summary>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="object"/>.</param>
        /// <param name="pCacheHours">The pCacheHours<see cref="double"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryAdd(string pKeyName, object pCachedData, double pCacheHours);

        /// <summary>
        /// The TryAddOrUpdate.
        /// </summary>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryAddOrUpdate(string pKeyName, object pCachedData);

        /// <summary>
        /// The TryAddOrUpdate.
        /// </summary>
        /// <param name="pKeyName">The pKeyName<see cref="string"/>.</param>
        /// <param name="pCachedData">The pCachedData<see cref="object"/>.</param>
        /// <param name="pCacheHours">The pCacheHours<see cref="double"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryAddOrUpdate(string pKeyName, object pCachedData, double pCacheHours);
    }
}
