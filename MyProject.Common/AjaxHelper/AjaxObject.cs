using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject.Common
{
    public class AjaxObject
    {
        public AjaxStatus Status { get; set; }   //ajax 回调状态码
        public object Data { get; set; }  //返回数据
        public string Msg { get; set; }   //返回文字信息
    }
}
