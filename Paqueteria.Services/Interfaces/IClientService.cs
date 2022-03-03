
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;

namespace Paqueteria.Services.Interfaces
{
    public interface IClientService
    {
        public ClientDto Get(int id);
        public IEnumerable<Client> GetAll();
        public ClientRegisterDto Update(ClientRegisterDto item);
        public void Delete(int id);
        public LoginRequestDto FindByUsername(string username);
        public ClientRegisterDto Register(ClientRegisterDto item);
    }
}
