using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;
using Paqueteria.Repositories.ImplClasses;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Services.ImplClasses
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository<Client> _clientRepository;
        private readonly IMapper _mapper;
        private DBContext _context;

        public ClientService(IMapper mapper, DBContext context)
        {
            _context = context;
            _clientRepository = new ClientRepository<Client>(_context);
            _mapper = mapper;
        }

        public ClientDto Get(int id)
        {
            Client item = _clientRepository.Get(id);
            return _mapper.Map<ClientDto>(item);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public ClientRegisterDto Update(ClientRegisterDto item)
        {
            _clientRepository.Update(_mapper.Map<Client>(item));
            item.Password = null;
            return item;
        }

        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }

        public LoginRequestDto FindByUsername(string username)
        {
            return _clientRepository.FindByUsername(username);
        }

        public ClientRegisterDto Register(ClientRegisterDto item)
        {
            _clientRepository.Add(_mapper.Map<Client>(item));
            item.Password = null;

            return item;
        }
    }
}
