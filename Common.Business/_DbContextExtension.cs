using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public static class _DbContextExtension
    {
        public static Task<List<TSource>> ToListAsyncSafe<TSource>(this IQueryable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!(source is IDbAsyncEnumerable<TSource>))
                return Task.FromResult(source.ToList());
            return source.ToListAsync();
        }

        public static bool CheckConnection(this DbContext context)
        {
            try
            {
                context.Database.Connection.Open();
                context.Database.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T GetRandomEntity<T>(this DbContext ctx) where T : AuditEntity
        {
            var rand = new Random();
            var skip = (int)(rand.NextDouble() * ctx.Set<T>().Count());
            return ctx.Set<T>().OrderBy(o => o.Id).Skip(skip).Take(1).First();
        }

        public static void Load(this DbContext ctx, ref AuditEntity entity, long id)
        {
            var dbSet = ctx.Set(entity.GetType());
            entity = (AuditEntity)dbSet.Find(id);
        }

        public static async Task<AuditEntity> FindAsync(this DbContext ctx, Type type, long id)
        {
            var dbSet = ctx.Set(type);
            object result = await dbSet.FindAsync(id);
            return result as AuditEntity;
        }

        public static long MaxOrDefault<T>(this DbContext ctx, Expression<Func<T, long>> predicate) where T : AuditEntity
        {
            var result = ctx.Set<T>().Select(predicate).DefaultIfEmpty(0).Max();
            return result;
        }

        public static IList<T> GetAll<T>(this DbContext ctx, bool enabled = true) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => x.Enabled == enabled).ToList();
            return result;
        }

        public static async Task<T[]> GetAllAsync<T>(this DbContext ctx, bool enabled = true) where T : AuditEntity
        {
            var result = await ctx.Set<T>().Where(x => x.Enabled).ToArrayAsync();
            return result;
        }

        public static IList<T> Where<T>(this DbContext ctx, Expression<Func<T, bool>> predicate, bool asNoTrcaking = false) where T : AuditEntity
        {
            var query = ctx.Set<T>().Where<T>(predicate);
            if (asNoTrcaking)
                query = query.AsNoTracking();
            return query.ToList();
        }

        public static async Task<T[]> WhereAsync<T>(this DbContext ctx, Expression<Func<T, bool>> predicate, bool asNoTrcaking = false) where T : AuditEntity
        {
            var query = ctx.Set<T>().Where<T>(predicate);
            if (asNoTrcaking)
                query = query.AsNoTracking();
            var result = await query.ToArrayAsync<T>();
            return result;
        }

        public static int Count<T>(this DbContext ctx, Expression<Func<T, bool>> predicate, bool asNoTrcaking = false) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where<T>(predicate).Count();
            return result;
        }

        public static IList<T> Where<T>(this DbContext ctx, Expression<Func<T, bool>> predicate, params string[] includes) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where<T>(predicate);
            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result.ToList();
        }

        public static IList<T> Search<T>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int take = 0, params string[] includes) where T : AuditEntity
        {
            return Search<T>(ctx, filterBy, filterValue, onlyEnabled, take, null, includes);
        }

        public static IList<T> Search<T>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int pageIndex, int pageSize, bool asNotTracking, params string[] includes) where T : AuditEntity
        {
            return Search<T>(ctx, filterBy, filterValue, onlyEnabled, pageIndex, pageSize, asNotTracking, null, includes);
        }

        public static IList<T> Search<T>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int take, Expression<Func<T, bool>> where = null, params string[] includes) where T : AuditEntity
        {
            return Search<T>(ctx, filterBy, filterValue, onlyEnabled, take, false, where, includes);
        }

        public static IList<T> Search<T>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int pageIndex, int pageSize, bool asNotTracking, Expression<Func<T, bool>> where = null, params string[] includes) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => !onlyEnabled || (onlyEnabled && x.Enabled));
            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            if (!string.IsNullOrEmpty(filterBy))
            {
                var properties = filterBy.Split('|');
                Expression<Func<T, bool>> predicate = null;
                for (var i = 0; i < properties.Length; i++)
                {
                    var filters = properties[i].Split('.');
                    if (i == 0)
                        predicate = ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters);
                    else
                        predicate = predicate.Or(ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters));
                }

                result = result.Where(predicate);
            }

            result = result.OrderByDescending(x => x.Id);

            if (where != null)
            {
                result = result.Where(where);
            }
            if (pageSize > 0)
            {
                result = result.Skip(pageSize * pageIndex).Take(pageSize);
            }

            if (asNotTracking)
                return result.AsNoTracking<T>().ToList();
            else
                return result.ToList<T>();
        }


        public static IList<T> Search<T>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int take, bool asNotTracking, Expression<Func<T, bool>> where = null, params string[] includes) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => !onlyEnabled || (onlyEnabled && x.Enabled));
            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            if (!string.IsNullOrEmpty(filterBy))
            {
                var properties = filterBy.Split('|');
                Expression<Func<T, bool>> predicate = null;
                for (var i = 0; i < properties.Length; i++)
                {
                    var filters = properties[i].Split('.');
                    if (i == 0)
                        predicate = ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters);
                    else
                        predicate = predicate.Or(ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters));
                }

                result = result.Where(predicate);
            }

            result = result.OrderByDescending(x => x.Id);

            if (where != null)
            {
                result = result.Where(where);
            }
            if (take > 0)
            {
                result = result.Take(take);
            }

            if (asNotTracking)
                return result.AsNoTracking<T>().ToList();
            else
                return result.ToList<T>();
        }

        public static IList<T> Search<T, TSortBy>(this DbContext ctx, string filterBy, string filterValue, bool onlyEnabled, int take, Expression<Func<T, bool>> where, Expression<Func<T, TSortBy>> sort, string sortDirection, params string[] includes) where T : AuditEntity
        {
            var result = ctx.Set<T>().Where(x => !onlyEnabled || (onlyEnabled && x.Enabled));
            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            if (!string.IsNullOrEmpty(filterBy))
            {
                var properties = filterBy.Split('|');
                Expression<Func<T, bool>> predicate = null;
                for (var i = 0; i < properties.Length; i++)
                {
                    var filters = properties[i].Split('.');
                    if (i == 0)
                        predicate = ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters);
                    else
                        predicate = predicate.Or(ExpressionBuilder.BuildPredicate<T>(filterValue, OperatorComparer.Contains, filters));
                }

                result = result.Where(predicate);
                result.OrderBy(x => x.Created);
            }

            if (where != null)
            {
                result = result.Where(where);
            }
            switch (sortDirection.ToUpper())
            {
                case "ASC":
                    result = result.OrderBy(sort);
                    break;
                default:
                    result = result.OrderByDescending(sort);
                    break;
            }

            if (take > 0)
            {
                result = result.Take(take);
            }

            return result.ToList<T>();
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
                //ctx.SaveChanges();
            }
            return aux;
        }

        public static void Save(this DbContext ctx, AuditEntity entity)
        {
            if (entity.IsNew)
                ctx.Set(entity.GetType()).Add(entity);
            else
            {
                ctx.Entry(entity).State = EntityState.Modified;
            }

            //ctx.SaveChanges();
        }

        public static void Delete(this DbContext ctx, AuditEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            //ctx.SaveChanges();
        }
    }
}
