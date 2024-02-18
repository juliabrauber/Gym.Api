
namespace Business.Abstractions.IO.User
{
    public class UserAuthOutput
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public IEnumerable<UserStoreAuthOutput> userStores { get; set; }
    }
    public class UserStoreAuthOutput
    {
        public string Name { get; set;}
        public int IdStore { get; set; }
    }
}
