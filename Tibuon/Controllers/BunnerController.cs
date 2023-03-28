using Database.Context;
using Database.DTO;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tibuon.Controllers;

[ApiController]
public class BunnerController : ControllerBase
{

    private readonly TibuonContext _context;

    public BunnerController(TibuonContext context)
    {
        _context = context;
    }
    
    [HttpPost("clickBunner")]
    public async Task<Bunner> ClickBunner(BunnerDto bunnerDto)
    {
        var bunner = await _context.Bunners.AsNoTracking().FirstOrDefaultAsync(id => id.BunnerId == bunnerDto.id);
        var result = _context.Bunners.Update(new Bunner
        {
            BunnerId = bunner.BunnerId,
            SeeCount = bunner.SeeCount,
            ClickCount = bunner.ClickCount + 1
        });
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    [HttpPost("seeBunner")]
    public async Task<IActionResult> SeeBunner(BunnerDto bunnerDto)
    {
        var bunner =await _context.Bunners.AsNoTracking().FirstOrDefaultAsync(id => id.BunnerId == bunnerDto.id);
        _context.Bunners.Update(new Bunner
        {
            BunnerId = bunner.BunnerId,
            SeeCount = bunner.SeeCount + 1,
            ClickCount = bunner.ClickCount
        });
        await _context.SaveChangesAsync();
        return Ok();
    }
}