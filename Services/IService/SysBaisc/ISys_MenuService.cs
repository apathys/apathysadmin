using System;
using System.Collections.Generic;

using XxsModel.SysBasic; 
namespace Services.IService.SysBasic
{
    public interface ISys_MenuService : IBaseService<Sys_Menu>
    {
        /// <summary>
        /// 根据用户id 获取有权限的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Sys_Menu> GetMyMenu(Guid userId);
    }
}
