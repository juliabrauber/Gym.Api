
namespace Business.Abstractions.IO.User
{
    public class UserInsertInput
    {
        public int? IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public long? PhoneNumber { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateRegister { get; set; }
    }
}
