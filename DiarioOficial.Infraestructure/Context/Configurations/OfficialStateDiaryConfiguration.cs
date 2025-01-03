using DiarioOficial.Domain.Entities.OfficialStateDiary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiarioOficial.Infraestructure.Context.Configurations
{
    internal sealed class OfficialStateDiaryConfiguration : IEntityTypeConfiguration<OfficialDiaries>
    {
        public void Configure(EntityTypeBuilder<OfficialDiaries> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Session)
                 .WithMany(x => x.OfficialStateDiaries)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
