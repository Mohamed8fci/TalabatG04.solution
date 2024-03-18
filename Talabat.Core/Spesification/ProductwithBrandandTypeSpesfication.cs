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
        // this constructor for get All products
        public ProductwithBrandandTypeSpesfication(ProductSpecParams specParams)
            :base(p=>
                   (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search)) &&
            //if brandid has value the condition will be false that he will go through condition
                      (!specParams.BrandId.HasValue || p.ProductBrandId == specParams.BrandId.Value)  &&
                      (!specParams.TypeId.HasValue || p.ProductTypeId == specParams.TypeId.Value)
                 )
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);


            AddOrderBy(P => P.Name);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch(specParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }


            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        // this constructor for get spesfication product

        public ProductwithBrandandTypeSpesfication(int id): base(p=>p.Id==id)
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.ProductType);
        }
    }
}
