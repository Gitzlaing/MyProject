using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public enum AjaxStatus
    {
        [EnumDescription("成功")]
        Success = 0,
        [EnumDescription("错误")]
        Error = 1,
        [EnumDescription("未登录")]
        NotLogin = 2
    }
}
