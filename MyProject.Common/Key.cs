using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public static class Key
    {
        public const string CAPTCHA = "Captcha";
        public const string Current_User = "CurrentUser";   //当前求职用户字段 
        public const string Current_Company = "Current_Company";//当前企业用户字段
        public const string Current_Operator = "Current_Operator";//当前管理员用户字段 
        /// <summary>
        /// 3DES加密解密的密钥  对称解密
        /// </summary>
        public const string TRIPLEDES_KEY = "5Av8pAXuCOcnNn1E";
    }
}
