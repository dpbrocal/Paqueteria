using Paqueteria.Models.Dtos;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class CarrierTest
    {
        public static CarrierDto _dtoCarrier =>
            new()
            {
                Id = 2,
                Email = "prueba2@hotmail.com",
                Name = "TestName2",
                Surnames = "TestSurnNames2",
                NIF = "1245930J",
                Tel = "653432237",
                Licence = "923742P"
            };
    }
}
