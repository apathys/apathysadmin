using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImplService.SysBasic
{

    public class ImplSys_UserAndRoleService : ISys_UserAndRoleService
    {
        private readonly ISys_UserAndRoleRepository _Sys_UserAndRoleRepository;
        public ImplSys_UserAndRoleService(ISys_UserAndRoleRepository Sys_UserAndRoleRepository)
        {
            _Sys_UserAndRoleRepository = Sys_UserAndRoleRepository;
        }
        public int Add(Sys_UserAndRole entity)
        {
            return _Sys_UserAndRoleRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_UserAndRole> entitys)
        {
            return _Sys_UserAndRoleRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_UserAndRoleRepository.Delete(id);
        }

        public int Delete(Sys_UserAndRole entity)
        {
            return _Sys_UserAndRoleRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_UserAndRole> entitys)
        {
            return _Sys_UserAndRoleRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_UserAndRole, bool>> where)
        {
            return _Sys_UserAndRoleRepository.Delete(where);
        }

        public IEnumerable<Sys_UserAndRole> GetAllData()
        {
            return _Sys_UserAndRoleRepository.GetAllData();
        }

        public Sys_UserAndRole GetByKey(object key)
        {
            return _Sys_UserAndRoleRepository.GetByKey(key);
        }

        public IEnumerable<Sys_UserAndRole> GetPageDate<T>(Expression<Func<Sys_UserAndRole, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_UserAndRole, T> orderBy)
        {
            return _Sys_UserAndRoleRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_UserAndRole> GetPageDate(Expression<Func<Sys_UserAndRole, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_UserAndRole>[] orderBy)
        {
            return _Sys_UserAndRoleRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_UserAndRole> GetWhereData(Expression<Func<Sys_UserAndRole, bool>> where)
        {
            return _Sys_UserAndRoleRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_UserAndRole> GetWhereData<T>(Expression<Func<Sys_UserAndRole, bool>> where, OrderByHelper<Sys_UserAndRole, T> orderBy)
        {
            return _Sys_UserAndRoleRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_UserAndRole> GetWhereData(Expression<Func<Sys_UserAndRole, bool>> where, params OrderByHelper<Sys_UserAndRole>[] orderBy)
        {
            return _Sys_UserAndRoleRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_UserAndRole entity)
        {
            return _Sys_UserAndRoleRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_UserAndRole> entitys)
        {
            return _Sys_UserAndRoleRepository.Update(entitys);
        }
    }
}
