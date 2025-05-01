using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var User = _serviceManager.AuthenticationService.LoginAsync(loginDTo);
            return Ok(User);
        }

        //Register
        [HttpPost("Register")] //POST BaseUrl/api/Authentecation/Register
        public async Task<ActionResult<UserDTo>> Register(RegisterDTo registerDTo)
        {
            var User = await _serviceManager.AuthenticationService.RegisterAsync(registerDTo);
            return Ok(User);
        }
    }
}
