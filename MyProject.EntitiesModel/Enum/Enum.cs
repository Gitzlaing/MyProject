using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Common;
namespace MyProject.EntitiesModel.Enum
{
    /// <summary>
    /// 投递简历枚举
    /// </summary>
    public enum ResumeStatus
    {
        [EnumDescription("等待中")]
        Waiting = 0,
        [EnumDescription("已接受")]
        Accepted = 1,
        [EnumDescription("面试中")]
        Interviewing = 2,
        [EnumDescription("已拒绝")]
        Refused = 3
    }
}
