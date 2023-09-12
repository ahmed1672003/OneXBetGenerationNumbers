using Microsoft.EntityFrameworkCore.Storage;

namespace OneXBet.Infrastructure.Repositories.Contracts;

public interface IUnitOfWork : IAsyncDisposable
{
    IRoleClaimRepository RoleClaims { get; }
    IRoleRepository Roles { get; }
    IUserLoginRepository UsersLogins { get; }
    IUserRepository Users { get; }
    IUserRoleRepository UserRoles { get; }
    IUserTokenRepository UserTokens { get; }
    IIdentityRepository Identity { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
