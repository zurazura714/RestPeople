using System.ComponentModel.DataAnnotations;

namespace PersonCatalog.Domain.Domains
{
    public class Relation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public RelationType RelationType { get; set; }

        [Required]
        public int PersonToID { get; set; }
        public virtual Person PersonTo { get; set; }

        [Required]
        public int PersonFromID { get; set; }
        public virtual Person PersonFrom { get; set; }
    }
}
