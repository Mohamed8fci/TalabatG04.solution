using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Spesification
{
    public class ProductSpecParams
    {
        private const int maxPageSize = 10;
        private int pageSize = 5;


        // البدج دي بتشيل كام 
        public int PageSize 
        {
            get { return pageSize; }
            set { pageSize = value > maxPageSize ? maxPageSize : value; }
        }

        // البيدج دي رقم كام
        public int PageIndex { get; set; } = 1;

        private string search;

        public string Search 
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

        public string? Sort {  get; set; }

        public int? BrandId { get; set; }

        public int? TypeId { get; set;}
    }
}
