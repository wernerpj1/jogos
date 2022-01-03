using System.ComponentModel.DataAnnotations;

namespace Jogos.Views.UsersViews
{
    public class LoginViewInput
    {
        [Required(ErrorMessage = "O Email de usu�rio � obrigat�rio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "� necess�rio digitar a senha cadastrada")]
        public string Senha { get; set; }
    }
}