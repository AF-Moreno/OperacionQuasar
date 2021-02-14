namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using MercadoLibre.OperacionQuasar.Core.Repositories;
    using System.Threading.Tasks;

    internal class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }
    }
}
