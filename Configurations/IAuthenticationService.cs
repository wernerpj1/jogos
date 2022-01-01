

using Jogos.Views.UsersViews;

namespace Jogos.Configurations
{
    public interface IAuthenticationService
    {
        object GerarToken(UserViewOutput userViewOutput);
    }
}