using OneXBet.Services.Service.Contracts;

namespace OneXBet.Services.Service;

public sealed class HttpContextService : IHttpContextService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Task<string> RetrieveCurrentUserNameAsync()
    {
        var userName = _contextAccessor.HttpContext.User.Identity.Name;
        return Task.FromResult(userName);
    }
}
