using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
