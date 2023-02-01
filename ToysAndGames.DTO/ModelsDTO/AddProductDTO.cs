using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ToysAndGames.DTO.Validations;

namespace ToysAndGames.DTO.ModelsDTO
{
    public class AddProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int AgeRestriction { get; set; }

        public int CompanyId { get; set; }

        public decimal Price { get; set; }

        [NotMapped]
        [SizeFileValidation(sizeMaxMB: 4)]
        [FileTypeValidation(fileTypeGroup: FileTypeGroup.Image)]
        public IFormFile Image { get; set; }

        //public string? Image { get; set; }
    }
}