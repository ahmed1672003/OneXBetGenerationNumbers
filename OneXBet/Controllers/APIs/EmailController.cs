using OneXBet.Application.Featurs.Email.Commands;
using OneXBet.Application.Featurs.Email.ViewModels;

namespace OneXBet.Controllers.APIs;
[Route("api/[controller]/[action]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailVM viewModel)
    {
        var result = await _mediator.Send(new ConfirmEmailCommand(viewModel));

        if (!result.status)
            return BadRequest(result.message);

        return Ok(result.userId);
    }
}
