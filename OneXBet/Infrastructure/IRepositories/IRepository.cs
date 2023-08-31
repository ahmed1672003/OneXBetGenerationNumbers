namespace OneXBet.Infrastructure.IRepositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);





}
