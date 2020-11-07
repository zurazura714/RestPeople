using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace PersonCatalog.Web.Models
{
    public class PhoneForUpdateDTO
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
