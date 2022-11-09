using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorService.Code.Models;

public class Actor
{
    [Key]
    public Int32 Id { get; set; }
    public String Name { get; set; } = null!;
    public Int32 BornYear { get; set; }
    [Column(TypeName ="varbinary(5000)")] public Byte[]? Photo { get; set; }
    public List<FilmActor>? FilmActors { get; set; }
}