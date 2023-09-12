using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
