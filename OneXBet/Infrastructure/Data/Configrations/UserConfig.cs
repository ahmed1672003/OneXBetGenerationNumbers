using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OneXBetGenerationNumbers.Domain.Constants;
using OneXBetGenerationNumbers.Domain.Entities.Identity;

namespace OneXBetGenerationNumbers.Infrastructure.Data.Configrations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);
    }
}
