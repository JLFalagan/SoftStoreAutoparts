//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace NeyTI.Core.Model
//{
//    public class EnumItem
//    {
//        public long Id { get; set; }

//        public long Display { get; set; }
//    }

//    public static class EnumHelper
//    {
//        public static EnumItem[] GetEnumItems<T>()
//        {
//            var items = new List<EnumItem>();

//            foreach (var item in Enum.GetValues(typeof(T)))
//            {
                
//            }
//           // Enum.Parse(typeof(T), )

//            return items.ToArray();
//        }

//        public static string GetDisplay(this Enum value)
//        {
//            //Type type = value.GetType();
//            //string name = Enum.GetName(type, value);
//            //if (name != null)
//            //{
//            //    FieldInfo field = type.GetField(name);
//            //    if (field != null)DisplayAttribute
//            //    {
//            //        DisplayAttribute attr =
//            //               Attribute.GetCustomAttribute(field,
//            //                 typeof()) as DisplayAttribute;
//            //        if (attr != null)
//            //        {
//            //            return attr.Description;
//            //        }
//            //    }
//            //}
//            return null;
//        }

//        //public static string GetDescription(Type type)
//        //{

//        //    Enum.GetValues(type);
//        //}
             
//    }
//}
