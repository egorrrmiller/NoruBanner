using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Tibuon.Controllers;

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
        var bunners = _context.Bunners.ToList();
        return View(bunners);
    }
}