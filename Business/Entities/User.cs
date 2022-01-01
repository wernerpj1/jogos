namespace Jogos.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }
    }
}