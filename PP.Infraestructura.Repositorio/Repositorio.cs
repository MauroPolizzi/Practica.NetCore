using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PP.Dominio.Base;
using PP.Dominio.Repositorio;
using PP.Infraestructura.Context;

namespace PP.Infraestructura.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntityBase
    {
        #region Persistencia

        public async Task Create(T entity)
        {
            using (var context = new DataContext())
            {
                await context.Set<T>().AddAsync(entity);

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Deleted;

                context.Set<T>().Remove(entity);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpDate(T entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Modified;

                context.Set<T>().Update(entity);

                await context.SaveChangesAsync();
            }
        }

        #endregion



        #region Consulta

        public Task<System.Collections.Generic.IEnumerable<T>>
            GetAll(System.Func<System.Linq.IQueryable<T>, System.Linq.IOrderedQueryable<T>> orderBy = null, System.Func<System.Linq.IQueryable<T>
                , Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null, bool enabledTraking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<T>>
            GetByFilter(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate = null, System.Func<System.Linq.IQueryable<T>
                , System.Linq.IOrderedQueryable<T>> orderBy = null, System.Func<System.Linq.IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T
                , object>> include = null, bool enabledTraking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetById(long id, System.Func<System.Linq.IQueryable<T>
            , Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null, bool enabledTraking = true)
        {
            throw new System.NotImplementedException();
        } 

        #endregion

    }
}
