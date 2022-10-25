namespace SearchEngine.Code.Models;

public class FilmCategory
{
    public Int32 FilmId { get; set; }
    public Film Film { get; set; }
    public Int32 CategoryId { get; set; }
    public Category Category { get; set; }
}