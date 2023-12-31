﻿using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
    public UserLoginRepository(IOneXBetGenerationNumbersDbContext context) : base(context)
    {
    }
}
