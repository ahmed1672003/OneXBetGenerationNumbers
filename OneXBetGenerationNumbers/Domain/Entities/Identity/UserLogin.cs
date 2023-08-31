using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using OneXBetGenerationNumbers.Domain.Constants;

namespace OneXBetGenerationNumbers.Domain.Entities.Identity;

[Table(TableNames.UserLogins)]

public class UserLogin : IdentityUserLogin<int>
{
}
