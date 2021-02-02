﻿using Microsoft.EntityFrameworkCore.Query;
using PP.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PP.Dominio.Repositorio
{
    public interface IRepositorio<T> where  T : EntityBase
    {
        Task Create(T entity);

        Task UpDate(T entity);

        Task Delete(T entity);


        Task<T> GetById(long id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);

        // ==================================================================================//

        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);


        //=================================================================================//

        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = true);
    }
}
