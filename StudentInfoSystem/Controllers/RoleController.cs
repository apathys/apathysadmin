using Common;
using Common.xxs;
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
    public class RoleController : BaseController
    {
        public ISys_RoleService roleService;
        public ISys_RoleAndAuthorityService roleAndAuthorityService; 
        public RoleController(ISys_UserService _userService,
                              IMemoryCache _memoryCache,
                              ISys_AuthorityRequestService _requestService,
                              ISys_RoleService _roleService,
                              ISys_RoleAndAuthorityService _roleAndAuthorityService) 
                                : base(_userService, _memoryCache, _requestService) {

            userService = _userService;
            memoryCache = _memoryCache;
            requestService = _requestService;

            roleService = _roleService;
            roleAndAuthorityService = _roleAndAuthorityService;
        }
        public IActionResult List()
        {
            return View("RoleList");
        }

        public IActionResult Add()
        {
            return View("RoleAdd");
        }

        public IActionResult Edit(Guid roleId)
        {
            Sys_Role role = roleService.GetByKey(roleId);
            if (role == null)
            {
                 
            }

            return View("RoleEdit", role);
        }

        public IActionResult BindAuthority(Guid roleId)
        {
            ViewData["id"] = roleId;
            return View();
        }

        public IActionResult GetPageData(int pageSize, int pageIndex)
        {

            //条件
            Expression<Func<Sys_Role, bool>> expre = u => true;

            var _roleName = HttpContext.Request.Form["roleName"];


            if (_roleName != "" && !string.IsNullOrEmpty(Request.Form["roleName"]))
            {
                string roleName = _roleName;
                expre = expre.And(u => u.RoleName.Contains(roleName));
            }

            int total = 0;

            //排序
            OrderByHelper<Sys_Role, DateTime> orderBy = new OrderByHelper<Sys_Role, DateTime>() { OrderByType = OrderByType.DESC, Expression = u => u.AddTime.Value };

            List<Sys_Role> list = roleService.GetPageDate(expre, pageIndex, pageSize, out total, orderBy).ToList();

            Hashtable ht = new Hashtable();

            ht.Add("total", total);
            ht.Add("data", list);
            string json = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, ht);

            return Content(json);
        }

        public IActionResult AddRole(string data)
        {
            string resultJson = "";
            Hashtable row = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_Role eRole = new Sys_Role();
            eRole.Id = Guid.NewGuid();
            eRole.RoleName = row["RoleName"].ToString().Trim();
            eRole.Remark = row["Remark"].ToString().Trim();
            int num = roleService.Add(eRole);
            if (num > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "新增成功！");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "新增失败！");
            }
            return Content(resultJson);
        }

        public IActionResult EditRole(string data)
        {
            string resultJson = "";
            Hashtable row = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_Role eRole = roleService.GetByKey(Guid.Parse(row["Id"].ToString()));
            if (eRole == null)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该条记录不存在！");
                return Content(resultJson);
            }
            eRole.RoleName = row["RoleName"].ToString().Trim();
            eRole.Remark = row["Remark"].ToString().Trim();

            int num = roleService.Update(eRole);
            if (num > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "修改成功！");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "修改失败！");
            }
            return Content(resultJson);

        }

        public IActionResult DeleteRole(Guid roleId)
        {
            string resultJson = "";
            int num = roleService.Delete(roleId);

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
        /// 根据角色已有的权限；
        /// </summary>
        public IActionResult GetRoleAuthority(Guid roleId)
        {
            string resultJson = "";
            IList<Sys_RoleAndAuthority> raaList = roleAndAuthorityService.GetWhereData(raa => raa.RoleId == roleId).ToList();
            resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, raaList);
            return Content(resultJson);
        }

        /// <summary>
        /// 角色绑定权限
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult RoleBindAuthority(Guid roleId, string data)
        {
            Hashtable rows = (Hashtable)XxsJsonHelp.Decode(data);


            IList<Sys_RoleAndAuthority> addRaa = new List<Sys_RoleAndAuthority>();
            IList<Sys_RoleAndAuthority> removeRaa = new List<Sys_RoleAndAuthority>();
            foreach (object key in rows.Keys)
            {
                Hashtable row = (Hashtable)rows[key];
                var type = row["type"].ToString().Trim();
                Guid? AuthorityId = ((row.ContainsKey("AuthorityId") && row["AuthorityId"] != null)
                    ? Guid.Parse(row["AuthorityId"].ToString()) : Guid.Empty);
                Sys_RoleAndAuthority entity = new Sys_RoleAndAuthority();
                if (type.Equals("add"))
                {
                    entity.Id = Guid.NewGuid();
                    entity.RoleId = roleId;
                    entity.AuthorityId = AuthorityId;
                    addRaa.Add(entity);
                }
                else if (type.Equals("remove"))
                {
                    entity.Id = Guid.Parse(row["Id"].ToString());
                    removeRaa.Add(entity);
                }
                else
                {
                }
            }
            roleAndAuthorityService.Add(addRaa);
            roleAndAuthorityService.Delete(removeRaa);
            string resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "保存成功");
            return Content(resultJson);

        }

    }
}
