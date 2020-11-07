using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public int Age { get; set; }
        public virtual ICollection<PhoneDTO> Phones { get; set; }
        public virtual ICollection<RelativeDTO> Relatives { get; set; } 
        = new List<RelativeDTO>();
    }
}
