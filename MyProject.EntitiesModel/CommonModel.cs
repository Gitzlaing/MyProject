using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MyProject.EntitiesModel
{
   public partial class UserInfo
    {
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "*两次密码不一致")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string RePassword { get; set; }
        
    }

    public partial class CompanyInfo
    {
        [System.ComponentModel.DataAnnotations.Compare("PassWord", ErrorMessage = "*两次密码不一致")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string RePassWord { get; set; }
    }

    
}
