using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Specifications.Expressions;

public sealed class OrSpecification<TEntity> : Specification<TEntity>
    where TEntity : class
{
    private readonly ISpecification<TEntity> _left;
    private readonly ISpecification<TEntity> _right;

    private OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
    {
        _left = left;
        _right = right;
    }
    public sealed override bool IsSatisfiedBy(TEntity entity) =>
        _right.IsSatisfiedBy(entity) || _left.IsSatisfiedBy(entity);

    public static OrSpecification<TEntity> Create(ISpecification<TEntity> left, ISpecification<TEntity> right) =>
        new OrSpecification<TEntity>(left, right);
}
