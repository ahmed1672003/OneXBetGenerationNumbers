using OneXBet.Infrastructure.IRepositories;

namespace OneXBet.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
