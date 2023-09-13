namespace OneXBet.Application.Featurs.Users.Queries;

public sealed record GetUserByIdQuery(int UserId) : IRequest<(bool status, string message, GetUserVM model)>;
