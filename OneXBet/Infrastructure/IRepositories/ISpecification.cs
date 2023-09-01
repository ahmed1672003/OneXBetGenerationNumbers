using System.Linq.Expressions;

namespace OneXBet.Infrastructure.IRepositories;

public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    Expression<Func<TEntity, object>> GroupBy { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    List<string> IncludesString { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }

    (Func<TEntity, object> PropertyExpression, Expression<Func<TEntity, object>> ValueExpression)
        ExecuteUpdateRequirments
    { get; }

    public (int? pageNumber, int? pageSize) PaginationRequirments { get; }

    bool IsPagingEnabled { get; }
}
