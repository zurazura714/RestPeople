using System.ComponentModel.DataAnnotations;

namespace PersonCatalog.Domain.Domains
{
    public class PhoneNumber
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50), MinLength(4)]
        public string Number { get; set; }

        [Required]
        public PhoneNumberType phoneNumberType { get; set; }

        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
