namespace SearchEngine.Code.Models;

public class Review
{
    public Int32 Id { get; set; }
    public String Content { get; set; }
    public Int32 UserId { get; set; }
    public Int32 FilmId { get; set; }
}