using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApiREST.DataProvider;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiREST.ServicesImp
{
    public static class ExtensionMethods
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(predicate1, param),
                    Expression.Invoke(predicate2, param)
                );
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }
        public static Func<T, bool> AndAlso<T>(this Func<T, bool> predicate1, Func<T, bool> predicate2)
        {
            return arg => predicate1(arg) && predicate2(arg);
        }
    }

    public class BaseServicesImp<TEntity> : IBaseServices<TEntity> where TEntity : BaseEntity
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public BaseServicesImp(SecurityDbContext context)
        {
            this.context = (DbContext)context;
            dbSet = ((DbContext)context).Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> filter, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var aux = query.Where(filter);

            return query.Where(filter).ToList();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }
        public virtual IEnumerable<TEntity> Get(string includeProperties)
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }
        public virtual IEnumerable<TEntity> Get(List<Func<TEntity, bool>> filtros, string includeProperties, Int32 NroPagina = 0, Int32 RegistrosPorPagina = int.MaxValue)
        {

            Func<TEntity, bool> filter = x => x.Id > 0;
            foreach (var item in filtros)
            {
                filter = filter.AndAlso(item);
            }

            IQueryable<TEntity> query = dbSet;
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(NroPagina * RegistrosPorPagina)
                .Take(RegistrosPorPagina).ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            var result = dbSet.Add(entity).Entity;
            context.SaveChanges();
            return result;
        }

        public virtual void Delete(object id)
        {

            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAsNoTracking(Func<TEntity, bool> query)
        {
            IQueryable<TEntity> dbset = dbSet.AsNoTracking();

            return dbset.Where(query);

        }

        public virtual Int32 Count()
        {
            return dbSet.Count();
        }
    }
}