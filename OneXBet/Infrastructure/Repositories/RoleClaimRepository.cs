using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
