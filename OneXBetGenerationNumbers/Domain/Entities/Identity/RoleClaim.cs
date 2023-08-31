using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using OneXBetGenerationNumbers.Domain.Constants;

namespace OneXBetGenerationNumbers.Domain.Entities.Identity;

[Table(TableNames.RoleClaims)]
public class RoleClaim : IdentityRoleClaim<int>
{

}
