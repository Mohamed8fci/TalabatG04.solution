using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Spesification
{
    public class ProductwithBrandandTypeSpesfication : baseSpesfication<Product>
    {
        // this constructor for getall product
        public ProductwithBrandandTypeSpesfication()
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);
        }

        // this constructor for get spesfication product

        public ProductwithBrandandTypeSpesfication(int id): base(p=>p.Id==id)
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);
        }
    }
}
