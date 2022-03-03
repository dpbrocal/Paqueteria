using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;
using Paqueteria.Repositories.InterfacesRep;
using System.Linq;

namespace Paqueteria.Repositories.ImplClasses
{
    public class CarrierRepository<T> : BaseRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(DBContext context) => _context = context;

        public LoginRequestDto FindByUsername(string username)
        {
            return _context.Users.Where(x => x.Username == username).Select(x => new LoginRequestDto
            {
                Username = x.Username,
                Password = x.Password
            }).FirstOrDefault();
        }
    }
}
