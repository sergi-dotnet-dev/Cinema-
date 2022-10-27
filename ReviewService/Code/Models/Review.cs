using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewService.Code.Models;

public class Review
{
    [Column(TypeName = "text(10000)")] public String Content { get; set; } = null!;
    public Int32 UserId { get; set; }
    public Int32 FilmId { get; set; }
}