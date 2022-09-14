using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImplService.SysBasic
{
    public class ImplSys_RoleService : ISys_RoleService
    {
        private readonly ISys_RoleRepository _Sys_RoleRepository;
        public ImplSys_RoleService(ISys_RoleRepository Sys_RoleRepository)
        {
            _Sys_RoleRepository = Sys_RoleRepository;
        }
        public int Add(Sys_Role entity)
        {
            return _Sys_RoleRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_Role> entitys)
        {
            return _Sys_RoleRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_RoleRepository.Delete(id);
        }

        public int Delete(Sys_Role entity)
        {
            return _Sys_RoleRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_Role> entitys)
        {
            return _Sys_RoleRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_Role, bool>> where)
        {
            return _Sys_RoleRepository.Delete(where);
        }

        public IEnumerable<Sys_Role> GetAllData()
        {
            return _Sys_RoleRepository.GetAllData();
        }

        public Sys_Role GetByKey(object key)
        {
            return _Sys_RoleRepository.GetByKey(key);
        }

        public IEnumerable<Sys_Role> GetPageDate<T>(Expression<Func<Sys_Role, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_Role, T> orderBy)
        {
            return _Sys_RoleRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_Role> GetPageDate(Expression<Func<Sys_Role, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_Role>[] orderBy)
        {
            return _Sys_RoleRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_Role> GetWhereData(Expression<Func<Sys_Role, bool>> where)
        {
            return _Sys_RoleRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_Role> GetWhereData<T>(Expression<Func<Sys_Role, bool>> where, OrderByHelper<Sys_Role, T> orderBy)
        {
            return _Sys_RoleRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_Role> GetWhereData(Expression<Func<Sys_Role, bool>> where, params OrderByHelper<Sys_Role>[] orderBy)
        {
            return _Sys_RoleRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_Role entity)
        {
            return _Sys_RoleRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_Role> entitys)
        {
            return _Sys_RoleRepository.Update(entitys);
        }

        public IList<Sys_Role> GetRoleByUserId(Guid userId) {
            return _Sys_RoleRepository.GetRoleByUserId(userId);
        }
    }
}
