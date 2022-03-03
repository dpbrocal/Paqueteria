
using AutoMapper;
using Paqueteria.Models.Dtos;
using Paqueteria.Models.Models;

namespace Paqueteria.Services.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Carrier, CarrierDto>();
            CreateMap<CarrierDto, Carrier>();

            CreateMap<Carrier, CarrierRegisterDto>();
            CreateMap<CarrierRegisterDto, Carrier>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Client, ClientRegisterDto>();
            CreateMap<ClientRegisterDto, Client>();

            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();

            CreateMap<LocationHistory, LocationHistoryDto>();
            CreateMap<LocationHistoryDto, LocationHistory>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
        }
    }
}
