namespace OneXBet.Services.Service.Contracts;

public interface IHttpContextService
{
    IHttpContextAccessor ContextAccessor { get; }

    Task<string> RetrieveCurrentUserNameAsync();
}
