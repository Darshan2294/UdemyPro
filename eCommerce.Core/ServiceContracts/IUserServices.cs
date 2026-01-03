using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserServices
    {

        ///Method to handle user login use case and returns an AuthenticationResponse object that contains status of login///
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        //Method to handle user registration use case and returns an object of AuthenticationResponse type that represents status of user registration
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
