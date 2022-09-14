using System;
using System.Collections.Generic; 
using XxsModel.SysBasic; 

namespace Services.IService.SysBasic
{
    public interface ISys_AuthorityRequestService : IBaseService<Sys_AuthorityRequest>
    {

         /// <summary>
        /// 获取用户有权限的请求
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Sys_AuthorityRequest> GetRequestByUserId(Guid userId);
    }
}
