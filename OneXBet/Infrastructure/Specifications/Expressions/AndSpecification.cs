using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Specifications.Expressions;

public sealed class AndSpecification<TEntity> : Specification<TEntity>
    where TEntity : class
{
    private readonly ISpecification<TEntity> _right;
    private readonly ISpecification<TEntity> _left;

    private AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
    {
        _left = left;
        _right = right;
    }

    public sealed override bool IsSatisfiedBy(TEntity entity) =>
        _right.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);

    public static AndSpecification<TEntity> Create(ISpecification<TEntity> left, ISpecification<TEntity> right) =>
        new(left, right);
}
