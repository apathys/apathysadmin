﻿using Common;
using Common.xxs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.IService.SysBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XxsModel.SysBasic;

namespace StudentInfoSystem.Controllers
{
    public class MenuController : BaseController
    {

        public ISys_MenuService menuService; 
        public ISys_MenuAuthorityService menuAuthorityService;  
        public ISys_RoleAndAuthorityService roleAndAuthorityService;

        public ISys_UserService userService;
        public IMemoryCache memoryCache;
        public ISys_AuthorityRequestService requestService;

        public MenuController(ISys_UserService _userService, 
                              IMemoryCache _memoryCache,
                              ISys_AuthorityRequestService _requestService,
                              ISys_MenuService _menuService,
                              ISys_MenuAuthorityService _menuAuthorityService,
                              ISys_RoleAndAuthorityService _roleAndAuthorityService)
                              :base(_userService,_memoryCache,_requestService){

            userService = _userService;
            memoryCache = _memoryCache;
            requestService = _requestService;
            menuService = _menuService;
            menuAuthorityService = _menuAuthorityService;
            roleAndAuthorityService = _roleAndAuthorityService; 
        }

        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult List()
        {
            return View("MenuList");
        }
        public IActionResult Add(string parentId)
        {

            ViewData["parentId"] = parentId;
            return View("MenuAdd");
        }

        public IActionResult Edit(Guid id)
        {
            Sys_Menu eMen = menuService.GetByKey(id);
            string parentName = "";
            if (eMen.ParentId != null)
            {
                parentName = menuService.GetByKey(eMen.ParentId).MenuName;

            }
            if (eMen == null)
            {
                //Response.BodyWriter("<p style='color:red;'>该条记录不存在！</p>");
                //Response.End();
            }
            ViewData["parentName"] = parentName;
            return View("MenuEdit", eMen);
        }

        public IActionResult SetAuthority(Guid id)
        {
            ViewData["id"] = id;
            return View();
        }

        public IActionResult SetRequest(Guid authorityId)
        {
            ViewData["authorityId"] = authorityId;
            return View();
        }

        public IActionResult GetTreeData()
        {
            string resultJson = "";
            Expression<Func<Sys_Menu, bool>> expre = (m => true);
            OrderByHelper<Sys_Menu, int> Order = new OrderByHelper<Sys_Menu, int>() { OrderByType = OrderByType.ASC, Expression = m => m.OrderValue.Value };
            var menuList = menuService.GetWhereData(expre, Order).Select(m => new { id = m.Id, pid = m.ParentId, text = m.MenuName });
            resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, menuList);
            return Content(resultJson);
        }


