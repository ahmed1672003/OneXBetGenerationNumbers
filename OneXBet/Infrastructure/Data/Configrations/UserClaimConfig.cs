using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OneXBetGenerationNumbers.Domain.Constants;
using OneXBetGenerationNumbers.Domain.Entities.Identity;

namespace OneXBetGenerationNumbers.Infrastructure.Data.Configrations;

public class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(TableNames.UserClaims);
    }
}
