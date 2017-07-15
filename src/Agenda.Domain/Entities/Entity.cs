using FluentValidation;
using FluentValidation.Results;
using System;

namespace Agenda.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool EhValido();
        public ValidationResult ValidationResult { get; protected set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataEdicao { get; private set; }
    }
}
