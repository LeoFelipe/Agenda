using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agenda.Domain.Interfaces.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Get paginated list without filter
        /// </summary>
        /// <returns>Paginated list of Objects</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get paginated list with filter
        /// </summary>
        /// <param name="filter">Filter applied by user</param>
        /// <returns>Paginated list of Objects</returns>
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);

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
    }
}