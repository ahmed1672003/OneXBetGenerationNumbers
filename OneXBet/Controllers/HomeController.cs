using System.Diagnostics;

using OneXBet.Models;

namespace OneXBet.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfServices _unitOfServices;
    public HomeController(ILogger<HomeController> logger, IUnitOfServices unitOfServices)
    {
        _logger = logger;
        _unitOfServices = unitOfServices;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
