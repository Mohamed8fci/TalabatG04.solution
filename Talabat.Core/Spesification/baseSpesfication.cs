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
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public baseSpesfication()
        {
        }

        public baseSpesfication(Expression<Func<T, bool>> CretiriaExpression)
        {
            Cretiria = CretiriaExpression;
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpresion)
        {
            OrderBy = orderByExpresion;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpresion)
        {
            OrderByDescending = orderByDescExpresion;
        }

        public void ApplyPagination(int skip,int take)
        {
            IsPaginationEnabled = true;
            Take = take;
            Skip = skip;
        }

    }
}
