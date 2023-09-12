using System.Linq.Expressions;

namespace OneXBet.Infrastructure.Specifications.Expressions;

public sealed class FilterSpecification<TEntity> : Specification<TEntity>
    where TEntity : class
{
    private readonly Expression<Func<TEntity, bool>> _expression;

    private FilterSpecification(Expression<Func<TEntity, bool>> expression)
    {
        _expression = expression;
    }

    public sealed override bool IsSatisfiedBy(TEntity entity) =>
        _expression.Compile().Invoke(entity);

    public static FilterSpecification<TEntity> Create(Expression<Func<TEntity, bool>> expression) =>
        new(expression);
}
