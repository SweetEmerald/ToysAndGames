using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ToysAndGames.DTO.Validations
{
    public class FileTypeValidation: ValidationAttribute
    {
        private readonly string[] _validTypes;

        public FileTypeValidation(string[] validTypes)
        {
            _validTypes = validTypes;
        }

        public FileTypeValidation(FileTypeGroup fileTypeGroup)
        {
            if (fileTypeGroup == FileTypeGroup.Image)
                _validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            IFormFile formfile = value as IFormFile;

            if (formfile == null)
                return ValidationResult.Success;

            if (!_validTypes.Contains(formfile.ContentType))
                return new ValidationResult($"The type of the file must to be one of the next: {string.Join(", ", _validTypes)}");

            return ValidationResult.Success;
        }
    }
}
