using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product:baseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }


        public int ProductTypeId { get; set; } // forign key not allow null
        public ProductType ProductType { get; set; }

    }
}
