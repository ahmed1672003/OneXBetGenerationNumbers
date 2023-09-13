namespace OneXBet.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<Role> roleManager,
        IUserStore<User> userStore)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
        UserStore = userStore;
        UserEmailStore = GetEmailStore();
    }
    public UserManager<User> UserManager { get; }
    public SignInManager<User> SignInManager { get; }
    public RoleManager<Role> RoleManager { get; }
    public IUserStore<User> UserStore { get; }
    public IUserEmailStore<User> UserEmailStore { get; }


    private IUserEmailStore<User> GetEmailStore()
    {
        if (!UserManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<User>)UserStore;
    }
}
