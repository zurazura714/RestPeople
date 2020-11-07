using PersonCatalog.Domain.Interfaces.IServices;
using PersonCatalog.Repository.Context;
using PersonCatalog.Web.Models;
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
            //using (PersonDbContext _context = new PersonDbContext())
            //{
            //    var person = _context.Set<PersonCreateDTO>().Where(a => a.PersonalNumber == value.ToString()).SingleOrDefault();
            //    if (person != null)
            //    {
            //        return new ValidationResult($"{validationContext.DisplayName} property Already exists");
            //    }
            //}
                return ValidationResult.Success;
        }
    }
}
