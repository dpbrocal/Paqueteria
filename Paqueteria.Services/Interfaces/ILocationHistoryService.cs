
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paqueteria.Services.Interfaces
{
    public interface ILocationHistoryService
    {
        public LocationHistoryDto Get(int id);
        public IEnumerable<LocationHistory> GetAll();
        public LocationHistoryDto Insert(LocationHistoryDto item);
        public LocationHistoryDto Update(LocationHistoryDto item);
        public Task InsertASync(LocationHistoryDto item);
        public void Delete(int id);
    }
}
