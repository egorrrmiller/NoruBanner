using Database.Context;
using Database.DTO;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tiburon.Controllers;

[ApiController]
public class BannerController : ControllerBase
{
    private readonly TibuonContext _context;

    public BannerController(TibuonContext context)
    {
        _context = context;
    }

    [HttpPost("clickBanner")]
    public async Task<Banner?> ClickBanner(BannerDto bannerDto)
    {
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.Id);

        if (banner is null)
            return null;

        banner.ClickCount += 1;
        var result = _context.Banners.Update(banner);
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }

    [HttpPost("dontSeeBanner")]
    public async Task<Banner?> DontSeeBanner(BannerDto bannerDto)
    {
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.Id);

        if (banner is null)
            return null;

        banner.DontSeeCount += 1;
        var result = _context.Banners.Update(banner);
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }

    [HttpPost("seeBanner")]
    public async Task<IActionResult> SeeBanner(BannerDto bannerDto)
    {
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.Id);

        if (banner is null)
            return NotFound("Баннер не найден");

        banner.SeeCount += 1;
        _context.Banners.Update(banner);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}