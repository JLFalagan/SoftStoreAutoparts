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
using System.Threading.Tasks;

namespace Common.Extension
{
    public static class SystemExtension
    {
        public static Type GetBaseType(this object entity)
        {
            var thisType = entity.GetType();

            if (thisType.Namespace == "System.Data.Entity.DynamicProxies")
                return thisType.BaseType;

            return thisType;
        }

        public static string GetDiscriminatorFromType(this object entity)
        {
            return entity.GetBaseType().Name;
        }

        public static string ToddMMyyyy(this DateTime value) => value.ToString("dd/MM/yyyy");

        public static string ToyyyyMMdd(this DateTime value) => value.ToString("yyyy/MM/dd");

        public static string ToddMMyyyyHHmm(this DateTime value) => value.ToString("dd/MM/yyyy HH:mm");

        #region Decimal
        public static Decimal ToDecimal(this Double value) => Convert.ToDecimal(value);
        #endregion

        #region Double
        public static Double ToDouble(this Decimal value) => Convert.ToDouble(value);
        #endregion

        #region Int
        public static int ToInt32(this long value) => Convert.ToInt32(value);
        public static long ToInt64(this long value) => Convert.ToInt64(value);
        public static long ToInt64(this Enum enumValue)
        {
            return (long)((object)enumValue);
        }
        public static T ToEnum<T>(this long value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static long ToInt64(this object value) => Convert.ToInt64(value);

        #endregion

        public static byte[] ToByteArray(this Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        public static string GetStringBase64(this Stream stream)
        {
            if (stream != null)
            {
                stream.Seek(0, SeekOrigin.Begin);
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }

                return bytes.GetStringBase64();
            }
            else
                return null;

        }

        public static string GetStringBase64(this byte[] bytes)
        {
            string base64 = Convert.ToBase64String(bytes);
            return base64;

        }

        public static Object GetValueByProperty(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);

                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetValueByProperty<T>(this Object obj, String name)
        {
            Object retval = GetValueByProperty(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static string GetValueByProperty(this Object obj, String name, string formatString)
        {
            Object retval = GetValueByProperty(obj, name);
            if (retval != null)
            {
                Type type = retval.GetType();
                switch (type.Name)
                {
                    case "Boolean":
                        var bVal = (bool)retval;
                        return bVal ? "Si" : "No";
                    case "Int64":
                    case "Int32":
                        var iVal64 = Convert.ToInt64(retval);
                        if (!string.IsNullOrEmpty(formatString))
                            return string.Format(formatString, iVal64);
                        else return iVal64.ToString();
                    case "Decimal":
                        var dVal = Convert.ToDecimal(retval);
                        if (!string.IsNullOrEmpty(formatString))
                            return string.Format(formatString, dVal);
                        else return dVal.ToString();
                    case "DateTime":
                        var dtVal = Convert.ToDateTime(retval);
                        if (!string.IsNullOrEmpty(formatString))
                            return string.Format(formatString, dtVal);
                        else
                            return dtVal.ToString();
                    case "String":
                        var sVal = Convert.ToString(retval);
                        if (!string.IsNullOrEmpty(formatString))
                            return string.Format(formatString, sVal);
                        else
                            return sVal;
                    default: return retval.ToString();
                }
            }
            else
                return string.Empty;
        }

        public static object ChangeType(this object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int retVal = 0;
            foreach (var item in items)
            {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> items) where T : new()
        {
            return new ObservableCollection<T>(items);
        }

        public static bool Exists<T>(this ICollection<T> colletion, Expression<Func<T, bool>> where) where T : new()
        {
            var entity = colletion.AsQueryable<T>().SingleOrDefault<T>(where);

            return entity != null;
        }

        public static Dictionary<string, object> AddOrUpdate(this Dictionary<string, object> dic, string key, object obj)
        {
            object aux;
            if (dic.TryGetValue(key, out aux))
                dic[key] = obj;
            else
                dic.Add(key, obj);
            return dic;
        }

        public static Dictionary<string, string> AddOrUpdate(this Dictionary<string, string> dic, string key, string obj)
        {
            string aux;
            if (dic.TryGetValue(key, out aux))
                dic[key] = obj;
            else
                dic.Add(key, obj);
            return dic;
        }

        public static bool TryParseExactExt(this DateTime date, string s, out DateTime result)
        {
            bool retVal = DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            return retVal;
        }

    }

}
