using System.ComponentModel.DataAnnotations;
using LeagueTool.Models;

namespace LeagueTool.Validation
{
    public class LanguageAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string language))
            {
                return new ValidationResult("Languages must be a string.");
            }

            if (!Language.IsValidLanguage(language))
            {
                return new ValidationResult("Not a valid language.");
            }

            return ValidationResult.Success;
        }
    }
}