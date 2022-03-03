using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// LocationHistory controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class LocationHistoryController : ControllerBase
    {
        private readonly ILocationHistoryService _locationService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="locationService">Location Service</param>
        /// <param name="mapper">Mapper</param>
        public LocationHistoryController(ILocationHistoryService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a location
        /// </summary>
        /// <param name="id">Location Id</param>
        /// <returns>Location Dto</returns>
        [HttpGet("{id}")]
        public LocationHistoryDto GetLocation(int id) => _locationService.Get(id);

        /// <summary>
        /// Get all the location
        /// </summary>
        /// <returns>Collection -> LocationHistory Dto</returns> 
        [HttpGet]
        public ICollection<LocationHistoryDto> GetAll() => _mapper.Map<ICollection<LocationHistoryDto>>(_locationService.GetAll());

        /// <summary>
        /// Insert a location
        /// </summary>
        /// <param name="item">LocationHistoryDto Object</param>
        /// <returns>LocationHistory Dto</returns>
        [HttpPost]
        public LocationHistoryDto Insert([FromBody] LocationHistoryDto item) => _locationService.Insert(item);

        /// <summary>
        /// Update a location
        /// </summary>
        /// <param name="item">LocationHistoryDto Object</param>
        /// <returns>LocationHistory Dto</returns>
        [HttpPut]
        public LocationHistoryDto Update([FromBody] LocationHistoryDto item) => _locationService.Update(item);

        /// <summary>
        /// Delete a location
        /// </summary>
        /// <param name="id">LocationHistory Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _locationService.Delete(id);

    }
}
