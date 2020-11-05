using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonCatalog.Web.CustomValidations
{
    public class OnlyLatinOrNonLatinSymbolsAllowed : ValidationBase
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyName = value.ToString();
            string FirstLatin = @"^[a-zA-z]";
            string OnlyLatinLetters = @"[a-zA-z]";
            string FirstGeorrgian = @"^[ა-ჰ]";
            string OnlyGeorrgianLetters = @"[ა-ჰ]";
            var person = (PersonCreateDTO)validationContext.ObjectInstance;

            if (value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} property is required");
            }

            if (propertyName.Trim().Contains(" "))
            {
                return new ValidationResult($"{validationContext.DisplayName} property contains white space");
            }

            if (Regex.IsMatch(propertyName, FirstLatin))
            {
                if (RegexMatcher(propertyName, OnlyLatinLetters))
                {
                    return new ValidationResult(@"For instance, if the word starts with georgian letter the rest letters should be Georgian as well, but if the first letter is latin Then the rest of the word should also contain latin letters");
                }
            }
            else if (Regex.IsMatch(propertyName, FirstGeorrgian))
            {
                if (RegexMatcher(propertyName, OnlyGeorrgianLetters))
                {
                    return new ValidationResult(@"For instance, if the word starts with georgian letter the rest letters should be Georgian as well, but if the first letter is latin Then the rest of the word should also contain latin letters");
                }
            }
            return ValidationResult.Success;
        }
        
    }
}
