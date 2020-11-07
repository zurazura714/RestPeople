using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    [RelativeIDsMustNotBeTheSame]
    public class RelativeCreateDTO
    {
        [Required]
        public RelationType RelationType { get; set; }
        [Required]
        public int PersonToID { get; set; }
        [Required]
        public int PersonFromID { get; set; }
    }
}
