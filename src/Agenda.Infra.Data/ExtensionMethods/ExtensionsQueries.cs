using Agenda.Domain.Core.Helpers;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Infra.Data.ExtensionMethods
{
    public static class ExtensionsQueries
    {
        /// <summary>
        /// Generate Paginated List
        /// </summary>
        /// <param name="order">Ordem da Lista</param>
        /// <param name="initialPage">Página Inicial (Valor Padrão => [ 0 ])</param>
        /// <param name="recordsPerPage">Quantidade de Registros por Página (Valor Padrão => [ 50 ])</param>
        /// <returns>Retorna uma lista paginada</returns>
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, SortHelper order = null, int initialPage = 0, int recordsPerPage = 50)
        {
            IOrderedQueryable<T> queryOrdered = null;
            
            // Ordenation
            if (order == null || order.GetFieldOrder() == null || string.IsNullOrEmpty(order.GetFieldOrder().FieldName))
                queryOrdered = query.OrderByMemberDescending(string.Concat(typeof(T).Name, "Id"));
            else
            {
                if (order.GetFieldOrder().FieldTypeOrderBy == "DESC")
                    queryOrdered = query.OrderByMemberDescending(order.GetFieldOrder().FieldName);
                else
                    queryOrdered = query.OrderByMember(order.GetFieldOrder().FieldName);

                foreach (var then in order.GetFieldsThen())
                {
                    if (then.FieldTypeThenBy == "DESC")
                        queryOrdered = queryOrdered.ThenByMemberDescending(then.FieldName);
                    else
                        queryOrdered = queryOrdered.ThenByMember(then.FieldName);
                }
            }

            // Pagination
            if (initialPage > 0)
                initialPage--;

            if (recordsPerPage > 100)
                recordsPerPage = 100;

            return queryOrdered.Skip(initialPage * recordsPerPage).Take(recordsPerPage);
        }

        /// <summary>
        /// Ordena os elementos da sequência na ordem ascendente pelo atributo parametrizado
        /// </summary>
        /// <param name="memberPath">Atibuto para ordenar</param>
        /// <returns>Uma lista ordenada pelo atributo informado</returns>
        public static IOrderedQueryable<T> OrderByMember<T>(this IQueryable<T> source, string memberPath)
        {
            return source.OrderByMemberUsing(memberPath, "OrderBy");
        }

        /// <summary>
        /// Ordena os elementos da sequência na ordem descendente pelo atributo parametrizado
        /// </summary>
        /// <param name="memberPath">Atibuto para ordenar</param>
        /// <returns>Uma lista ordenada ascendentemente pelo atributo informado</returns>
        public static IOrderedQueryable<T> OrderByMemberDescending<T>(this IQueryable<T> source, string memberPath)
        {
            return source.OrderByMemberUsing(memberPath, "OrderByDescending");
        }

        /// <summary>
        /// Adiciona mais atributos na ordenação ascendente
        /// </summary>
        /// <param name="memberPath">Atibuto para ordenar</param>
        /// <returns>Uma lista ordenada ascendentemente pelos atributos informados</returns>
        public static IOrderedQueryable<T> ThenByMember<T>(this IOrderedQueryable<T> source, string memberPath)
        {
            return source.OrderByMemberUsing(memberPath, "ThenBy");
        }

        /// <summary>
        /// Adiciona mais atributos na ordenação descendente
        /// </summary>
        /// <param name="memberPath">Atibuto para ordenar</param>
        /// <returns>Uma lista ordenada descendentemente pelos atributos informados</returns>
        public static IOrderedQueryable<T> ThenByMemberDescending<T>(this IOrderedQueryable<T> source, string memberPath)
        {
            return source.OrderByMemberUsing(memberPath, "ThenByDescending");
        }

        private static IOrderedQueryable<T> OrderByMemberUsing<T>(this IQueryable<T> source, string memberPath, string method)
        {
            var entity = Expression.Parameter(typeof(T), "item");
            var attribute = memberPath.Split('.').Aggregate((Expression)entity, Expression.PropertyOrField);
            var keySelector = Expression.Lambda(attribute, entity);
            var methodCall = Expression.Call(
                typeof(Queryable), method, new[] { entity.Type, attribute.Type },
                source.Expression, Expression.Quote(keySelector)
            );
            var cq = (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCall);
            return cq;
        }
    }
}
