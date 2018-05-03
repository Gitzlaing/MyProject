using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace MyProject.Common
{
    public  class AjaxHelps
    {
        private static void WriteJson(AjaxStatus status, string msg, object data)
        {
            AjaxObject model = new AjaxObject();
            model.Status = status;
            model.Msg = msg;
            model.Data = data;
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(model));
            HttpContext.Current.Response.End();
        }
        public static void WriteSucessJson(string msg="",object data=null)
        {
            WriteJson(AjaxStatus.Success, msg, data);
        }
        public static void WriteErrorJson(string msg = "", object data = null)
        {
            WriteJson(AjaxStatus.Error, msg, data);
        }
        public static void WriteSNotLoginJson(string msg = "", object data = null)
        {
            WriteJson(AjaxStatus.NotLogin, msg, data);
        }
      
    }
}
