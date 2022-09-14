using System;
using System.Collections.Generic;
using XxsModel.SysBasic;

namespace Repository.IRepository.SysBasic
{
    public interface ISys_AuthorityRequestRepository : IBaseRepository<Sys_AuthorityRequest>
    {

        /// <summary>
        /// 获取用户有权限的请求
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Sys_AuthorityRequest> GetRequestByUserId(Guid userId);
    }
}
