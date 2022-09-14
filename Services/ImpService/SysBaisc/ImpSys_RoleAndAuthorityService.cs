using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImpService.SysBasic
{

    public class ImplSys_RoleAndAuthorityService : ISys_RoleAndAuthorityService
    {
        private readonly ISys_RoleAndAuthorityRepository _Sys_RoleAndAuthorityRepository;
        public ImplSys_RoleAndAuthorityService(ISys_RoleAndAuthorityRepository Sys_RoleAndAuthorityRepository)
        {
            _Sys_RoleAndAuthorityRepository = Sys_RoleAndAuthorityRepository;
        }
        public int Add(Sys_RoleAndAuthority entity)
        {
            return _Sys_RoleAndAuthorityRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_RoleAndAuthority> entitys)
        {
            return _Sys_RoleAndAuthorityRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_RoleAndAuthorityRepository.Delete(id);
        }

        public int Delete(Sys_RoleAndAuthority entity)
        {
            return _Sys_RoleAndAuthorityRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_RoleAndAuthority> entitys)
        {
            return _Sys_RoleAndAuthorityRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_RoleAndAuthority, bool>> where)
        {
            return _Sys_RoleAndAuthorityRepository.Delete(where);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetAllData()
        {
            return _Sys_RoleAndAuthorityRepository.GetAllData();
        }

        public Sys_RoleAndAuthority GetByKey(object key)
        {
            return _Sys_RoleAndAuthorityRepository.GetByKey(key);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetPageDate<T>(Expression<Func<Sys_RoleAndAuthority, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_RoleAndAuthority, T> orderBy)
        {
            return _Sys_RoleAndAuthorityRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetPageDate(Expression<Func<Sys_RoleAndAuthority, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_RoleAndAuthority>[] orderBy)
        {
            return _Sys_RoleAndAuthorityRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetWhereData(Expression<Func<Sys_RoleAndAuthority, bool>> where)
        {
            return _Sys_RoleAndAuthorityRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetWhereData<T>(Expression<Func<Sys_RoleAndAuthority, bool>> where, OrderByHelper<Sys_RoleAndAuthority, T> orderBy)
        {
            return _Sys_RoleAndAuthorityRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_RoleAndAuthority> GetWhereData(Expression<Func<Sys_RoleAndAuthority, bool>> where, params OrderByHelper<Sys_RoleAndAuthority>[] orderBy)
        {
            return _Sys_RoleAndAuthorityRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_RoleAndAuthority entity)
        {
            return _Sys_RoleAndAuthorityRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_RoleAndAuthority> entitys)
        {
            return _Sys_RoleAndAuthorityRepository.Update(entitys);
        } 
        
    }
}
