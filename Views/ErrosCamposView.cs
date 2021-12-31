using System.Collections.Generic;

namespace back.ViewModels
{
    public class ErrosCamposView
    {
        public IEnumerable<string> Erros { get; set; }

        public ErrosCamposView(IEnumerable<string> errors)
        {
            Erros = errors;
        }
    }
}