namespace SearchEngine.Code.Models;

public class Category
{
    public Int32 Id { get; set; }
    public String Name { get; set; } = null!;
    public List<FilmCategory> Films { get; set; }
}