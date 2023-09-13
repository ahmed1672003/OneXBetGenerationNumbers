
namespace OneXBet.Application.Featurs.Users.Commands;

public record RegisterUserCommand(RegisterUserVM ViewModel) : IRequest<(bool statues, string message)>;
