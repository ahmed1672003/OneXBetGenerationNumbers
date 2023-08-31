using System.Reflection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using OneXBetGenerationNumbers.Domain.Entities.Identity;

namespace OneXBetGenerationNumbers.Infrastructure.Data;
public class OneXBetGenerationNumbersDbContext :
    IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
    IOneXBetGenerationNumbersDbContext
{
    public OneXBetGenerationNumbersDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<UserToken> UserToken { get; set; }
}