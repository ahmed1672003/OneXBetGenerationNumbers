namespace OneXBet.Services.Service;

public sealed class HttpContextService : IHttpContextService
{
    public HttpContextService(IHttpContextAccessor contextAccessor)
    {
        ContextAccessor = contextAccessor;
    }

    public IHttpContextAccessor ContextAccessor { get; }

    public Task<string> RetrieveCurrentUserNameAsync()
    {
        var userName = ContextAccessor.HttpContext.User.Identity.Name;
        return Task.FromResult(userName);
    }
}
