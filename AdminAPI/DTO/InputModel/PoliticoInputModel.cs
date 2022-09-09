using System.ComponentModel.DataAnnotations;

namespace AdminAPI.DTO.InputModel
{
    public class PoliticoInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve possuir de {2} ate {1} Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve possuir de {2} ate {1} Caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Entre com um numero válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Partido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cargo { get; set; }
    }
}