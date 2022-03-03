using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.InterfacesRep;

namespace Paqueteria.Repositories.ImplClasses
{
    public class OrderRepository<T> : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DBContext context) => _context = context;
    }
}
