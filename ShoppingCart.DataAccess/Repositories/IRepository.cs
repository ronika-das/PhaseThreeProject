﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repositories
{
    public interface IRepository<T> where T:class
    {
        //x=>x.id==id, _context.product.include("categories,tags").tolist()
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null,string includeProperties=null);

        T GetT(Expression<Func<T,bool>> predicate, string? includeProperties=null);
        void Add(T entity);

        T AddT(T entity);

      //T Add(T entity);
        void Delete(T entity);

        void Update(T entity);
        void DeleteData(T entity);
        void DeleteRange(IEnumerable<T> entity);
       
       // T GetById(T entity);
    }
}
