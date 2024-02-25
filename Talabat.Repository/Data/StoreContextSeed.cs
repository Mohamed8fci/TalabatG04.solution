using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {
            if(!dbcontext.productBrands.Any())
            {
                var brandsdate = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdate);

                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)

                        await dbcontext.Set<ProductBrand>().AddAsync(brand);

                    await dbcontext.SaveChangesAsync();
                }
            }

            if (!dbcontext.productTypes.Any())
            {
                var typesdate = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdate);

                if (types?.Count > 0)
                {
                    foreach (var type in types)

                        await dbcontext.Set<ProductType>().AddAsync(type);

                    await dbcontext.SaveChangesAsync();
                }
            }

            if (!dbcontext.products.Any())
            {
                var productsdate = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdate);

                if (products?.Count > 0)
                {
                    foreach (var product in products)

                        await dbcontext.Set<Product>().AddAsync(product);

                    await dbcontext.SaveChangesAsync();
                }
            }
        }
    }
}
