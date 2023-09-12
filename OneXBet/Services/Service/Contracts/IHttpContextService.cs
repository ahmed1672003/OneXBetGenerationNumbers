namespace OneXBet.Services.Service.Contracts;

public interface IHttpContextService
{
    Task<string> RetrieveCurrentUserNameAsync();
}
