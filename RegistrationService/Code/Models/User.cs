using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace RegistrationService.Code.Models;

public class User
{
    [Key] 
    public Int32 Id { get; set; }
    public String Name { get; set; } = null!;
    public Int32 Age { get; set; }
    public DateTime RegistrationDate { get; set; }

}