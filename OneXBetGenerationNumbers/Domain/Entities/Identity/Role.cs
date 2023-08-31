using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using OneXBetGenerationNumbers.Domain.Constants;

namespace OneXBetGenerationNumbers.Domain.Entities.Identity;

[Table(TableNames.Roles)]
public class Role : IdentityRole<int>
{
}
