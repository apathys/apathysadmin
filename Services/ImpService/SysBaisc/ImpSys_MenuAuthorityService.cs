using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImplService.SysBasic
{

    public class ImplSys_MenuAuthorityService : ISys_MenuAuthorityService
    {
        private readonly ISys_MenuAuthorityRepository _Sys_MenuAuthorityRepository;
        public ImplSys_MenuAuthorityService(ISys_MenuAuthorityRepository Sys_MenuAuthorityRepository)
        {
            _Sys_MenuAuthorityRepository = Sys_MenuAuthorityRepository;
        }
        public int Add(Sys_MenuAuthority entity)
        {
            return _Sys_MenuAuthorityRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_MenuAuthority> entitys)
        {
            return _Sys_MenuAuthorityRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_MenuAuthorityRepository.Delete(id);
        }

        public int Delete(Sys_MenuAuthority entity)
        {
            return _Sys_MenuAuthorityRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_MenuAuthority> entitys)
        {
            return _Sys_MenuAuthorityRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_MenuAuthority, bool>> where)
        {
            return _Sys_MenuAuthorityRepository.Delete(where);
        }

        public IEnumerable<Sys_MenuAuthority> GetAllData()
        {
            return _Sys_MenuAuthorityRepository.GetAllData();
        }

        public Sys_MenuAuthority GetByKey(object key)
        {
            return _Sys_MenuAuthorityRepository.GetByKey(key);
        }

        public IEnumerable<Sys_MenuAuthority> GetPageDate<T>(Expression<Func<Sys_MenuAuthority, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_MenuAuthority, T> orderBy)
        {
            return _Sys_MenuAuthorityRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_MenuAuthority> GetPageDate(Expression<Func<Sys_MenuAuthority, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_MenuAuthority>[] orderBy)
        {
            return _Sys_MenuAuthorityRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_MenuAuthority> GetWhereData(Expression<Func<Sys_MenuAuthority, bool>> where)
        {
            return _Sys_MenuAuthorityRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_MenuAuthority> GetWhereData<T>(Expression<Func<Sys_MenuAuthority, bool>> where, OrderByHelper<Sys_MenuAuthority, T> orderBy)
        {
            return _Sys_MenuAuthorityRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_MenuAuthority> GetWhereData(Expression<Func<Sys_MenuAuthority, bool>> where, params OrderByHelper<Sys_MenuAuthority>[] orderBy)
        {
            return _Sys_MenuAuthorityRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_MenuAuthority entity)
        {
            return _Sys_MenuAuthorityRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_MenuAuthority> entitys)
        {
            return _Sys_MenuAuthorityRepository.Update(entitys);
        }
    }
}
