using System.Linq.Expressions;

namespace Query_Parameters_Versioning_And_Securing.Model
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> items, string sortBy, string sortOrder) {
            var type = typeof(TEntity);
            var expressionParameter = Expression.Parameter(type, "t");
            var property = type.GetProperty(sortBy);
            var expresion = Expression.MakeMemberAccess(expressionParameter, property);
            var lambda = Expression.Lambda(expresion, expressionParameter);
            var result = Expression.Call(
                typeof(Queryable),
                sortOrder == "desc" ? "OrderByDescending" : "OrderBy",
                new Type[] { type, property.PropertyType },
                items.Expression,
                Expression.Quote(lambda));

            return items.Provider.CreateQuery<TEntity>(result);
        }
    }
}
