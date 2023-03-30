using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Tiburon.Controllers;

public class HomeController : Controller
{
    private readonly TibuonContext _context;

    // GET
    public HomeController(TibuonContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var banners = _context.Banners.ToList();
        return View(banners);
    }
}