using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImpService.SysBasic
{
    public class ImplSys_AuthorityRequestService : ISys_AuthorityRequestService
    {
        private readonly ISys_AuthorityRequestRepository _Sys_AuthorityRequestRepository;
        public ImplSys_AuthorityRequestService(ISys_AuthorityRequestRepository Sys_AuthorityRequestRepository)
        {
            _Sys_AuthorityRequestRepository = Sys_AuthorityRequestRepository;
        }

        public int Add(Sys_AuthorityRequest entity)
        {
            return _Sys_AuthorityRequestRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_AuthorityRequest> entitys)
        {
            return _Sys_AuthorityRequestRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_AuthorityRequestRepository.Delete(id);
        }

        public int Delete(Sys_AuthorityRequest entity)
        {
            return _Sys_AuthorityRequestRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_AuthorityRequest> entitys)
        {
            return _Sys_AuthorityRequestRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_AuthorityRequest, bool>> where)
        {
            return _Sys_AuthorityRequestRepository.Delete(where);
        }

        public IEnumerable<Sys_AuthorityRequest> GetAllData()
        {
            return _Sys_AuthorityRequestRepository.GetAllData();
        }

        public Sys_AuthorityRequest GetByKey(object key)
        {
            return _Sys_AuthorityRequestRepository.GetByKey(key);
        }

        public IEnumerable<Sys_AuthorityRequest> GetPageDate<T>(Expression<Func<Sys_AuthorityRequest, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_AuthorityRequest, T> orderBy)
        {
            return _Sys_AuthorityRequestRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_AuthorityRequest> GetPageDate(Expression<Func<Sys_AuthorityRequest, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_AuthorityRequest>[] orderBy)
        {
            return _Sys_AuthorityRequestRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_AuthorityRequest> GetWhereData(Expression<Func<Sys_AuthorityRequest, bool>> where)
        {
            return _Sys_AuthorityRequestRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_AuthorityRequest> GetWhereData<T>(Expression<Func<Sys_AuthorityRequest, bool>> where, OrderByHelper<Sys_AuthorityRequest, T> orderBy)
        {
            return _Sys_AuthorityRequestRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_AuthorityRequest> GetWhereData(Expression<Func<Sys_AuthorityRequest, bool>> where, params OrderByHelper<Sys_AuthorityRequest>[] orderBy)
        {
            return _Sys_AuthorityRequestRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_AuthorityRequest entity)
        {
            return _Sys_AuthorityRequestRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_AuthorityRequest> entitys)
        {
            return _Sys_AuthorityRequestRepository.Update(entitys);
        }

        public IList<Sys_AuthorityRequest> GetRequestByUserId(Guid userId) {
            return _Sys_AuthorityRequestRepository.GetRequestByUserId(userId);
        }
    }
}
