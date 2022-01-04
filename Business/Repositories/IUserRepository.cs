using Jogos.Business.Entities;
using System.Security.Claims;

namespace Jogos.Business.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void RemoveUser(User user);
        void UpdateUser(User user);
        void Commit();
        User GetUser(string login);
        
    }
}
