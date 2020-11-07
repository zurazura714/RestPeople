using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class PhoneCreateDTO
    {
        public int ID { get; set; }
        [Required]
        [ShouldContainOnlyDigits]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} property Minimum Length is {2} and Maximum {1} characters")]
        public string Number { get; set; }

        [Required]
        public PhoneNumberType phoneNumberType { get; set; }
    }
}
