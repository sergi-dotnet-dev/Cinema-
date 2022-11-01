using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Code.Models;

public class Actor
{
    [Key]
    public Int32 Id { get; set; }
    public String Name { get; set; } = null!;
    public Int32 BornYear { get; set; }
    [Column(TypeName ="blob")] public Byte[]? Photo { get; set; }
}