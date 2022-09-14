using EFData;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System.Linq;
using System.Collections.Generic;
using System;
using Common;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImplService.SysBasic
{ 
    public class ImplSys_UserService : ISys_UserService
    {
        private readonly ISys_UserRepository _sys_UserRepository; 
        public ImplSys_UserService(ISys_UserRepository sys_UserRepository) {
            _sys_UserRepository = sys_UserRepository;
        }

        public int Add(Sys_User entity)
        {
            return _sys_UserRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_User> entitys)
        {
            return _sys_UserRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _sys_UserRepository.Delete(id);
        }

        public int Delete(Sys_User entity)
        {
            return _sys_UserRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_User> entitys)
        {
            return _sys_UserRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_User, bool>> where)
        {
            return _sys_UserRepository.Delete(where);
        }

        public IEnumerable<Sys_User> GetAllData()
        {
            return _sys_UserRepository.GetAllData();
        }

        public Sys_User GetByKey(object key)
        {
            return _sys_UserRepository.GetByKey(key);
        }

        public IEnumerable<Sys_User> GetPageDate<T>(Expression<Func<Sys_User, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_User, T> orderBy)
        {
            return _sys_UserRepository.GetPageDate<T>(where,pageIndex,pageSize,out total,orderBy);
        }

        public IEnumerable<Sys_User> GetPageDate(Expression<Func<Sys_User, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_User>[] orderBy)
        {
            return _sys_UserRepository.GetPageDate(where,pageIndex,pageSize,out total,orderBy);
        }

        public IEnumerable<Sys_User> GetWhereData(Expression<Func<Sys_User, bool>> where)
        {
            return _sys_UserRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_User> GetWhereData<T>(Expression<Func<Sys_User, bool>> where, OrderByHelper<Sys_User, T> orderBy)
        {
            return _sys_UserRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_User> GetWhereData(Expression<Func<Sys_User, bool>> where, params OrderByHelper<Sys_User>[] orderBy)
        {
            return _sys_UserRepository.GetWhereData(where,orderBy);
        }

        public int Update(Sys_User entity)
        {
            return _sys_UserRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_User> entitys)
        {
            return _sys_UserRepository.Update(entitys);
        }
    }
}
