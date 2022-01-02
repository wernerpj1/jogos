using Jogos.Business.Entities;
using Jogos.Business.Repositories;
using System.Linq;

namespace Jogos.Infraestruture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JogoDbContext _context;

        public UserRepository(JogoDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public User GetUser(string login)
        {
           return _context.User.FirstOrDefault(u => u.Nome == login); 
        }
    }
}
