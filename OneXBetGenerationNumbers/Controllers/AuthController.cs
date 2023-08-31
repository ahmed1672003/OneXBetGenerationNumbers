using Microsoft.AspNetCore.Mvc;

namespace OneXBetGenerationNumbers.Controllers;
public class AuthController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
}
