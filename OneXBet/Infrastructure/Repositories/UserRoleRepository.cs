using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
