using FluentValidation;

namespace Agenda.Domain.Entities
{
    public class Endereco : Entity<Endereco>
    {
        public int EnderecoId { get; set; }
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.ClienteId)
                .NotEmpty().WithMessage("Cliente não identificado");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("O Logradouro precisa ser informado")
                .Length(150).WithMessage("O Logradouro não pode ter mais que 150 caracteres");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O Número precisa ser informado")
                .Length(20).WithMessage("O Número não pode ter mais que 20 caracteres");

            RuleFor(x => x.Complemento)
                .Length(150).WithMessage("O Complemento não pode ter mais que 20 caracteres");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O Bairro precisa ser informado")
                .Length(50).WithMessage("O Bairro não pode ter mais que 50 caracteres");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O Cep precisa ser informado")
                .Length(8, 8).WithMessage("O Cep deve ter 8 caracteres");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A Cidade precisa ser informada")
                .Length(50).WithMessage("A Cidade não pode ter mais que 50 caracteres");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O Estado precisa ser informado")
                .Length(50).WithMessage("O Estado não pode ter mais que 50 caracteres");

            ValidationResult = Validate(this);
        }
    }
}
