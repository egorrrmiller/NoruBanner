using Database.Context;
using Database.DTO;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Tibuon.Controllers;

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
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.id);

        if (banner is null)
            return null;

        var result = _context.Banners.Update(new Banner
        {
            BannerId = banner.BannerId,
            SeeCount = banner.SeeCount,
            ClickCount = banner.ClickCount + 1,
            DontSeeCount = banner.DontSeeCount
        });
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    
    [HttpPost("dontSeeBanner")]
    public async Task<Banner?> DontSeeBanner(BannerDto bannerDto)
    {
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.id);

        if (banner is null)
            return null;

        var result = _context.Banners.Update(new Banner
        {
            BannerId = banner.BannerId,
            SeeCount = banner.SeeCount,
            ClickCount = banner.ClickCount,
            DontSeeCount = banner.DontSeeCount + 1
        });
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    [HttpPost("seeBanner")]
    public async Task<IActionResult> SeeBanner(BannerDto bannerDto)
    {
        var banner = await _context.Banners.AsNoTracking().FirstOrDefaultAsync(id => id.BannerId == bannerDto.id);

        if (banner is null)
            return NotFound("Баннер не найден");

        _context.Banners.Update(new Banner
        {
            BannerId = banner.BannerId,
            SeeCount = banner.SeeCount + 1,
            ClickCount = banner.ClickCount,
            DontSeeCount = banner.DontSeeCount
        });
        await _context.SaveChangesAsync();
        return Ok();
    }
}