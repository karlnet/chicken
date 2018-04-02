using Chicken.Data.Entities;
using Chicken.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Chicken.Data
{
    public static class EFHelper
    {
        public static bool IsExists<T>(this AppDbContext db, Expression<Func<T, bool>> predicate) where T : class
        {
            DbSet<T> dbSet = db.Set<T>();
            bool isExists = dbSet.Where(predicate).Any();
            //bool isExists = dbSet.Any(predicate); //TODO: dbSet 中的元素必须全部满足 predicate 才为 true?
            return isExists;
        }

        public static IQueryable<T> Where<T>(this AppDbContext db, Expression<Func<T, bool>> predicate) where T : class
        {
            DbSet<T> dbSet = db.Set<T>();
            IQueryable<T> query = dbSet.Where(predicate);
            return query;
        }

        public static bool Insert<T>(this AppDbContext db, T entity, bool saveChanges = true) where T : class
        {

            DbSet<T> dbSet = db.Set<T>();
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Added;
            int effect = 0;
            try
            {
                effect = db.SaveChanges();
            }
            catch (Exception e)
            {
            }
            return effect == 1;

        }
        public static bool Update<T>(this AppDbContext db, T entity, bool saveChanges = true) where T : class
        {
            DbSet<T> dbSet = db.Set<T>();
            dbSet.Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            //if (saveChanges)
            //{
                int effect = db.SaveChanges();

                return effect == 1;
            //}
            //return null;
        }

        public static bool InsertOrUpdate<T>(this AppDbContext db, T entity, Expression<Func<T, bool>> predicate, bool saveChanges = true) where T : class
        {
            bool isExist = db.IsExists<T>(predicate);
            if (isExist)
            {

             return   db.Update<T>(entity, saveChanges);
            }
            else
            {
             return   db.Insert<T>(entity, saveChanges);
            }
        }



    }
}