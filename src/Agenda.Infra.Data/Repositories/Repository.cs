using Agenda.Domain.Core.Helpers;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infra.Data.Context;
using Agenda.Infra.Data.ExtensionMethods;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AgendaContext ctx;
        protected DbSet<TEntity> db;

        public Repository(AgendaContext context)
        {
            ctx = context;
            db = ctx.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(SortHelper order = null, int initialPage = 0, int recordsPerPage = 50)
        {
            return db.Pagination(order, initialPage, recordsPerPage);
        }

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, SortHelper order = null, int initialPage = 0, int recordsPerPage = 50)
        {
            var query = db.Where(predicate);
            var x = query.Pagination(order, initialPage, recordsPerPage);
            return x;
        }

        public virtual TEntity GetById(int id)
        {
            return db.Find(id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            return db.Add(obj);
        }

        public virtual TEntity Update(TEntity obj)
        {
            db.Attach(obj);
            ctx.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public virtual void Delete(int id)
        {
            db.Remove(db.Find(id));
        }

        public int SaveChanges()
        {
            return ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
