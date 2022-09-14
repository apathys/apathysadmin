using EFData; 
using Repository.IRepository.SysBasic;
using System;
using System.Collections.Generic; 
using System.Linq;
using XxsModel.SysBasic;

namespace Repository.ImpRepository.SysBasic
{

    public class ImpSys_AuthorityRequestRepository : ImpBaseRepository<Sys_AuthorityRequest>, ISys_AuthorityRequestRepository
    {

        public ImpSys_AuthorityRequestRepository(EFDataContext _EFDbContext) :base(_EFDbContext){ }

        /// <summary>
        /// 获取用户有权限的请求
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Sys_AuthorityRequest> GetRequestByUserId(Guid userId) 
        {
            EFDataContext context = (EFDataContext)base.Context;
            //根据用户获取角色id
            var userAndRole = from Sys_UserAndRole uar in context.Sys_UserAndRole where uar.UserId == userId select uar.RoleId;
            //根据角色获取权限id
            var roleAndAuthority = from Sys_RoleAndAuthority raa in context.Sys_RoleAndAuthority where userAndRole.Contains(raa.RoleId) select raa.AuthorityId;
            //根据权限获取请求
            var authRequest = from Sys_AuthorityRequest ar in context.Sys_AuthorityRequest where roleAndAuthority.Contains(ar.AuthorityId) select ar;
            
            return authRequest.ToList();
        }
    }
}
