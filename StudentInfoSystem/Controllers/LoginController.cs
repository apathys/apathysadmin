using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.IService.SysBasic;
using StudentInfoSystem.Models.Model;
using System; 
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks; 

namespace StudentInfoSystem.Controllers
{
    public class LoginController :Controller
    {
        private readonly ISys_UserService _sys_UserService;
        private IMemoryCache _memoryCache;
        public LoginController(ISys_UserService sys_UserService, 
            IMemoryCache memoryCache)
        {
            _sys_UserService = sys_UserService;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("hbes_login_user") != null)
            {//添加session
                HttpContext.Session.SetString("hbes_login_user",null);
            }

            if (Request.Cookies["hbes_login_username"] != null)
            {

                //设置cookie的过期时间
                HttpContext.Response.Cookies.Append("hbes_login_username",
                    Request.Cookies["hbes_login_username"], new CookieOptions
                {
                    Expires = DateTime.Now.AddMilliseconds(3600)
                });
                

            }
            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            ResultMsg result = new ResultMsg();
            var checkCookie = "";
            HttpContext.Request.Cookies.TryGetValue("checkCode", out checkCookie);

            if (string.IsNullOrEmpty(user.userName))
            {
                result.IsSuccess = false;
                result.Msg = "请输入用户名！";
            }
            else if (string.IsNullOrEmpty(user.password))
            {
                result.IsSuccess = false;
                result.Msg = "请输入密码！";
            }
            else if (string.IsNullOrEmpty(user.checkCode))
            {
                result.IsSuccess = false;
                result.Msg = "请输入验证码！";
            }
            else if (checkCookie == null)
            {
                result.IsSuccess = false;
                result.Msg = "验证码过期！";
            }


            var model = _sys_UserService.GetWhereData(u => u.UserName == user.userName).ToList();

            if (model == null || model.Count == 0)
            {
                result.IsSuccess = false;
                result.Msg = "用户或密码不正确！";
            }
            else if (model.Count>1) {
                result.IsSuccess = false;
                result.Msg = "用户或密码不正确！";
            }
            else
            {
                XxsModel.SysBasic.Sys_User _user = model[0];
                //user.password = Common.MD5Helper.GetMD5(user.password);
                if (true) //_user.Password.Equals(user.password) 验证密码
                {
                    result.IsSuccess = true;
                    result.Msg = "登录成功";

                     //登录成功后的用户数据缓存功能还没做。
                    

                } 
            }


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return Content(json);
        }
        public IActionResult CheckCode()
        {
            string checkCode = GetRandomCode(4);
            int iwidth = (int)(checkCode.Length * 14);
            Bitmap image = new Bitmap(iwidth, 25);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Font f = new System.Drawing.Font("Arial ", 10);//, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(Color.Black);
                Brush r = new System.Drawing.SolidBrush(Color.FromArgb(166, 8, 8));

                g.Clear(System.Drawing.ColorTranslator.FromHtml("#99C1CB"));//背景色

                char[] ch = checkCode.ToCharArray();
                for (int i = 0; i < ch.Length; i++)
                {
                    if (ch[i] >= '0' && ch[i] <= '9')
                    {
                        //数字用红色显示
                        g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                    }
                    else
                    {   //字母用黑色显示
                        g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                    }
                }

                MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                Response.Cookies.Append("checkCode", checkCode.ToUpper());

                return File(ms.ToArray(), "image/jpeg");
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        private string GetRandomCode(int CodeCount)
        {
            string allChar = "0,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(32);

                while (temp == t)
                {
                    t = rand.Next(32);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }

    }
}
