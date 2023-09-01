using Microsoft.AspNetCore.Mvc;

namespace OneXBet.Controllers;
public class AuthController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
