using Common.Model;
using Common.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public static class BaseBusiness
    {
        private static I CreateInstance<I>(string typeName, string assemblyPath) where I : class
        {
            Assembly assembly;
            assembly = Assembly.LoadFrom(assemblyPath);
            Type type = assembly.GetType(typeName);
            return Activator.CreateInstance(type) as I;
        }

        internal static DbContext CreateDbContext() //BaseModelContext
        {
            //Version NetStandar
            //var dbContextType = ConfigurationManager.AppSettings["NeyTI.DbContextType"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] dbContextType = new string[] { "NeyTI.DbContextType", ", " }; //Implementar lectura por Json o Recursos de parametros
            string assemblyPath = $@"{Environment.CurrentDirectory}\{dbContextType[1]}.dll";
            return CreateInstance<DbContext>(dbContextType[0], assemblyPath);
        }

        public static void Save(this AuditEntity entity, DbContext ctx) //BaseModelContext - Version NetStandar
        {
            //if (entity.IsNew)
            //    ctx.Set(entity.GetType()).Add(entity);

            if (entity.IsNew)
                ctx.Set<AuditEntity>().Add(entity);

            ctx.SaveChanges();
        }

        public static void Delete(this AuditEntity entity, DbContext ctx)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges();
        }

    }

}
