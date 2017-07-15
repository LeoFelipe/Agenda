using Agenda.Application.ViewModels.Endereco;
using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Application.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Celular Principal")]
        [MinLength(8, ErrorMessage = "Mínimo de {1} caracteres")]
        public string CelularPrincipal { get; set; }

        [Display(Name = "Celular Secundário")]
        [MinLength(8, ErrorMessage = "Mínimo de {1} caracteres")]
        public string CelularSecundario { get; set; }

        [MinLength(8, ErrorMessage = "Mínimo de {1} caracteres")]
        public string Telefone { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {1} carcteres")]
        [MinLength(8, ErrorMessage = "Mínimo de {1} caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {1} caracteres")]
        public string Empresa { get; set; }

        public bool Ativo { get; set; }

        public EnderecoViewModel Endereco { get; set; }
    }
}
