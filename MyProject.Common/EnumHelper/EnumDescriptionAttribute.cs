using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class EnumDescriptionAttribute : Attribute
    {
        public string Desc { get; set; }
        public EnumDescriptionAttribute(string desc)
        {
            this.Desc = desc;
        }
    }
}
