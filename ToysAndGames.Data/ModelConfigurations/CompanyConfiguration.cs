using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Data.ModelConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(Get());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Companies).OnDelete(DeleteBehavior.Restrict);
        }

        private IList<Company> Get()
        {
            return new List<Company>()
            {
                new Company(){ Id = 1, Name = "Mattel" },
                new Company(){ Id = 2, Name = "Disney"},
                new Company(){ Id = 3, Name = "Lego"},
                new Company(){ Id = 4, Name = "Fisher-Price"},
                new Company(){ Id = 5, Name = "Bandai"},
                new Company(){ Id = 6, Name = "Hasbro"},
            };
        }
    }
}
