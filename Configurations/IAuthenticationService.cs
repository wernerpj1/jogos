

using Jogos.Views.UsersViews;

namespace Jogos.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(UserViewOutput userViewOutput);
    }
}