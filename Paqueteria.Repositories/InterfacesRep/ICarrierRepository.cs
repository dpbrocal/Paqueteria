using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;

namespace Paqueteria.Repositories.InterfacesRep
{
    public interface ICarrierRepository : ICRUDRepository<Carrier>
    {
        LoginRequestDto FindByUsername(string username);
    }
}
