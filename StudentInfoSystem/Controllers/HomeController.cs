using Common.xxs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Services.IService.SysBasic;
using StudentInfoSystem.Models;
using StudentInfoSystem.Models.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using XxsModel.SysBasic;

namespace StudentInfoSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISys_MenuService menuService;
        private readonly IMemoryCache memoryCache;
        private readonly ISys_AuthorityRequestService requestService;
        //private readonly ISys_UserService userService;

        public HomeController(ILogger<HomeController> logger,
            ISys_MenuService _menuService, 
            ISys_UserService _userService,
            IMemoryCache _memoryCache,
            ISys_AuthorityRequestService _requestService):base(_userService, _memoryCache, _requestService)
        {
            _logger = logger;
            menuService = _menuService;
            memoryCache = _memoryCache;
        }

        public IActionResult Index()
        {
            try
            {
                //正在学习 NetCore项目开发
                //对此感兴趣的可以关注下，保持交流

                IList<Sys_Menu> listMenu = menuService.GetMyMenu(base.LoginUser.Id.Value);
                var menus = listMenu.Select(p => new { pid = p.ParentId, id = p.Id,
                    text = p.MenuName, Url = p.Url });
                ViewData["menu"] = XxsJsonHelp.Encode(menus);
                if (memoryCache.Get("myRequest") != null)
                {
                    memoryCache.Remove("myRequest");
                }

            }
            catch(Exception ex)
            {

            }


            return View();
        }

        public ActionResult GetButton()
        {
            string href = Request.Headers["Referer"].ToString();
            href = new Uri(href).AbsolutePath;
            
            if (href.IndexOf("?") > 0)
            {
                href = href.Substring(0, href.IndexOf("?"));
            }
            if (href.IndexOf("/") != 0)
            {
                href = "/" + href;
            }
            IList<Sys_AuthorityRequest> mrList = GetMyRequest();
            IList<Sys_AuthorityRequest> currentUrlRequest = mrList.Where(x => x.Url.Equals(href)).ToList();
            List<String> buttonId = new List<String>();

            foreach (Sys_AuthorityRequest req in currentUrlRequest)
            {
                if (!string.IsNullOrEmpty(req.ButtonId))
                {
                    buttonId.Add(req.ButtonId);
                }
            }
            return Content(XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, buttonId));
        }
        public IActionResult TestAdd() {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ResultMsg
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
    }
}
