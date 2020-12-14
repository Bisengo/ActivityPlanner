using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ActivityPlanner.Validations
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reg = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
            
            if ((string)value == null)
            {
                return new ValidationResult("Password is needed");
            }
            else if (!reg.IsMatch((string)value))
            {
                return new ValidationResult("Password must have a minimum of eight characters, at least one letter, one number and one special character");
            }
            else
            {
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}
