using Agenda.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;
using FluentValidation;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Core.Notifications;
using System.Linq.Expressions;

namespace Agenda.Domain.Services
{
    public abstract class Service<TEntity> : AbstractValidator<TEntity>, IService<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly IDomainNotificationHandler _dnh;
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository, IDomainNotificationHandler dnh)
        {
            _repository = repository;
            _dnh = dnh;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
           return _repository.GetBy(filter);
        }

        public TEntity Insert(TEntity obj)
        {
            if (!obj.EhValido())
            {
                _dnh.NotificarValidacoesErro(obj.ValidationResult);
                return obj;
            }

            return _repository.Insert(obj);
        }

        public TEntity Update(TEntity obj)
        {
            if (!obj.EhValido())
            {
                _dnh.NotificarValidacoesErro(obj.ValidationResult);
                return obj;
            }

            return _repository.Update(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }       

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
