using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;

namespace Paqueteria.Services.Interfaces
{
    public interface IVehicleService
    {
        public VehicleDto Get(int id);
        public IEnumerable<Vehicle> GetAll();
        public VehicleDto Insert(VehicleDto item);
        public VehicleDto Update(VehicleDto item);
        public void Delete(int id);
    }
}
