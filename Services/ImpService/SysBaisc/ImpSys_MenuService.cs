using Common;
using XxsModel.SysBasic;
using Services.IService.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Repository.IRepository.SysBasic;

namespace Services.ImplService.SysBasic
{

    public class ImplSys_MenuService : ISys_MenuService
    {
        private readonly ISys_MenuRepository _Sys_MenuRepository;
        public ImplSys_MenuService(ISys_MenuRepository Sys_MenuRepository)
        {
            _Sys_MenuRepository = Sys_MenuRepository;
        }
        public int Add(Sys_Menu entity)
        {
            return _Sys_MenuRepository.Add(entity);
        }

        public int Add(IEnumerable<Sys_Menu> entitys)
        {
            return _Sys_MenuRepository.Add(entitys);
        }

        public int Delete(object id)
        {
            return _Sys_MenuRepository.Delete(id);
        }

        public int Delete(Sys_Menu entity)
        {
            return _Sys_MenuRepository.Delete(entity);
        }

        public int Delete(IEnumerable<Sys_Menu> entitys)
        {
            return _Sys_MenuRepository.Delete(entitys);
        }

        public int Delete(Expression<Func<Sys_Menu, bool>> where)
        {
            return _Sys_MenuRepository.Delete(where);
        }

        public IEnumerable<Sys_Menu> GetAllData()
        {
            return _Sys_MenuRepository.GetAllData();
        }

        public Sys_Menu GetByKey(object key)
        {
            return _Sys_MenuRepository.GetByKey(key);
        }

        public IEnumerable<Sys_Menu> GetPageDate<T>(Expression<Func<Sys_Menu, bool>> where, int pageIndex, int pageSize, out int total, OrderByHelper<Sys_Menu, T> orderBy)
        {
            return _Sys_MenuRepository.GetPageDate<T>(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_Menu> GetPageDate(Expression<Func<Sys_Menu, bool>> where, int pageIndex, int pageSize, out int total, params OrderByHelper<Sys_Menu>[] orderBy)
        {
            return _Sys_MenuRepository.GetPageDate(where, pageIndex, pageSize, out total, orderBy);
        }

        public IEnumerable<Sys_Menu> GetWhereData(Expression<Func<Sys_Menu, bool>> where)
        {
            return _Sys_MenuRepository.GetWhereData(where);
        }

        public IEnumerable<Sys_Menu> GetWhereData<T>(Expression<Func<Sys_Menu, bool>> where, OrderByHelper<Sys_Menu, T> orderBy)
        {
            return _Sys_MenuRepository.GetWhereData<T>(where, orderBy);
        }

        public IEnumerable<Sys_Menu> GetWhereData(Expression<Func<Sys_Menu, bool>> where, params OrderByHelper<Sys_Menu>[] orderBy)
        {
            return _Sys_MenuRepository.GetWhereData(where, orderBy);
        }

        public int Update(Sys_Menu entity)
        {
            return _Sys_MenuRepository.Update(entity);
        }

        public int Update(IEnumerable<Sys_Menu> entitys)
        {
            return _Sys_MenuRepository.Update(entitys);
        }

        public IList<Sys_Menu> GetMyMenu(Guid userId) {
            return _Sys_MenuRepository.GetMyMenu(userId);
        }
    }
}
