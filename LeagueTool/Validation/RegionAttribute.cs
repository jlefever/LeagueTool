using System.ComponentModel.DataAnnotations;
using LeagueTool.Models;

namespace LeagueTool.Validation
{
    public class RegionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string region))
            {
                return new ValidationResult("Regions must be a string.");
            }

            if (!Region.IsValidRegion(region))
            {
                return new ValidationResult("Not a valid region.");
            }

            return ValidationResult.Success;
        }
    }
}