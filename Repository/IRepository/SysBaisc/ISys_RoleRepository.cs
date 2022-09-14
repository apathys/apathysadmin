
using XxsModel.SysBasic;
using System;
using System.Collections.Generic;

namespace Repository.IRepository.SysBasic
{
   public interface ISys_RoleRepository : IBaseRepository<Sys_Role>
    {
       /// <summary>
       /// 根据用户id，获取用户绑定的角色
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       IList<Sys_Role> GetRoleByUserId(Guid userId);
    }
}
