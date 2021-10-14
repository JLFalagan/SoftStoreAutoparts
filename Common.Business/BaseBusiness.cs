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

        internal static BaseModelContext CreateDbContext()
        {
            var dbContextType = ConfigurationManager.AppSettings["NeyTI.DbContextType"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string assemblyPath = $@"{Environment.CurrentDirectory}\{dbContextType[1]}.dll";
            return CreateInstance<BaseModelContext>(dbContextType[0], assemblyPath);
        }

        public static void Save(this AuditEntity entity, BaseModelContext ctx)
        {
            if (entity.IsNew)
                ctx.Set(entity.GetType()).Add(entity);

            //ctx.SaveChanges();
        }

        public static void Delete(this AuditEntity entity, DbContext ctx)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            //ctx.SaveChanges();
        }

    }

}
