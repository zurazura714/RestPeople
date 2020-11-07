using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class PersonCreateDTO
    {

        //[RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [OnlyLatinOrNonLatinSymbolsAllowed]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} property Minimum Length is {2} and Maximum {1} characters")]
        public string Name { get; set; }

        [OnlyLatinOrNonLatinSymbolsAllowed]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} property Minimum Length is {2} and Maximum {1} characters")]
        public string Surname { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [PersonalNumberIsUnique]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} property symbol Length must be {2}")]
        [ShouldContainOnlyDigits]
        public string PersonalNumber { get; set; }

        [Min18YearsOld]
        public DateTime BirthDate { get; set; }

        public ICollection<PhoneCreateDTO> Phones { get; set; }
          = new List<PhoneCreateDTO>();
    }
}
