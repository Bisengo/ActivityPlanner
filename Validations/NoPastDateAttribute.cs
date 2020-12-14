using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityPlanner.Validations
{
    public class NoPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime) value < DateTime.Now)
            {
                return new ValidationResult("Date must be in the future!");
            }
            return ValidationResult.Success;
        }
    }
}