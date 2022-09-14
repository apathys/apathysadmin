using EFData;
using XxsModel.SysBasic;
using Repository.IRepository.SysBasic;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository.ImpRepository.SysBasic
{
    
    public class ImpSys_RoleRepository : ImpBaseRepository<Sys_Role>, ISys_RoleRepository
    {
        public ImpSys_RoleRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }
        /// <summary>
        /// 根据用户id，获取用户绑定的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Sys_Role> GetRoleByUserId(Guid userId) 
        {
            EFDataContext context = (EFDataContext)base.Context;

            IList<Sys_Role> roleList = (from Sys_Role role in context.Sys_Role
                                        where
                                       ((from Sys_UserAndRole uar in context.Sys_UserAndRole
                                         where uar.UserId == userId select uar.RoleId).ToList().Contains(role.Id))
                    select role).ToList();
            return roleList;
        }
    }
}
