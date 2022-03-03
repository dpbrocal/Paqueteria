using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.InterfacesRep;

namespace Paqueteria.Repositories.ImplClasses
{
    public class DeliveryRepository<T> : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(DBContext context) => _context = context;
    }
}
