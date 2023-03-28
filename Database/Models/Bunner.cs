namespace Database.Models;

public class Bunner
{
    // допустим, что баннеров много и их ид есть в базе данных
    public Guid BunnerId { get; set; }

    public int ClickCount { get; set; }
    public int SeeCount { get; set; }
}