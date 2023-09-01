using OneXBet.Infrastructure.IRepositories;

namespace OneXBet.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<User> roleManager)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
    }

    public UserManager<User> UserManager { get; }
    public SignInManager<User> SignInManager { get; }
    public RoleManager<User> RoleManager { get; }
}
