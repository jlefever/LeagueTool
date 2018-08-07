using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using LeagueTool.Services;

namespace LeagueTool.Validation
{
    public class VersionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string version))
            {
                return new ValidationResult("Versions must be a string.");
            }

            var dataDragon = DependencyResolver.Current.GetService<IDataDragonService>();

            var versions = dataDragon.GetVersionsAsync().GetAwaiter().GetResult();

            if (versions.Count(v => v == version) != 1)
            {
                return new ValidationResult("Not a valid version.");
            }

            return ValidationResult.Success;
        }
    }
}