using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using ToysAndGames.DTO.Validations;

namespace ToysAndGames.DTO.ModelsDTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}