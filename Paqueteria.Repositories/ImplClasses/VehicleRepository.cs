
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.InterfacesRep;
   
namespace Paqueteria.Repositories.ImplClasses
{
    public class VehicleRepository<T> : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DBContext context) => _context = context;
    }
}
