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
           options.SignIn.RequireConfirmedAccount = true;
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
