using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
//using Z.Expressions;

namespace Common.EFCore
{
    public static class ExtensionEntity
    {
        public static object ReflectPropertyValue(object source, string property)
        {
            return source.GetType().GetProperty(property).GetValue(source, null);
        }

        public static IQueryable<T> WhereStringContains<T>(this IQueryable<T> query, string propertyName, string contains)
        {
            var result = query;
            //string[] words = contains.Split(',');
            string[] atributes = propertyName.Split(',');
            //if (words.Count() != atributes.Count())
            //    return null;
            for (int i = 0; i < atributes.Count(); i++)
            {
                var propertyType = typeof(T).GetProperty(atributes[i]).PropertyType;

                var typeName = propertyType.Name;
                var nullType = Nullable.GetUnderlyingType(propertyType);
                if (nullType != null)
                    typeName = nullType.Name;

                var parameter = Expression.Parameter(typeof(T), "type");
                var propertyExpression = Expression.Property(parameter, atributes[i]);
                switch (typeName)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Boolean":
                    case "DateTime"://TODO: NO FUNCIONA
                        var type = typeof(T);
                        var x = Expression.Parameter(type, "x");
                        var member = Expression.Property(x, atributes[i]);
                        ConstantExpression constant;
                        MethodInfo toStringMethod = typeof(object).GetMethod("ToString");
                        MethodInfo method2 = typeof(string).GetMethod("Equals", new[] { typeof(string) });
                        constant = Expression.Constant(contains);
                        var memberToStringCall = Expression.Call(member, toStringMethod);
                        var call = Expression.Call(memberToStringCall, method2, constant);
                        result = query.Where(Expression.Lambda<Func<T, bool>>(call, x));
                        break;
                    case "String":
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var someValue = Expression.Constant(contains, typeof(string));
                        var containsExpression = Expression.Call(propertyExpression, method, someValue);
                        result = query.Where(Expression.Lambda<Func<T, bool>>(containsExpression, parameter));
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            var ordenamiento = "OrderBy";
            if (string.IsNullOrEmpty(propertyName))
            {
                propertyName = "Id";
                ordenamiento = "OrderBy";
            }
            if (propertyName.StartsWith("-"))
            {
                ordenamiento = "OrderByDescending";
                propertyName = propertyName.Replace("-", "");
            }
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var parameter = Expression.Parameter(typeof(T), "type");
            var propertyExpression = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(propertyExpression, new[] { parameter });

            return typeof(Queryable).GetMethods()
                                    .Where(m => m.Name == ordenamiento && m.GetParameters().Length == 2)
                                    .Single()
                                    .MakeGenericMethod(new[] { typeof(T), propertyType })
                                    .Invoke(null, new object[] { query, lambda }) as IOrderedQueryable<T>;
        }

        public enum Comparison
        {
            Equal,
            NotEqual,
            LessThan,
            LessThanOrEqual,
            GreaterThan,
            GreaterThanOrEqual
        }
        public static IQueryable<TSource> 
            Compare<TSource, TValue>( this IQueryable<TSource> source, Expression<Func<TSource, TValue>> selector,
            TValue value, Comparison comparison)
        {
            Expression left = selector.Body;
            Expression right = Expression.Constant(value, typeof(TValue));

            BinaryExpression body;
            switch (comparison)
            {
                case Comparison.LessThan:
                    body = Expression.LessThan(left, right);
                    break;
                case Comparison.LessThanOrEqual:
                    body = Expression.LessThanOrEqual(left, right);
                    break;
                case Comparison.Equal:
                    body = Expression.Equal(left, right);
                    break;
                case Comparison.NotEqual:
                    body = Expression.NotEqual(left, right);
                    break;
                case Comparison.GreaterThan:
                    body = Expression.GreaterThan(left, right);
                    break;
                case Comparison.GreaterThanOrEqual:
                    body = Expression.GreaterThanOrEqual(left, right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparison));
            }
            return source.Where(Expression.Lambda<Func<TSource, bool>>(body, selector.Parameters));
        }
    }
}