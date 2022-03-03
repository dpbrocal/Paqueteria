using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.InterfacesRep;

namespace Paqueteria.Repositories.ImplClasses
{
    public class LocationRepository<T> : BaseRepository<LocationHistory>, ILocationHistoryRepository
    {
        public LocationRepository(DBContext context) => _context = context;
    }
}
