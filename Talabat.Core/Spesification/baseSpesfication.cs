using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Spesificatio;

namespace Talabat.Core.Spesification
{
    public class baseSpesfication<T> : Ispesfication<T> where T : baseEntity
    {

        public Expression<Func<T, bool>> Cretiria { get; set; }
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();

        public baseSpesfication()
        {
        }

        public baseSpesfication(Expression<Func<T, bool>> CretiriaExpression)
        {
            Cretiria = CretiriaExpression;
        }
    }
}
