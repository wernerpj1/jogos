using System.ComponentModel.DataAnnotations;

namespace Jogos.Views.UsersViews
{
    public class UserViewInput
    {
       [Required(ErrorMessage = "O nome de usuário é obrigatório")]
       public string Nome { get; set; } 

       [Required(ErrorMessage = "Uma senha para o cadastro é obrigatório")]
       public string Senha { get; set; }

       [Required(ErrorMessage = "Um endereço de Email é obrigatório")]
       public string Email { get; set; }

       public bool IsAdmin { get; set; }
    }
}