using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects;
using Shared.DataTransfareObjects.IdentityDTO_s;

namespace ServiceAbstraction
{
    public interface IAuthenticationService
    {
        //Login
        //Take Email and Password then return Token, Email and DisplayName.
        Task<UserDTo> LoginAsync(LoginDTo loginDTo);


        //Register
        //Take Email, Password, UserName, Display Name and Phone Number
        //Then Return Token , Email and Display Name.

        Task<UserDTo> RegisterAsync(RegisterDTo registerDTo);

    }
}
