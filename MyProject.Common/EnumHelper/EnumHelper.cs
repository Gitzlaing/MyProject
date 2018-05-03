using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public static class EnumHelper
    {
        public static string GetDesc<T>(long value)
        {
            T t =(T)Enum.Parse(typeof(T),value.ToString());
            return GetDesc(t);
        }

        public static string GetDesc<T>(this T e)
        {
            string desc = string.Empty; //枚举描述
            Type t = e.GetType();
            FieldInfo fi = t.GetField(e.ToString());
            if (!fi.IsDefined(typeof(EnumDescriptionAttribute), false))  //
            {
                return desc;
            }

            object[] obj = fi.GetCustomAttributes(typeof(EnumDescriptionAttribute),false);
            if (obj==null||obj.Length<=0)
            {
                return desc;
            }

            EnumDescriptionAttribute[] attrArr = obj as EnumDescriptionAttribute[];
            foreach (EnumDescriptionAttribute item in attrArr)
            {
                desc += item.Desc + " | ";
            }
            desc.TrimEnd(new char[]{ ' ', '|', ' ' });
            return desc;

        }
    }
}
