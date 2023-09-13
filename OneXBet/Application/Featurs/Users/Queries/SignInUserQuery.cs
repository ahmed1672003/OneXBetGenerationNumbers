using OneXBet.Application.Featurs.Email.ViewModels;

namespace OneXBet.Application.Featurs.Users.Queries;

public sealed record class SignInUserQuery(ConfirmEmailVM ViewModel) : IRequest<(bool status, string message)>;
