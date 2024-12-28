using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiarioOficial.Infraestructure.Context.Configurations
{
    internal sealed class OfficialStateDiaryConfiguration : IEntityTypeConfiguration<OfficialStateDiaryConfiguration>
    {
        public void Configure(EntityTypeBuilder<OfficialStateDiaryConfiguration> builder)
        {

        }
    }
}
