using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ToysAndGames.DTO.Validations;

namespace ToysAndGames.DTO.ModelsDTO
{
    public class AddCompanyDTO
    {
        public string Name { get; set; }
    }
}