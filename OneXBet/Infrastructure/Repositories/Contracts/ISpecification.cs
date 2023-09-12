using System.Linq.Expressions;

namespace OneXBet.Infrastructure.Repositories.Contracts;

public interface ISpecification<TEntity> where TEntity : class
{
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

    bool IsSatisfiedBy(TEntity entity);

    ISpecification<TEntity> And(ISpecification<TEntity> left, ISpecification<TEntity> right);
    ISpecification<TEntity> Or(ISpecification<TEntity> left, ISpecification<TEntity> right);
    ISpecification<TEntity> Not(ISpecification<TEntity> specification);
}
