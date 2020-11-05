using PersonCatalog.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class PersonalNumberIsUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var person = _personService.Set().Where(a => a.PersonalNumber == value.ToString()).SingleOrDefault();
            //if (person != null)
            //{
            //    return new ValidationResult($"{validationContext.DisplayName} property Already exists");
            //}
            return ValidationResult.Success;
            
        }
    }
}
