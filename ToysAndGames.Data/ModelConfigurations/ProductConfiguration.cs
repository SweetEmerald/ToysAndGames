using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Data.ModelConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(Get());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18, 2)");
        }

        private IList<Product> Get()
        {
            return new List<Product>()
            {
                new Product(){Id = 1, Name = "Match box2", Description = "Matchbox Work Team Pack 4 cars", AgeRestriction=6, CompanyId=1, Price=125, Image=null },
                new Product(){Id = 2, Name = "The Razor Crest2", Description = "Display base for the Mandalorian LEGO Star Wars minifigures", AgeRestriction = 3, CompanyId = 3, Price = 3000, Image = null },
                new Product(){Id = 3, Name = "Potato Head", Description = "Potato Head - Mr. Potato Head", AgeRestriction = 3, CompanyId = 6, Price = 1000, Image = null},
                new Product(){Id = 4, Name = "Superman 2", Description = "DC Comics Stylized Superman", AgeRestriction = 6, CompanyId = 5, Price = 524, Image = null},
            };
        }
    }
}