        public IActionResult GetData()
        {
            string resultJson = "";
            Expression<Func<Sys_Menu, bool>> expre = (m => true);

            var queryParameters = HttpContext.Request.Form;
            string qstr = queryParameters["ParentId"];
             
 
            if (qstr != null && !string.IsNullOrEmpty(qstr.Trim()))
            {
                Guid parentId = Guid.Parse(qstr.Trim());
                expre = expre.And(m => m.ParentId == parentId);

            }
            else
            {
                expre = expre.And(m => m.ParentId == null);
            }
            OrderByHelper<Sys_Menu, int> Order = new OrderByHelper<Sys_Menu, int>() { OrderByType = OrderByType.ASC, Expression = m => m.OrderValue.Value };

            List<Sys_Menu> menuList = menuService.GetWhereData(expre, Order).ToList();
            resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, menuList);
            return Content(resultJson);
        }

        public ActionResult AddMenu(string data)
        {
            string resultJson = "";
            Hashtable ht = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_Menu eMenu = new Sys_Menu();
            eMenu.Id = Guid.NewGuid();
            Guid parentId;
            if (Guid.TryParse(ht["ParentId"].ToString(), out parentId))
            {
                eMenu.ParentId = parentId;
            }
            eMenu.MenuName = ht["MenuName"].ToString().Trim();
            eMenu.Url = ht["Url"].ToString().Trim();
            int OrderValue;
            if (int.TryParse(ht["OrderValue"].ToString(), out OrderValue))
            {
                eMenu.OrderValue = OrderValue;
            }
            if (menuService.Add(eMenu) > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "新增成功");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "新增失败");
            }

            return Content(resultJson);
        }

        public IActionResult EditMenu(string data)
        {
            string resultJson = "";
            Hashtable ht = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_Menu eMenu = menuService.GetByKey(Guid.Parse(ht["Id"].ToString()));
            if (eMenu == null)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该条记录不存在！");
                return Content(resultJson);
            }
            eMenu.MenuName = ht["MenuName"].ToString().Trim();
            eMenu.Url = ht["Url"].ToString().Trim();
            int OrderValue;
            if (int.TryParse(ht["OrderValue"].ToString(), out OrderValue))
            {
                eMenu.OrderValue = OrderValue;
            }
            if (menuService.Update(eMenu) > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "修改成功");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "修改失败");
            }
            return Content(resultJson);
        }

        public IActionResult DeleteMenu(Guid menuId)
        {
            string resultJson = "";
            int num = menuService.Delete(menuId);//删除菜单
            List<Sys_MenuAuthority> maList = menuAuthorityService.GetWhereData(ma => ma.MenuId == menuId).ToList();
            menuAuthorityService.Delete(maList);//菜单菜单权限

            if (maList.Count > 0)
            {
                List<Guid> authorityIds = maList.Select(x => x.Id.Value).ToList();

                Expression<Func<Sys_AuthorityRequest, bool>> exp = r => authorityIds.Contains<Guid>(r.AuthorityId.Value);
                requestService.Delete(r => (authorityIds.Contains(r.AuthorityId.Value)));//删除菜单权限请求


                roleAndAuthorityService.Delete(raa => authorityIds.Contains(raa.AuthorityId.Value));//删除角色权限
            }



            if (num > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框不关闭窗体, "删除成功！");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "删除失败！");
            }

            return Content(resultJson);
        }

        /// <summary>
        /// 获取菜单已有的权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public IActionResult GetAuthorityByMenuId(Guid menuId)
        {
            List<Sys_MenuAuthority> maList = menuAuthorityService.GetWhereData(ma => ma.MenuId == menuId, new OrderByHelper<Sys_MenuAuthority, int>() { OrderByType = OrderByType.ASC, Expression = ma => ma.OrderValue.Value }).ToList();
            string resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, maList);
            return Content(resultJson);
        }

        /// <summary>
        /// 保存菜单权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult SaveAuthority(Guid menuId, string data)
        {
            Hashtable rows = (Hashtable)XxsJsonHelp.Decode(data);

            IList<Sys_MenuAuthority> addList = new List<Sys_MenuAuthority>();
            IList<Sys_MenuAuthority> updateList = new List<Sys_MenuAuthority>();
            IList<Sys_MenuAuthority> deleteList = new List<Sys_MenuAuthority>();

            foreach (object key in rows.Keys)
            {
                Hashtable row = (Hashtable)rows[key];
                var type = row["type"].ToString().Trim();
                string AuthorityName = (row.ContainsKey("AuthorityName") && row["AuthorityName"] != null ? row["AuthorityName"].ToString() : "");
                int? orderBy = ((row.ContainsKey("OrderValue") && row["OrderValue"] != null) ? int.Parse(row["OrderValue"].ToString()) : 0);

                if (type.Equals("add"))
                {

                    Sys_MenuAuthority eMenu = new Sys_MenuAuthority();
                    eMenu.Id = Guid.NewGuid();
                    eMenu.MenuId = menuId;
                    eMenu.AuthorityName = AuthorityName;
                    if (orderBy != 0)
                    {
                        eMenu.OrderValue = orderBy;
                    }
                    addList.Add(eMenu);

                }
                else if (type.Equals("update"))
                {
                    Sys_MenuAuthority eMenu = new Sys_MenuAuthority();
                    eMenu = menuAuthorityService.GetByKey(Guid.Parse(row["Id"].ToString()));
                    eMenu.AuthorityName = AuthorityName;
                    if (orderBy != 0)
                    {
                        eMenu.OrderValue = orderBy;
                    }
                    updateList.Add(eMenu);
                }
                else if (type.Equals("remove"))
                {
                    Sys_MenuAuthority eMenu = new Sys_MenuAuthority();
                    eMenu.Id = Guid.Parse(row["Id"].ToString());
                    deleteList.Add(eMenu);
                }

            }
            if (addList.Count > 0)
            {
                menuAuthorityService.Add(addList);
            }
            if (updateList.Count > 0)
            {
                menuAuthorityService.Update(updateList);
            }
            if (deleteList.Count > 0)
            {
                menuAuthorityService.Delete(deleteList);

                List<Guid> authorityIds = new List<Guid>();
                foreach (Sys_MenuAuthority ma in deleteList)
                {
                    authorityIds.Add(ma.Id.Value);
                }
                Expression<Func<Sys_AuthorityRequest, bool>> exp = r => authorityIds.Contains<Guid>(r.AuthorityId.Value);
                requestService.Delete(r => (authorityIds.Contains(r.AuthorityId.Value)));//删除权限请求
                roleAndAuthorityService.Delete(raa => authorityIds.Contains(raa.AuthorityId.Value));//删除角色权限

            }
            string resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框不关闭窗体, "保存成功");
            return Content(resultJson);
        }


        /// <summary>
        /// 获取权限已有的请求
        /// </summary>
        /// <param name="authorityId"></param>
        /// <returns></returns>
        public IActionResult GetRequestByAuthorityId(Guid authorityId)
        {
            List<Sys_AuthorityRequest> requestList = requestService.GetWhereData(r => r.AuthorityId == authorityId).ToList();
            string resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, requestList);
            return Content(resultJson);
        }

        /// <summary>
        /// 保存权限请求
        /// </summary>
        /// <param name="authorityId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult SaveRequest(Guid authorityId, string data)
        {
            Hashtable rows = (Hashtable)XxsJsonHelp.Decode(data);

            IList<Sys_AuthorityRequest> addList = new List<Sys_AuthorityRequest>();
            IList<Sys_AuthorityRequest> updateList = new List<Sys_AuthorityRequest>();
            IList<Sys_AuthorityRequest> deleteList = new List<Sys_AuthorityRequest>();
            foreach (object key in rows.Keys)
            {
                Hashtable row = (Hashtable)rows[key];
                var type = row["type"].ToString().Trim();
                string Url = (row.ContainsKey("Url") && row["Url"] != null ? row["Url"].ToString() : "");
                string ButtonId = (row.ContainsKey("ButtonId") && row["ButtonId"] != null ? row["ButtonId"].ToString() : "");

                if (type.Equals("add"))
                {
                    Sys_AuthorityRequest eRequest = new Sys_AuthorityRequest();
                    eRequest.Id = Guid.NewGuid();
                    eRequest.AuthorityId = authorityId;
                    eRequest.Url = Url;
                    eRequest.ButtonId = ButtonId;
                    addList.Add(eRequest);
                }
                else if (type.Equals("update"))
                {
                    Sys_AuthorityRequest eRequest = new Sys_AuthorityRequest();
                    eRequest = requestService.GetByKey(Guid.Parse(row["Id"].ToString()));
                    eRequest.Url = Url;
                    eRequest.ButtonId = ButtonId;
                    updateList.Add(eRequest);
                }
                else if (type.Equals("remove"))
                {
                    Sys_AuthorityRequest eRequest = new Sys_AuthorityRequest();
                    eRequest.Id = Guid.Parse(row["Id"].ToString());
                    deleteList.Add(eRequest);
                }
            }
            requestService.Add(addList); requestService.Update(updateList); requestService.Delete(deleteList);
            string resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框不关闭窗体, "保存成功");
            return Content(resultJson);
        }


        /// <summary>
        /// 获取菜单以及菜单设置的权限
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenuBindAuthority()
        {
            string resultJson = "";
            var menuList = menuService.GetWhereData(x => true,
                new OrderByHelper<Sys_Menu, int>()
                { OrderByType = OrderByType.ASC, Expression = x => x.OrderValue.Value }).Select(m => new { id = m.Id, pid = m.ParentId, text = m.MenuName });

            IList<Sys_MenuAuthority> maList = menuAuthorityService.GetWhereData(x => true,
                new OrderByHelper<Sys_MenuAuthority, int>()
                { OrderByType = OrderByType.ASC, Expression = x => x.OrderValue.Value }).ToList();

            IList<Hashtable> list = new List<Hashtable>();
            foreach (var menu in menuList)
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", menu.id); ht.Add("pid", menu.pid); ht.Add("text", menu.text);
                IList<Sys_MenuAuthority> meMaList = maList.Where(ma => ma.MenuId.Value.Equals(menu.id)).ToList();
                ht.Add("auth", meMaList);
                list.Add(ht);
            }

            resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, list);
            return Content(resultJson);
        }

    }
}
