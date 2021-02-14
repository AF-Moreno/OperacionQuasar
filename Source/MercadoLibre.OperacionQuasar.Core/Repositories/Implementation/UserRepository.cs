using MercadoLibre.OperacionQuasar.Core.DataAccess;
using MercadoLibre.OperacionQuasar.Core.Entities;
using System.Threading.Tasks;

namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public UserRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<UserEntity> GetByEmailAsync(string email)
        {
            string storedProcedure = "[dbo].[sp_UserGetByEmail]";
            var parameters = new
            {
                Email = email
            };

            return _dataAccess.ExecuteSingleQueryAsync<UserEntity>(storedProcedure, parameters);
        }
    }
}
