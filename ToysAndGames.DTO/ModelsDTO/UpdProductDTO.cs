using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using ToysAndGames.DTO.Validations;

namespace ToysAndGames.DTO.ModelsDTO
{
    public class UpdProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AgeRestriction { get; set; }

        public int CompanyId { get; set; }

        public decimal Price { get; set; }

        [NotMapped]
        [SizeFileValidation(sizeMaxMB: 4)]
        [FileTypeValidation(fileTypeGroup: FileTypeGroup.Image)]
        public IFormFile Image { get; set; }
    }
}