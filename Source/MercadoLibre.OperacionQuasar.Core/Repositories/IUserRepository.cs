namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUserRepository" />.
    /// </summary>
    internal interface IUserRepository : IRepository
    {
        /// <summary>
        /// The GetByEmailAsync.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{UserEntity}"/>.</returns>
        Task<UserEntity> GetByEmailAsync(string email);
    }
}
