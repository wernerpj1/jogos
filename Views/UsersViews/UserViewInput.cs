using System.ComponentModel.DataAnnotations;

namespace Jogos.Views.UsersViews
{
    public class UserViewInput
    {
       [Required(ErrorMessage = "O nome de usuário é obrigatório")]
       public string Nome { get; set; } 
       [Required(ErrorMessage = "O nome de usuário é obrigatório")]
       public string Senha { get; set; }
       public string Email { get; set; }
       public bool IsAdmin { get; set; }
    }
}