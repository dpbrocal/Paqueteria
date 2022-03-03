using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paqueteria.Services.ImplClasses
{
    public class LocationHistoryService : ILocationHistoryService
    {
        private readonly LocationRepository<LocationHistory> _locationRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public LocationHistoryService(IMapper mapper, DBContext context)
        {
            _context = context;
            _locationRepository = new LocationRepository<LocationHistory>(_context);
            _mapper = mapper;
        }

        public LocationHistoryDto Get(int id)
        {
            LocationHistory item = _locationRepository.Get(id);
            return _mapper.Map<LocationHistoryDto>(item);
        }

        public IEnumerable<LocationHistory> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public LocationHistoryDto Insert(LocationHistoryDto item)
        {
            _locationRepository.Add(_mapper.Map<LocationHistory>(item));
            return item;
        }


        public async Task InsertASync(LocationHistoryDto item)
        {
            await _locationRepository.AddAsync(_mapper.Map<LocationHistory>(item));
        }

        public LocationHistoryDto Update(LocationHistoryDto item)
        {
            _locationRepository.Update(_mapper.Map<LocationHistory>(item));
            return item;
        }

        public void Delete(int id)
        {
            _locationRepository.Delete(id);
        }
    }
}
