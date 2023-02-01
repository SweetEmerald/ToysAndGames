namespace ToysAndGames.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int AgeRestriction { get; set; }

        public int CompanyId { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }

        //navigation properties
        public Company Companies { get; set; } = null!;
    }
}
