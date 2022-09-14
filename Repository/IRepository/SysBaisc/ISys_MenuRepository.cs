
using XxsModel.SysBasic;
using System;
using System.Collections.Generic;

namespace Repository.IRepository.SysBasic
{
    public interface ISys_MenuRepository : IBaseRepository<Sys_Menu>
    {
        /// <summary>
        /// 根据用户id 获取有权限的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Sys_Menu> GetMyMenu(Guid userId);
    }
}
