using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Spesificatio;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : baseEntity
    {
        private readonly StoreContext _dbContext;
        public GenericRepository(StoreContext dbContext) { 
           _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(Product))
            //    return (IEnumerable<T>) await _dbContext.products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }

        

        public async Task<T> GetByIdAsync(int id)
        {
            // _dbContext.products.where(p=>p.Id==id).Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();

            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllWithSpescAsync(Ispesfication<T> spec)
        {
            return await ApplySpesfifcation(spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpescAsync(Ispesfication<T> spec)
        {
            return await ApplySpesfifcation(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpesfifcation(Ispesfication<T> spec)
        {
            return SpecficationEvalutor<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
