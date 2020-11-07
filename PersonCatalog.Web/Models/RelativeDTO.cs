using PersonCatalog.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class RelativeDTO
    {
        public int ID { get; set; }
        public RelationType RelationType { get; set; }
        public int PersonToID { get; set; }
        public int PersonFromID { get; set; }
    }
    public class RelativeDTOForFilter
    {
        public RelationType RelationType { get; set; }
        public string Name { get; set; }
    }
}
