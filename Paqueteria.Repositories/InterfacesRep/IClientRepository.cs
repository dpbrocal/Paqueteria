using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.Common;

namespace Paqueteria.Repositories.InterfacesRep
{
    public interface IClientRepository : ICRUDRepository<Client>
    {
        LoginRequestDto FindByUsername(string username);

    }
}
