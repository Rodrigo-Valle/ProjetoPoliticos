using System.ComponentModel.DataAnnotations;

namespace AdminAPI.DTO.InputModel
{
    public class ProcessoInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public int Politico { get; set; }
    }
}