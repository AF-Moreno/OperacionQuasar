using MercadoLibre.OperacionQuasar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    internal interface IUserRepository: IRepository
    {
        Task<UserEntity> GetByEmailAsync(string email);
    }
}
