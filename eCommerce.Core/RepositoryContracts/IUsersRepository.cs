using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    //Contract to be implemented by UserRepository that contains data access logic of Users data store
    public interface IUsersRepository
    {
        //Method to add a user to the data store and return the added user
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        //Method to retrive existing user by their email and password
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password);
    }
}
