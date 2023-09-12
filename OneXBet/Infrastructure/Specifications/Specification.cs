using System.Linq.Expressions;

using OneXBet.Infrastructure.Repositories.Contracts;
using OneXBet.Infrastructure.Specifications.Expressions;

namespace OneXBet.Infrastructure.Specifications;

public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public Specification()
    {
        PaginationRequirments = (1, 10);
    }
    public List<Expression<Func<TEntity, object>>> Includes { get; private set; }
        = new List<Expression<Func<TEntity, object>>>();

    public List<string> IncludesString { get; private set; } = new List<string>();

    public Expression<Func<TEntity, object>> OrderBy { get; private set; }

    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

    public (Func<TEntity, object> PropertyExpression, Expression<Func<TEntity, object>> ValueExpression) ExecuteUpdateRequirments { get; private set; }

    public (int? pageNumber, int? pageSize) PaginationRequirments { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    public Expression<Func<TEntity, object>> GroupBy { get; private set; }

    protected virtual void AddIncludes(
                          Expression<Func<TEntity, object>> include) =>
       Includes.Add(include);
    protected virtual void AddIncludesString(
                           string includesString) =>
        IncludesString.Add(includesString);

    protected virtual void AddOrderBy(
                           Expression<Func<TEntity, object>> orderBy) =>
        OrderBy = orderBy;
    protected virtual void AddOrderByDescending(
                           Expression<Func<TEntity, object>> orderByDescending) =>
        OrderByDescending = orderByDescending;
    protected virtual void AddExecuteUpdate(
                            (Func<TEntity, object> property,
                           Expression<Func<TEntity, object>> propertyExpression) executeUpdateRequirments) =>
        ExecuteUpdateRequirments = executeUpdateRequirments;
    protected virtual void ApplyPaging(
                                      (int? pageNumber, int? pageSize) paginationRequirments)
    {
        PaginationRequirments = paginationRequirments;
        IsPagingEnabled = true;
    }
    protected virtual void ApplyGroupBy(Expression<Func<TEntity, object>> groupBy) => GroupBy = groupBy;

    public abstract bool IsSatisfiedBy(TEntity entity);

    public ISpecification<TEntity> And(ISpecification<TEntity> left, ISpecification<TEntity> right) =>
        AndSpecification<TEntity>.Create(left, right);

    public ISpecification<TEntity> Or(ISpecification<TEntity> left, ISpecification<TEntity> right) =>
        OrSpecification<TEntity>.Create(left, right);

    public ISpecification<TEntity> Not(ISpecification<TEntity> specification) =>
        NotSpecification<TEntity>.Create(specification);
}
