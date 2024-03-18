using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Spesificatio;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : baseEntity
    {
        // use I readonly list because we need retrive endpoint to front end , not looping in it.
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllWithSpescAsync(Ispesfication<T> spec);

        Task<T> GetByIdWithSpescAsync(Ispesfication<T> spec);

        Task<int> getCountWithSpecAsync (Ispesfication<T> spec);
    }
}
