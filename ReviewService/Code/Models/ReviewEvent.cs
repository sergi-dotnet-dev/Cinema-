using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewService.Code.Models;

public class ReviewEvent
{
    [Key]
    public Int32 Id { get; set; }
    [Column(TypeName = "varchar(30)")] public String EventName { get; set; } = null!;
    public DateTime RaiseTime { get; set; }
    public String Content { get; set; } = null!;
}