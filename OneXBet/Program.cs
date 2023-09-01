using OneXBet.Infrastructure.IRepositories;
using OneXBet.Infrastructure.Repositories;
using OneXBet.Infrastructure.Specifications;
using OneXBet.Services.IService;
using OneXBet.Services.Service;
using OneXBet.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services

// Data Base Context
{
    #region DbContext
    var connectionString = builder.Configuration
                                    .GetConnectionString("DefaultConnection") ??
                                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services
           .AddDbContext<OneXBetGenerationNumbersDbContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    #endregion
}

// Identity
{
    #region Identity 
    builder.Services
       .AddIdentity<User, Role>(options =>
       {
           #region Email Options
           options.SignIn.RequireConfirmedEmail = false;
           options.SignIn.RequireConfirmedPhoneNumber = false;
           options.SignIn.RequireConfirmedAccount = false;
           #endregion

           #region Stores Options
           //options.Stores.ProtectPersonalData = true;

           #endregion

           #region Password Options
           options.Password.RequireNonAlphanumeric = false;
           options.Password.RequireLowercase = false;
           options.Password.RequireUppercase = false;
           options.Password.RequireDigit = false;
           options.Password.RequiredLength = 3;
           #endregion

           #region User Options
           options.User.RequireUniqueEmail = true;
           #endregion

           #region Lock Out Options
           options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
           options.Lockout.MaxFailedAccessAttempts = 5;
           options.Lockout.AllowedForNewUsers = true;
           #endregion

           #region Claims Options

           #endregion

           #region Token Options

           #endregion
       })
       .AddEntityFrameworkStores<OneXBetGenerationNumbersDbContext>()
       .AddDefaultTokenProviders()
       .AddDefaultUI();
    #endregion
}

// Dependecies
{
    #region Dependecies
    builder.Services.AddScoped<UserManager<User>>();
    builder.Services.AddScoped<SignInManager<User>>();
    builder.Services.AddScoped<RoleManager<Role>>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped(typeof(ISpecification<>), typeof(Specification<>));
    builder.Services.AddScoped<IOneXBetGenerationNumbersDbContext, OneXBetGenerationNumbersDbContext>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
    builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
    builder.Services.AddScoped<IUnitOfServices, UnitOfServices>();
    builder.Services.AddScoped<IEmailService, EmailService>();
    #endregion
}

// Configurations
{
    #region Configurations
    builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("emailSettings"));
    #endregion
}
#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
