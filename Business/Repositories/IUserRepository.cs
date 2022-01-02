using Jogos.Business.Entities;

namespace Jogos.Business.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void Commit();
        User GetUser(string login);
    }
}
