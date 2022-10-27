using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Code.Models;

public class User
{
    [Key]
    public Int32 Id { get; set; }
    [Column(TypeName = "nvarchar(40)")] public String Name { get; set; } = null!;
    [Column(TypeName =("blob"))] public Byte[]? Photo { get; set; }
    public List<FilmUser>? FavoriteFilms { get; set; }
}