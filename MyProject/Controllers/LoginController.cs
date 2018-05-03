using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.Bll;

namespace MyProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("login");
        }


        [HttpPost]
        public void CheckLogin(FormCollection form)
        {
            string strLoginType = form["LoginType"];
            string strIsAutoLogin = form["isAutoLogin"];
            string strCaptcha = form["Captcha"];
            string Username = form["Username"];
            string Password = form["Password"];
            EFDbContext db = BaseBll.db;
                if (strLoginType == "user")
                {
                    IQueryable<UserInfo> userAccout = db.UserInfo.Where(o => o.Username == Username);
                    if (userAccout.FirstOrDefault() == null)
                    {
                        AjaxHelps.WriteErrorJson("该用户名不存在!");
                    }
                    UserInfo ui = userAccout.Where(o => o.Password == Password).SingleOrDefault();
                    if (ui == null)
                    {
                        AjaxHelps.WriteErrorJson("用户名或密码错误!");
                    }

                    if (Session[Key.CAPTCHA].ToString() != strCaptcha)
                    {
                        AjaxHelps.WriteErrorJson("验证码错误!");
                    }

                    Session[Key.Current_User] = ui;
                    GenerateCookie(strIsAutoLogin, ui.Uid.ToString(), 1);
                    AjaxHelps.WriteSucessJson("登录成功");
                }
                else
                {
                    IQueryable<CompanyInfo> userAccout = db.CompanyInfo.Where(o => o.Username == Username);
                    if (userAccout.FirstOrDefault() == null)
                    {
                        AjaxHelps.WriteErrorJson("该用户名不存在!");
                    }
                    CompanyInfo ci = userAccout.Where(o => o.PassWord == Password).SingleOrDefault();
                    if (ci == null)
                    {
                        AjaxHelps.WriteErrorJson("用户名或密码错误!");
                    }

                    if (Session[Key.CAPTCHA].ToString() != strCaptcha)
                    {
                        AjaxHelps.WriteErrorJson("验证码错误!");
                    }

                    Session[Key.Current_Company] = ci;
                    GenerateCookie(strIsAutoLogin, ci.CompanyId.ToString(), 2);
                    AjaxHelps.WriteSucessJson("登录成功");
                }
        }

        /// <summary>
        /// 获取验证码图片Action
        /// </summary>
        /// <returns></returns>
        public ActionResult GetimgAction()
        {
            byte[] buff = GetCaptcha();
            return File(buff, "image/jpeg");
        }

        #region 验证码

        private byte[] GetCaptcha()
        {
            string captcha = string.Empty;
            Response.ContentType = "image/jpeg";

            using (Image img = new Bitmap(100, 30))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    //背景色
                    g.Clear(Color.White);

                    //边框
                    g.DrawRectangle(Pens.Black, 0, 0, img.Width - 2, img.Height - 2);

                    //随机数
                    captcha = GenerateRandomNumber(4);
                    g.DrawString(captcha, new Font("宋体", 20, FontStyle.Bold | FontStyle.Italic), Brushes.Red, new PointF(15, 2));

                    //噪点
                    this.DrawLine(g, img.Width, img.Height, Pens.YellowGreen, 15);
                }

                Session[Key.CAPTCHA] = captcha.ToLower();//保存随机数
                //img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                //MemoryStream 内存流
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }

        }

        #region 画噪点
        /// <summary>
        /// 画噪点
        /// </summary>
        /// <param name="g">Graphics对象</param>
        /// <param name="imgWidth">验证码宽度</param>
        /// <param name="imgHeight">验证码高度</param>
        /// <param name="pen">线条颜色</param>
        /// <param name="lineCount">画多少条线</param>
        private void DrawLine(Graphics g, int imgWidth, int imgHeight, Pen pen, int lineCount)
        {
            Random r = new Random();

            for (int i = 0; i < lineCount; i++)
            {
                int x1 = r.Next(1, imgWidth - 2);
                int y1 = r.Next(1, imgHeight - 2);
                int x2 = r.Next(1, imgWidth - 2);
                int y2 = r.Next(1, imgHeight - 2);

                g.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y2));
            }
        }
        #endregion

        #region 生成随机数
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="count">生成个数</param>
        /// <returns></returns>
        private string GenerateRandomNumber(int count)
        {
            string strAll = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";//去除大写O
            string strNumber = string.Empty;
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, strAll.Length);
                strNumber += strAll.Substring(index, 1);
            }
            return strNumber;
        }
        #endregion

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAutoLogin"></param>
        /// <param name="userId"></param>
        /// <param name="type">用户类型 1 为公司 2 为普通用户</param>
        public void GenerateCookie(string isAutoLogin, string userId, int type)
        {
            bool autologin = false;
            if (string.IsNullOrWhiteSpace(isAutoLogin) || !bool.TryParse(isAutoLogin, out autologin))
            {
                return;
            }
            if (!autologin)
            {
                return;
            }
            string value = CryptoHelper.TripleDES_Encrypt(userId, Key.TRIPLEDES_KEY);
            HttpCookie hc;
            if (type == 1)
            {
                 hc = new HttpCookie("UserId", value);
            }
            else
            {
                 hc = new HttpCookie("CompanyId", value);
            }
            hc.Expires = DateTime.Now.AddDays(2);
             Response.Cookies.Add(hc);            
        }


        /// <summary>
        /// 清除用户Session
        /// </summary>
        public ActionResult ClearUserSession()
        {
            Session[Key.Current_User] = null;
            Session[Key.Current_Company] = null;
            return RedirectToAction("Index");
        }

    }
}