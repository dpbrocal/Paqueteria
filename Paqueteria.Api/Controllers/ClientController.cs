using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Client controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientService">Client Service</param>
        /// <param name="mapper">Mapper</param>
        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a client
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns>Client Dto</returns>
        [HttpGet("{id}")]
        public ClientDto GetClient(int id) => _clientService.Get(id);

        /// <summary>
        /// Get all the clients
        /// </summary>
        /// <returns>Collection -> Client Dto</returns> 
        [HttpGet]
        public ICollection<ClientDto> GetAll() => _mapper.Map<ICollection<ClientDto>>(_clientService.GetAll());

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="item">ClientDto Object</param>
        /// <returns>Client Dto</returns>
        [HttpPut]
        public ClientRegisterDto Update([FromBody] ClientRegisterDto item) 
        {
            item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            return _clientService.Update(item);
        } 

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id">Client Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _clientService.Delete(id);

    }
}
