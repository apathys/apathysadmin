using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 用户Cookie管理
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 写Cookie值， 名称 ，值，代表浏览器的js不能获取到cookie的值
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sValue"></param>
        /// <param name="httpOnly"></param>
        public void WriteCookie(string sName, string sValue, bool httpOnly = true) {
            IHttpContextAccessor hca = GlobalContent.ServiceProvider?.GetService<IHttpContextAccessor>(); 
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(30);
            option.HttpOnly = httpOnly;
            option.SameSite = SameSiteMode.Lax;
            hca?.HttpContext?.Response.Cookies.Append(sName,sValue,option);
        }

        /// <summary>
        /// 写Cookie值， 名称 ，值，代表浏览器的js不能获取到cookie的值
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sValue"></param>
        /// <param name="httpOnly"></param>
        public void WriteCookie(string sName, string sValue,int expire, bool httpOnly = true)
        {
            IHttpContextAccessor hca = GlobalContent.ServiceProvider?.GetService<IHttpContextAccessor>();
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(expire);
            option.HttpOnly = httpOnly;
            option.SameSite = SameSiteMode.Lax;
            hca?.HttpContext?.Response.Cookies.Append(sName, sValue, option);
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public string GetCookie(string sName) {
            IHttpContextAccessor hca = GlobalContent.ServiceProvider?.GetService<IHttpContextAccessor>();
            return hca?.HttpContext?.Request.Cookies[sName];
        }

        public void RemoveCookie(string sName)
        {
            IHttpContextAccessor hca = GlobalContent.ServiceProvider?.GetService<IHttpContextAccessor>();
            hca?.HttpContext?.Response.Cookies.Delete(sName);
        }

    }
}
