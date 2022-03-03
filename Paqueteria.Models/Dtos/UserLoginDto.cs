
namespace Paqueteria.Models.Dtos
{
    public class UserLoginDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
