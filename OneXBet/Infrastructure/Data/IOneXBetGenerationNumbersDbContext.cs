using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using OneXBetGenerationNumbers.Domain.Entities.Identity;

namespace OneXBetGenerationNumbers.Infrastructure.Data;

public interface IOneXBetGenerationNumbersDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<RoleClaim> RoleClaims { get; }
    DbSet<UserClaim> UserClaims { get; }
    DbSet<UserLogin> UserLogins { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<UserToken> UserTokens { get; }
    ValueTask DisposeAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get; }
}
