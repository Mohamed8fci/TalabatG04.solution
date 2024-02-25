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
        public Expression<Func<T,bool>> Cretiria { get; set; }

        public  List<Expression<Func<T,Object>>> Include { get; set; }
    }
}
