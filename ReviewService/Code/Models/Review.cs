using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewService.Code.Models;

public class Review
{
    [Column(TypeName = "text")] public String Content { get; set; } = null!;
    public Int32 UserId { get; set; }
    public Int32 FilmId { get; set; }
}