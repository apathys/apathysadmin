using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using XxsModel.SysBasic;

namespace StudentInfoSystem.Controllers
{
    /// <summary>
    /// 这里用来处理操作日志
    /// </summary>
    public class BaseController : Controller
    {
        public ISys_UserService userService;
        public IMemoryCache memoryCache;
        public ISys_AuthorityRequestService requestService;
        public BaseController(ISys_UserService _userService,
                              IMemoryCache _memoryCache,
                              ISys_AuthorityRequestService _requestService) {
            userService = _userService;
            memoryCache = _memoryCache;
            requestService = _requestService;
        }
        public Sys_User LoginUser
        {
            get
            {
                Sys_User user = new Sys_User();

                user.Id = Guid.Parse("502a60f3-8c55-4b4d-8186-001470344b8f");
                user.Name = "Admin";
                user.UserName = "Admin";
                user.Name = "Admin";
                return user;
                
            }
             
        }

        protected IList<Sys_AuthorityRequest> GetMyRequest()
        {
            if (memoryCache.Get("myRequest") != null)
            {
                return (IList<Sys_AuthorityRequest>)memoryCache.Get("myRequest");
            }
            else
            {
                IList<Sys_AuthorityRequest> list = requestService.GetRequestByUserId(this.LoginUser.Id.Value);
                memoryCache.Set("myRequest", list);
                return list;
            }
            
        }
        /// <summary>
        /// 添加cookie缓存不设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddCookie(string key, string value)
        {
            try
            {
                HttpContext.Response.Cookies.Append(key, value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加cookie缓存设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public void AddCookie(string key, string value, int time)
        {
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMilliseconds(time)
            });
        }
        /// <summary>
        /// 删除cookie缓存
        /// </summary>
        /// <param name="key"></param>
        public void DeleteCookie(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }
        /// <summary>
        /// 根据键获取对应的cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            var value = "";
            HttpContext.Request.Cookies.TryGetValue(key, out value);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = string.Empty;
            }
            return value;
        }

    }
}
