using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApi.Api.Services;
using BankApi.Api.Dtos;


namespace BankApi.Api.Controllers
{
    [ApiController]
    [Route("bankApi/")]
    public class AuthController : ControllerBase
    {
     
        [HttpGet("login")]
        public ActionResult<ResultDto> Login(LoginDto loginDto)
        {
            AuthService authService = new AuthService();
            return authService.Login(loginDto);
        }

        [HttpGet("")]
        public string Hi()
        {
           string myHi = "Hello World!";
            return myHi;
        }

    }
}
