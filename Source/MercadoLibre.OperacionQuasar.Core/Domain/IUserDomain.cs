namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUserDomain" />.
    /// </summary>
    public interface IUserDomain : IDomain
    {
        /// <summary>
        /// The GetUserByEmailAsync.
        /// </summary>
        /// <param name="email">The email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{UserEntity}"/>.</returns>
        Task<UserEntity> GetUserByEmailAsync(string email);
    }
}
