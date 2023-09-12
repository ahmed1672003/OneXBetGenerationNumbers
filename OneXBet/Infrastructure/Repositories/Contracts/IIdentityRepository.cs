namespace OneXBet.Infrastructure.Repositories.Contracts;

public interface IIdentityRepository
{
    UserManager<User> UserManager { get; }
    SignInManager<User> SignInManager { get; }
    RoleManager<Role> RoleManager { get; }
}
