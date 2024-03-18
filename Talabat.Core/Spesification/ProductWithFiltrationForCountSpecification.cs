using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Spesification
{
    public class ProductWithFiltrationForCountSpecification : baseSpesfication<Product>
    {
        public ProductWithFiltrationForCountSpecification(ProductSpecParams specParams)
               : base(p =>
                (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search)) &&
                  //if brandid has value the condition will be false that he will go through condition
                  (!specParams.BrandId.HasValue || p.ProductBrandId == specParams.BrandId.Value) &&
                  (!specParams.TypeId.HasValue || p.ProductTypeId == specParams.TypeId.Value)
               )
        {

        }
        
    }
}
