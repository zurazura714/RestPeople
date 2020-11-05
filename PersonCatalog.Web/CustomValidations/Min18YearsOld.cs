using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class Min18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (PersonCreateDTO)validationContext.ObjectInstance;
            if (person.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - person.BirthDate.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Following Person should be at least 18");
        }
    }
}
