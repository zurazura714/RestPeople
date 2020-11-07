using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class RelativeIDsMustNotBeTheSame : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var course = (RelativeCreateDTO)validationContext.ObjectInstance;

            if (course.PersonToID == course.PersonFromID)
            {
                return new ValidationResult("PersonToID and PersonFromID can't be same");
            }
            return ValidationResult.Success;
        }
    }
}