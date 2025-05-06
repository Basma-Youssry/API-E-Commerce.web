using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects;
using Shared.DataTransfareObjects.IdentityDTO_s;

namespace Presentation.Controllers
{
    public class AuthenticationController(IServiceManager _serviceManager) : APIBaseController
    {
        //Login
        [HttpPost("Login")] //POST BaseUrl/api/Authentecation/Login

        public async Task<ActionResult<UserDTo>> Login(LoginDTo loginDTo)
        {
            var User = await _serviceManager.AuthenticationService.LoginAsync(loginDTo);
            return Ok(User);
        }

        //Register
        [HttpPost("Register")] //POST BaseUrl/api/Authentecation/Register
        public async Task<ActionResult<UserDTo>> Register(RegisterDTo registerDTo)
        {
            var User = await _serviceManager.AuthenticationService.RegisterAsync(registerDTo);
            return Ok(User);
        }

        ////Get checkEmail
        [HttpGet("CheckEmail")] //GET BaseUrl/api/Authentication/CheckEmail
        public async Task<ActionResult<bool>> CheckEmail(string Email)
        {
            var Result = await _serviceManager.AuthenticationService.CheckEmailAsync(Email);
            return Ok(Result);
        }

        ////Get current user 
        [Authorize]
        [HttpGet("CurrentUser")] //GET BaseUrl/api/Authentication/CurrentUser
        public async Task<ActionResult<UserDTo>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var AppUser = await _serviceManager.AuthenticationService.GetCurrentUserAsync(email!);
            return Ok(AppUser);
        }

        ////Get current user Address
        [Authorize]
        [HttpGet("Address")] //GET BaseUrl/api/Authentication/Address
        public async Task<ActionResult<AddressDTo>> GettCurrentUSerAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var Address = await _serviceManager.AuthenticationService.GetCurrentUserAddressAsync(email);
            return Ok(Address);
        }

        ////Update current user address
        [Authorize]
        [HttpPut("Address")] //PUT BaseUrl/api/Authentication/Address
        public async Task<ActionResult<AddressDTo>> UpdateCurrentUserAddress(AddressDTo addressDTo)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var UpdatedAddress = await _serviceManager.AuthenticationService.UpdateCurrentUserAddressAsync(email, addressDTo);
            return Ok(UpdatedAddress);
        }
    }
}
