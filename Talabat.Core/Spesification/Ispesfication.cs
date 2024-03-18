using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Spesificatio
{
    public interface Ispesfication<T> where T : baseEntity
    {
        public Expression<Func<T, bool>> Cretiria { get; set; }

        public List<Expression<Func<T, Object>>> Include { get; set; }

        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
        
        public bool IsPaginationEnabled { get; set; }
    }
}
