namespace OneXBet.Infrastructure.IRepositories;

public interface IIdentityRepository
{
    UserManager<User> UserManager { get; }
    SignInManager<User> SignInManager { get; }
    RoleManager<User> RoleManager { get; }
}
