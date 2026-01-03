using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //Generate a new unique user Id for the user
            user.UserId = Guid.NewGuid();

            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
        {
            return new ApplicationUser()
            {
                UserId = Guid.NewGuid(),
                Email = Email,
                Password = Password,
                PersonName = "Person name",
                Gender = GenderOptions.Male.ToString(),
            };
        }
    }
}
