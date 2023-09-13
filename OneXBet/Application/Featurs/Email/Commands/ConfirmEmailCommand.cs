using OneXBet.Application.Featurs.Email.ViewModels;

namespace OneXBet.Application.Featurs.Email.Commands;

public sealed record class ConfirmEmailCommand(ConfirmEmailVM ViewModel) : IRequest<(bool status, string message, int? userId)>;


