using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entity;

namespace Module4HW6.Data.EntityConfigurators
{
    public class ArtistTypeConfigurator : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.DateOfBirth).IsRequired();
        }
    }
}