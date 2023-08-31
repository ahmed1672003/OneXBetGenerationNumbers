using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using OneXBetGenerationNumbers.Domain.Constants;

namespace OneXBetGenerationNumbers.Domain.Entities.Identity;

[Table(TableNames.UserRoles)]

public class UserRole : IdentityUserRole<int>
{
}
