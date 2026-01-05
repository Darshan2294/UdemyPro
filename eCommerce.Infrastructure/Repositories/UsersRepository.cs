using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        public readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dapperDb)
        {
            _dbContext = dapperDb;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //Generate a new unique user Id for the user
            user.UserId = Guid.NewGuid();


            //SQL Query to insert user data into the "Users" table
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\")VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            //Sql query to select a user by Email and Password
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
           
            var parameter = new { Email = email, Password = password };

            ApplicationUser? user = await 
            _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameter);

            return user;
        }
    }
}
