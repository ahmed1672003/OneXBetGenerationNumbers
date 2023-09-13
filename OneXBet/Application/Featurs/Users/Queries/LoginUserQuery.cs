namespace OneXBet.Application.Featurs.Users.Queries;

public sealed record LoginUserQuery(LoginUserVM ViewModel) : IRequest<(bool status, string message)>;
