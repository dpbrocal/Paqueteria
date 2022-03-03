using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paqueteria.Models.Dtos;
using Paqueteria.Services.Interfaces;
using System.Collections.Generic;

namespace Paqueteria.Api.Controllers
{
    /// <summary>
    /// Order controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService">Order Service</param>
        /// <param name="mapper">Mapper</param>
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns>Order Dto</returns>
        [HttpGet("{id}")]
        public OrderDto GetOrder(int id) => _orderService.Get(id);

        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns>Collection -> Order Dto</returns> 
        [HttpGet]
        public ICollection<OrderDto> GetAll() => _mapper.Map<ICollection<OrderDto>>(_orderService.GetAll());

        /// <summary>
        /// Insert a order
        /// </summary>
        /// <param name="item">OrderDto Object</param>
        /// <returns>Order Dto</returns>
        [HttpPost]
        public OrderDto Insert([FromBody] OrderDto item) => _orderService.Insert(item);

        /// <summary>
        /// Update a order
        /// </summary>
        /// <param name="item">OrderDto Object</param>
        /// <returns>Order Dto</returns>
        [HttpPut]
        public OrderDto Update([FromBody] OrderDto item) => _orderService.Update(item);

        /// <summary>
        /// Delete a order
        /// </summary>
        /// <param name="id">Order Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _orderService.Delete(id);

    }
}
