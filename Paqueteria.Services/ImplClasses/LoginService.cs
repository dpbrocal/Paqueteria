using AutoMapper;
using Microsoft.Extensions.Options;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using Paqueteria.Services.Security;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Paqueteria.Services.ImplClasses
{
    public class LoginService : ILoginService
    {
        private readonly ClientRepository<Client> _clientRepository;
        private readonly CarrierRepository<Carrier> _carrierRepository;
        private DBContext _context;
        private readonly JWTSettings _jwtSettings;
        public LoginService(DBContext context, IOptions<JWTSettings> jwtSettings)
        {
            _context = context;
            _clientRepository = new ClientRepository<Client>(_context);
            _carrierRepository = new CarrierRepository<Carrier>(_context);
            _jwtSettings = jwtSettings.Value;
        }

        public UserLoginDto ClientLogin(LoginRequestDto user)
        {
            LoginRequestDto userLogin = _clientRepository.FindByUsername(user.Username);
            return Login(userLogin, user);
        }

        public UserLoginDto CarrierLogin(LoginRequestDto user)
        {
            LoginRequestDto userLogin = _carrierRepository.FindByUsername(user.Username);
            return Login(userLogin, user);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private UserLoginDto Login(LoginRequestDto userLogin, LoginRequestDto user)
        {
            if (userLogin != null)
            {
                var passVerify = BCrypt.Net.BCrypt.Verify(user.Password, userLogin.Password);
                if (passVerify)
                {
                    var token = TokenGenerator.GenerateTokenJwt(user.Username, _jwtSettings);
                    var refreshToken = GenerateRefreshToken();
                    UserLoginDto result = new UserLoginDto
                    {
                        Username = userLogin.Username,
                        Token = token,
                        RefreshToken = refreshToken
                    };
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
