
using Microsoft.AspNetCore.Authorization;

using OneXBet.Application.Featurs.Email.ViewModels;
using OneXBet.Application.Featurs.Users.Queries;

namespace OneXBet.Controllers;

[AllowAnonymous]
public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult PostUser()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> PostUser(RegisterUserVM viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var result = await _mediator.Send(new RegisterUserCommand(viewModel));

        if (!result.statues)
            return BadRequest(result.message);

        return RedirectToAction(nameof(VerifyUserEmail));
    }

    [HttpGet]
    public IActionResult LoginUser()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> LoginUser(LoginUserVM viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var result = await _mediator.Send(new LoginUserQuery(viewModel));

        if (!result.status)
            return BadRequest(result.message);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet]
    public IActionResult VerifyUserEmail()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> SinInUser(string token, string userId)
    {
        var response = await _mediator.Send(new SignInUserQuery(new ConfirmEmailVM()
        {
            Token = token,
            UserId = userId
        }));

        if (!response.status)
            return BadRequest(response.message);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
