using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ToysAndGames.DTO.Validations
{
    public class SizeFileValidation: ValidationAttribute
    {
        private readonly int _sizeMaxMB;

        public SizeFileValidation(int sizeMaxMB)
        {
            _sizeMaxMB = sizeMaxMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            IFormFile formfile = value as IFormFile;

            if (formfile == null)
                return ValidationResult.Success;

            if (formfile.Length > _sizeMaxMB * 1024 * 1024) //convert to bytes
                return new ValidationResult($"The size of the file not be greater than {_sizeMaxMB} MB");

            return ValidationResult.Success;
        }
    }
}
