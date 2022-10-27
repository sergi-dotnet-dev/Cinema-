namespace SearchEngine.Code.Models;

public class FilmUser
{
    public Int32 UserId { get; set; }
    public User User { get; set; }
    public Int32 FilmId { get; set; }
    public Film Film { get; set; }
}