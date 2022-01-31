using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entity;

namespace Module4HW6.Data.EntityConfigurators
{
    public class GenreTypeConfigurator : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).ValueGeneratedNever();
            builder.Property(g => g.Title).IsRequired();
        }
    }
}