using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.ResourceParameters
{
    public class PeopleResourceParameters
    {
        const int maxPageSize = 20;
        public string SearchName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int _pageSize;
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; 
        }
    }
}
