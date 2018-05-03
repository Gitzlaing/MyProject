using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models.BakModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class UserInfo
    {
        public int Uid { get; set; }

        [Required(ErrorMessage = "*请输入用户名")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "*长度为4~10位")]
        [Remote("CheckUsername", "User", ErrorMessage = "*该用户已存在!", HttpMethod = "post")]
        [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "*包含非法字符")]
        public string Username { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*请输入密码")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "*两次密码不一致")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string School { get; set; }
        public string Describe { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Knowledge { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Specialty { get; set; }
    }
}