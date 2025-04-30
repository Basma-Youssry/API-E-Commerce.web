using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Exceptions;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared.DataTransfareObjects;
using Shared.DataTransfareObjects.IdentityDTO_s;

namespace Service
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager) : IAuthenticationService
    {
        public async Task<UserDTo> LoginAsync(LoginDTo loginDTo)
        {
            //Check I Email is Exists
            var User = await _userManager.FindByEmailAsync(loginDTo.Email) ?? throw new UserNotException(loginDTo.Email);

            //Check Password
            var IsPasswordValid = await _userManager.CheckPasswordAsync(User, loginDTo.Passsword);
            if (IsPasswordValid)
                //Return UserDTo
                return new UserDTo()
                {
                    DisplayName = User.DisplayName,
                    Email = User.Email,
                    Token = CreateTokenAsync(User)
                };

            else
            {
                throw new UnauthorizedException();
            }



        }


        public async Task<UserDTo> RegisterAsync(RegisterDTo registerDTo)
        {
            //Mapping Register Dto => Application USer
            var User = new ApplicationUser()
            {
                DisplayName = registerDTo.DisplayName,
                Email = registerDTo.Email,
                PhoneNumber = registerDTo.PhoneNumber,
                UserName = registerDTo.UserName
            };

            //Create USer [Application User]
            var Result = await _userManager.CreateAsync(User, registerDTo.Passsword);
            if (Result.Succeeded)
                return new UserDTo() { DisplayName = User.DisplayName, Email = User.Email, Token = CreateTokenAsync(User) };
            else
            {
                var Errors = Result.Errors.Select(E => E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }



        private static string CreateTokenAsync(ApplicationUser user)
        {
            return "Token - TODO";
        }
    }
}
