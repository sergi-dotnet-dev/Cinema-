namespace SearchEngine.Code.Models;

public class FilmActor
{
    public Int32 FilmId { get; set; }
    public Film Film { get; set; }
    public Int32 ActorId { get; set; }
    public Actor Actor { get; set; }
}