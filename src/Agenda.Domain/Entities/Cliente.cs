using FluentValidation;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Entities
{
    public class Cliente : Entity<Cliente>
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CelularPrincipal { get; set; }
        public string CelularSecundario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Empresa { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do cliente precisa ser fornecido")
                .Length(2, 80).WithMessage("O nome do evento precisa ter entre 2 e 80 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Informe um email válido")
                .Length(8, 50).WithMessage("O email precisa ter entre 8 e 50 caracteres");

            RuleFor(x => x.Empresa)
                .Length(2, 50).WithMessage("O nome da empresa precisa ter entre 2 e 50 caracteres");

            ValidationResult = Validate(this);
        }
    }
}
