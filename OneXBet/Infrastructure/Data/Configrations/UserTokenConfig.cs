using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OneXBetGenerationNumbers.Domain.Constants;

namespace OneXBetGenerationNumbers.Infrastructure.Data.Configrations;

public class UserTokenConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(TableNames.UserTokens);
    }
}
