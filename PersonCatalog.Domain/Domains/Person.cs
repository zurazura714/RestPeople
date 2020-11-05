using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonCatalog.Domain.Domains
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(2),MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        [MinLength(11),MaxLength(11)]
        public string PersonalNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<PhoneNumber> Phones { get; set; }
        public virtual ICollection<Relations> RelatedTo { get; set; }
        public virtual ICollection<Relations> RelatedFrom { get; set; }
    }
}
