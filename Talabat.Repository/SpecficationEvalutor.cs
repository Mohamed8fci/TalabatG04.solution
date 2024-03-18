using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Spesificatio;

namespace Talabat.Repository
{
    public static class SpecficationEvalutor <TEntity> where TEntity : baseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, Ispesfication<TEntity> spec )
        {
            var query = inputQuery; // query = _dbcontext.product

            if (spec.Cretiria is not null)  //p=>p.id==1
            {
                query = query.Where(spec.Cretiria);

            }


            // query = _dbcontext.product.where(p=>p.id==1)
            //1- include with  p=>p.ProductBrand
            //2- include with  p=>p.ProductType


            if (spec.OrderBy is not null) //p=>p.price
                query = query.OrderBy(spec.OrderBy);

            //query = DbContext.products.orderby(p=>p.price);

            if (spec.OrderByDescending is not null) //p=>p.price
                query = query.OrderByDescending(spec.OrderByDescending);


            if(spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);
            
            query = spec.Include.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
            
            return query;
        }
    }
}
