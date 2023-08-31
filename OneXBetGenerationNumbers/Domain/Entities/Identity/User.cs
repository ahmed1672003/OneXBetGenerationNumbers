using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using OneXBetGenerationNumbers.Domain.Constants;
namespace OneXBetGenerationNumbers.Domain.Entities.Identity;

[Table(TableNames.Users)]
[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
public class User : IdentityUser<int>
{
    [Required, StringLength(255)]
    public string FirstName { get; set; } = null!;

    [Required, StringLength(255)]
    public string LastName { get; set; } = null!;

    [AllowNull]
    public string? Address { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
    }
}
