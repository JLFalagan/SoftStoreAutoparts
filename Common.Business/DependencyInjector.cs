using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public class DependencyInjector
    {
        private static Dictionary<Type, Type> Mappings = new Dictionary<Type, Type>();

        public static T Get<T>()
        {
            var type = typeof(T);
            return (T)Get(type);
        }

        private static object Get(Type type)
        {
            var target = ResolveType(type);
            var constructor = target.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> resolvedParameters = new List<object>();

            foreach (var item in parameters)
            {
                resolvedParameters.Add(Get(item.ParameterType));
            }

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private static Type ResolveType(Type type)
        {
            if (Mappings.Keys.Contains(type))
            {
                return Mappings[type];
            }

            return type;
        }

        public static void Map<T, V>() where V : T
        {
            Mappings.Add(typeof(T), typeof(V));
        }

        public static void Clear()
        {
            Mappings.Clear();
        }
    }
}
