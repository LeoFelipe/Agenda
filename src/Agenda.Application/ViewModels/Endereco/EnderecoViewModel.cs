using System.ComponentModel.DataAnnotations;

namespace Agenda.Application.ViewModels.Endereco
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de {1} carcteres")]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Máximo de {1} carcteres")]
        public string Numero { get; set; }
        
        [MaxLength(150, ErrorMessage = "Máximo de {1} carcteres")]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de {1} carcteres")]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "Máximo de {1} carcteres")]
        public string Cep { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de {1} carcteres")]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de {1} carcteres")]
        public string Estado { get; set; }
    }
}
