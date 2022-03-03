
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Login controller
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ICarrierService _carrierService;
        private readonly ILoginService _loginService;
        private readonly IMemoryCache _memoryCache;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientService">Client Service</param>
        /// <param name="carrierService">Carrier Service</param>
        /// <param name="loginService">Login Service</param>
        /// <param name="memoryCache">Memory cache</param>
        public LoginController(IClientService clientService, ICarrierService carrierService, ILoginService loginService, IMemoryCache memoryCache)
        {
            _clientService = clientService;
            _carrierService = carrierService;
            _memoryCache = memoryCache;
            _loginService = loginService;
        }

        /// <summary>
        /// Client Authentication
        /// </summary>
        /// <param name="login">Login</param>
        [HttpPost]
        [Route("clientauthenticate")]
        public IActionResult ClientAuthenticate([FromBody] LoginRequestDto login)
        {
            if (login == null)
                return BadRequest("Invalid user request");
            try
            {
                UserLoginDto user = _loginService.ClientLogin(login);
               
                _memoryCache.Set(user.RefreshToken, user.Token, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60)).SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
                return Ok(user.Token);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Carrier Authentication
        /// </summary>
        /// <param name="login">Login</param>
        [HttpPost]
        [Route("carrierauthenticate")]
        public IActionResult CarrierAuthenticate([FromBody] LoginRequestDto login)
        {
            if (login == null)
                return BadRequest("Invalid user request");
            try
            {
                UserLoginDto user = _loginService.CarrierLogin(login);

                _memoryCache.Set(user.RefreshToken, user.Token, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60)).SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
                return Ok(user.Token);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }


        /// <summary>
        /// Client register
        /// </summary>
        /// <param name="user">user</param>
        [HttpPost]
        [Route("clientregister")]
        public IActionResult ClientRegister([FromBody] ClientRegisterDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _clientService.Register(user);
            return Ok("Register OK");
        }

        /// <summary>
        /// Carrier register
        /// </summary>
        /// <param name="user">user</param>
        [HttpPost]
        [Route("carrierregister")]
        public IActionResult CarrierRegister([FromBody] CarrierRegisterDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _carrierService.Register(user);
            return Ok("Register OK");
        }
    }
}
