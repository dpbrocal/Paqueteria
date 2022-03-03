
using Paqueteria.Models.Dtos;

namespace Paqueteria.Services.Interfaces
{
    public interface ILoginService
    {
        public UserLoginDto CarrierLogin(LoginRequestDto user);
        public UserLoginDto ClientLogin(LoginRequestDto user);
    }
}
