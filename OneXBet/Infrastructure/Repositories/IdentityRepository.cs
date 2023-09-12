using OneXBet.Infrastructure.Repositories.Contracts;

namespace OneXBet.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<Role> roleManager)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
    }

    public UserManager<User> UserManager { get; private set; }
    public SignInManager<User> SignInManager { get; private set; }
    public RoleManager<Role> RoleManager { get; private set; }
}
