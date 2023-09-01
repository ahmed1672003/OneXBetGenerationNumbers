using Microsoft.EntityFrameworkCore.Storage;

using OneXBet.Infrastructure.IRepositories;

namespace OneXBet.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IOneXBetGenerationNumbersDbContext _db;
    public UnitOfWork(
        IRoleClaimRepository roleClaims,
        IRoleRepository roles,
        IUserLoginRepository usersLogins,
        IUserRepository users,
        IUserRoleRepository userRoles,
        IUserTokenRepository userTokens,
        IOneXBetGenerationNumbersDbContext db,
        IIdentityRepository identity)
    {
        _db = db;
        RoleClaims = roleClaims;
        Roles = roles;
        UsersLogins = usersLogins;
        Users = users;
        UserRoles = userRoles;
        UserTokens = userTokens;
        Identity = identity;
    }

    public IRoleClaimRepository RoleClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserLoginRepository UsersLogins { get; }
    public IUserRepository Users { get; }
    public IUserRoleRepository UserRoles { get; }
    public IUserTokenRepository UserTokens { get; }
    public IIdentityRepository Identity { get; }
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _db.Database.CommitTransactionAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _db.Database.RollbackTransactionAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }
}
