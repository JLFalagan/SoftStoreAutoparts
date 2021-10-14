using Common.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Common.Model
{
   
    public static class DbContextExtension
    {

        public static DateTime GetServerDate(this BaseModelContext ctx)
        {
            //var dateQuery = ctx.Database.SqlQuery<DateTime>("SELECT GETDATE()");
            //DateTime serverDate = dateQuery.AsEnumerable().First();
            //return serverDate;
            return DateTime.Now;
        }

        public static T Load<T>(this DbContext ctx, long id, params string[] includes) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => x.Id == id);
            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result.SingleOrDefault();
        }

        public static T Load<T>(this DbContext ctx, long id) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => x.Id == id);

            return result.SingleOrDefault();
        }

        public static T SingleOrDefault<T>(this DbContext ctx, Expression<Func<T, bool>> predicate) where T : AuditEntity
        {
            var result = ctx.Set<T>().SingleOrDefault<T>(predicate);
            return result;
        }

        public static T FirstOrDefault<T>(this DbContext ctx, Expression<Func<T, bool>> predicate) where T : AuditEntity
        {
            var result = ctx.Set<T>().FirstOrDefault<T>(predicate);
            return result;
        }

        public static T GetOrDefineByName<T>(this DbContext ctx, string name, long id = 0) where T : BaseType
        {
            var aux = ctx.Set<T>().FirstOrDefault(x => x.Name == name);
            if (aux == null)
            {
                aux = Activator.CreateInstance<T>();
                aux.Name = name;
                aux.Id = id;
                ctx.Set<T>().Add(aux);
                ctx.SaveChanges();
            }
            ctx.Entry<T>(aux).State = EntityState.Unchanged;
            return aux;
        }

        public static T GetOrDefineByName<T>(this DbContext ctx, string name) where T : BaseType
        {
            var aux = ctx.Set<T>().FirstOrDefault(x => x.Name == name);
            if (aux == null)
            {
                aux = Activator.CreateInstance<T>();
                aux.Name = name;
                ctx.Set<T>().Add(aux);
                ctx.SaveChanges();
            }
            ctx.Entry<T>(aux).State = EntityState.Unchanged;
            return aux;
        }
    }

   
}
