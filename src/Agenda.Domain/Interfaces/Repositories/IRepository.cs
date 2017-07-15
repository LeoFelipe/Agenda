using Agenda.Domain.Core.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Get paginated list without filter
        /// </summary>
        /// <param name="initialPage">Initial Page from pagination</param>
        /// <param name="recordsPerPage"></param>
        /// <returns>Paginated list of Objects</returns>
        IQueryable<TEntity> GetAll(SortHelper order = null, int initialPage = 0, int recordsPerPage = 50);

        /// <summary>
        /// Get paginated list with filter
        /// </summary>
        /// <param name="predicate">Filter applied by user</param>
        /// <param name="initialPage">Initial Page from pagination</param>
        /// <param name="recordsPerPage"></param>
        /// <returns>Paginated list of Objects</returns>
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, SortHelper order = null, int initialPage = 0, int recordsPerPage = 50);

        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>Return a Object</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Insert a new Record into Database
        /// </summary>
        /// <param name="obj">Object to Insert</param>
        /// <returns>Object Inserted</returns>
        TEntity Insert(TEntity obj);

        /// <summary>
        /// Update a Database Record
        /// </summary>
        /// <param name="obj">Entidade a se editar na tabela</param>
        /// <returns>Object Updated</returns>
        TEntity Update(TEntity obj);

        /// <summary>
        /// Delete a Database Record
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>None Return</returns>
        void Delete(int id);

        /// <summary>
        /// Commit a Transaction
        /// </summary>
        /// <returns>Number of records entered</returns>
        int SaveChanges();
    }
}