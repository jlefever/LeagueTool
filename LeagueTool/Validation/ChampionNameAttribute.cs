using System;
using System.ComponentModel.DataAnnotations;

namespace LeagueTool.Validation
{
    public class ChampionNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}