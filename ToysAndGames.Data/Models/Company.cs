using System.ComponentModel.DataAnnotations;

namespace ToysAndGames.Data.Models
{
    public  class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
