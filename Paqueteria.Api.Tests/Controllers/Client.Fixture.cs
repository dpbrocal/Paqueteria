using Paqueteria.Models.Dtos;

namespace Paqueteria.Api.Tests.Controllers
{
    public partial class ClientTest
    {
        public static ClientDto _dtoClient =>
            new()
            {
                Id = 2,
                Email = "pruebaClient2@hotmail.com",
                Name = "TestName2",
                Surnames = "TestSurnames2",
                NIF = "1245930L",
                Tel = "163942012",
                NumClient = "23823p"
            };
    }
}
