using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OneXBetGenerationNumbers.Domain.Constants;
using OneXBetGenerationNumbers.Domain.Entities.Identity;

namespace OneXBetGenerationNumbers.Infrastructure.Data.Configrations;

public class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(TableNames.RoleClaims);
    }
}
