using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.ResourceParameters
{
    public class PeopleResourceParameters
    {
        const int maxPageSize = 20;
        public string SearchName { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
