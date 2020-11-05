using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class ShouldContainOnlyDigits : ValidationBase
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyName = value.ToString();
            string onlyDigits = @"[0-9]";

            if (value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} property is required");
            }

            if (propertyName.Trim().Contains(" "))
            {
                return new ValidationResult($"{validationContext.DisplayName} property contains white space");
            }

            if (RegexMatcher(propertyName, onlyDigits))
            {
                return new ValidationResult(@"Only digits are allowed");
            }
            return ValidationResult.Success;
        }
    }
}
