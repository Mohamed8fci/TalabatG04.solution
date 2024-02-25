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
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllWithSpescAsync(Ispesfication<T> spec);

        Task<T> GetByIdWithSpescAsync(Ispesfication<T> spec);
    }
}
