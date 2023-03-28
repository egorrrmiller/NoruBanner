namespace Database.Models;

public class Banner
{
    public Guid BannerId { get; set; }
    public int ClickCount { get; set; }
    public int SeeCount { get; set; }
    public int DontSeeCount { get; set; }
}