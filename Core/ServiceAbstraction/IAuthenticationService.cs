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
        //Take Email, Password, UserName, Display Name and Phone Number.
        //Then Return Token , Email and Display Name.

        Task<UserDTo> RegisterAsync(RegisterDTo registerDTo);


        //Check Email
        //Take string Email then return bool boolean.
        Task<bool> CheckEmailAsync(string Email);

        //GetCurrent User Address
        //Take string Email then return AddressDTO
        Task<AddressDTo> GetCurrentUserAddressAsync(string Email);

        //Update Current USer Address
        //Take AddressDTO Updated Address and string Email then return AddressDTO Address after Update.

        Task<AddressDTo> UpdateCurrentUserAddressAsync(string Email, AddressDTo addressDTo);

        //Get Current User.
        //Take string Email Then Return UserDTO Token, Email and Display Name.

        Task<UserDTo> GetCurrentUserAsync(string Email);

    }
}
