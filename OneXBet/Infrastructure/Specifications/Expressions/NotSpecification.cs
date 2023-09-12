using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Specifications.Expressions;

public sealed class NotSpecification<TEntity> : Specification<TEntity>
    where TEntity : class
{
    private readonly ISpecification<TEntity> _specification;
    private NotSpecification(ISpecification<TEntity> specification)
    {
        _specification = specification;
    }
    public sealed override bool IsSatisfiedBy(TEntity entity) =>
       !_specification.IsSatisfiedBy(entity);

    public static NotSpecification<TEntity> Create(ISpecification<TEntity> specification) =>
        new(specification);
}
