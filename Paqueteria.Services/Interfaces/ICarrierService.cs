
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;

namespace Paqueteria.Services.Interfaces
{
    public interface ICarrierService
    {
        public CarrierDto Get(int id);
        public IEnumerable<Carrier> GetAll();
        public CarrierRegisterDto Update(CarrierRegisterDto item);
        public void Delete(int id);
        public LoginRequestDto FindByUsername(string username);
        public CarrierRegisterDto Register(CarrierRegisterDto item);
    }
}
