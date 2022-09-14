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
    public class UserController : BaseController
    { 
        public ISys_UserAndRoleService userAndRoleService { get; set; } 
        public ISys_RoleService roleService { get; set; }


        public UserController(ISys_UserService _userService,
                              IMemoryCache _memoryCache,
                              ISys_AuthorityRequestService _requestService,
                              ISys_RoleService _roleService,
                              ISys_UserAndRoleService _userAndRoleService)
                                : base(_userService, _memoryCache, _requestService)
        {
            roleService = _roleService;
            userAndRoleService = _userAndRoleService;
        }

        public IActionResult List()
        {
            return View("UserList");
        }

        public IActionResult Add()
        {
            return View("UserAdd");
        }

        public IActionResult Edit(Guid userId)
        {
            Sys_User sys_User = userService.GetByKey(userId);

            if (sys_User == null)
            {
                
            }
            return View("UserEdit", sys_User);

        }

        public IActionResult GetPageData(int pageSize, int pageIndex)
        {

            //条件
            Expression<Func<Sys_User, bool>> expre = u => true;

            if (Request.Form["userName"] != "" && !string.IsNullOrEmpty(Request.Form["userName"]))
            {
                string userName = Request.Form["userName"];
                expre = expre.And(u => u.UserName.Contains(userName));
            }
            if (Request.Form["name"] != "" && !string.IsNullOrEmpty(Request.Form["name"]))
            {
                string name = Request.Form["name"];
                expre = expre.And(u => u.Name.Contains(name));
            }


            //排序
            OrderByHelper<Sys_User, DateTime> orderBy = new OrderByHelper<Sys_User, DateTime>() { OrderByType = OrderByType.DESC, Expression = u => u.AddTime.Value };

            int total = 0;

            List<Sys_User> list = userService.GetPageDate(expre, pageIndex, pageSize, out total, orderBy).ToList();

            Hashtable ht = new Hashtable();

            ht.Add("total", total);
            ht.Add("data", list);
            string json = XxsAjaxHelper.AjaxResult(XxsAjaxType.执行数据源, ht);

            return Content(json);

        }

        public ActionResult AddUser(string data)
        {
            string resultJson = "";
            Hashtable row = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_User eUser = new Sys_User();
            eUser.Id = Guid.NewGuid();
            eUser.UserName = row["UserName"].ToString().Trim();
            eUser.Password = MD5Helper.GetMD5("123456");
            eUser.Name = row["Name"].ToString().Trim();
            List<Sys_User> listUser = userService.GetWhereData(u => u.UserName.Equals(eUser.UserName)).ToList();
            if (listUser.Count > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该用户已经存在！");
                return Content(resultJson);
            }
            int num = userService.Add(eUser);
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

        public ActionResult EditUser(string data)
        {

            string resultJson = "";
            Hashtable row = (Hashtable)XxsJsonHelp.Decode(data);
            Sys_User eUser = userService.GetByKey(Guid.Parse(row["Id"].ToString()));
            if (eUser == null)
            {
                resultJson = resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该条记录不存在！");
                return Content(resultJson);
            }
            String userName = row["UserName"].ToString().Trim();
            eUser.Name = row["Name"].ToString().Trim();
            if (!eUser.UserName.Equals(userName))
            {
                List<Sys_User> listUser = userService.GetWhereData(u => u.UserName.Equals(userName)).ToList();
                if (listUser.Count > 0)
                {
                    resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该用户已经存在！");
                    return Content(resultJson);
                }
            }
            eUser.UserName = userName;
            int num = userService.Update(eUser);
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

        public ActionResult DeleteUser(Guid userId)
        {
            int num = userService.Delete(userId);
            string resultJson = "";
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
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult ResetPwd(Guid userId)
        {
            string resultJson = "";
            Sys_User eUser = userService.GetByKey(userId);
            if (eUser == null)
            {
                resultJson = resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出警告提示框不关闭窗体, "该条记录不存在！");
                return Content(resultJson);
            }
            eUser.Password = MD5Helper.GetMD5("123456");
            int num = userService.Update(eUser);
            if (num > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "重置成功！");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "重置失败！");
            }
            return Content(resultJson);
        }

        /// <summary>
        /// 获取用户已经绑定的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult BindRole(Guid userId)
        {

            List<Sys_Role> roleList = roleService.GetAllData().ToList();
            ViewData["roleList"] = roleList;
            List<Sys_UserAndRole> uarList = userAndRoleService.GetWhereData(uar => uar.UserId == userId).ToList();
            ViewData["meRoleList"] = uarList;
            ViewData["userId"] = userId;
            return View();
        }

        /// <summary>
        /// 用户绑定角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public ActionResult BindRoleHandler(Guid userId, string roleIds)
        {
            userAndRoleService.Delete(uar => uar.UserId == userId);
            List<Sys_UserAndRole> uarList = new List<Sys_UserAndRole>();
            string[] roleIdArray = roleIds.Split(',');
            foreach (string roleId in roleIdArray)
            {
                if (!string.IsNullOrEmpty(roleId.Trim()))
                {
                    Sys_UserAndRole uar = new Sys_UserAndRole();
                    uar.Id = Guid.NewGuid();
                    uar.UserId = userId;
                    uar.RoleId = Guid.Parse(roleId);
                    uarList.Add(uar);
                }
            }

            int num = userAndRoleService.Add(uarList);
            string resultJson = "";
            if (num > 0)
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出OK提示框关闭窗体, "绑定成功！");
            }
            else
            {
                resultJson = XxsAjaxHelper.AjaxResult(XxsAjaxType.弹出错误提示框不关闭窗体, "绑定失败！");
            }
            return Content(resultJson);
        }
    }
}
