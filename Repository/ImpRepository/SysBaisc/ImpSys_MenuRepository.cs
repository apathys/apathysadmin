using EFData;
using XxsModel.SysBasic;
using Repository.IRepository.SysBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.ImpRepository.SysBasic
{
     
    public class ImpSys_MenuRepository : ImpBaseRepository<Sys_Menu>, ISys_MenuRepository
    {
        public ImpSys_MenuRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }
        /// <summary>
        /// 根据用户id 获取有权限的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Sys_Menu> GetMyMenu(Guid userId) 
       {

           EFDataContext context = (EFDataContext)base.Context;
           //根据用户获取角色id
           var userAndRole = from Sys_UserAndRole uar in context.Sys_UserAndRole where uar.UserId == userId select uar.RoleId;
          //根据角色获取权限id
           var roleAndAuthority = from Sys_RoleAndAuthority raa in context.Sys_RoleAndAuthority where userAndRole.Contains(raa.RoleId) select raa.AuthorityId;
           //根据权限获取菜单id
           var menuAuthority = from Sys_MenuAuthority ma in context.Sys_MenuAuthority where roleAndAuthority.Contains(ma.Id) select ma.MenuId;
           //获取菜单
           IList<Sys_Menu> menuList = (from Sys_Menu menu in context.Sys_Menu orderby menu.OrderValue where menuAuthority.Contains(menu.Id) select menu).ToList();
           
           allMenu = GetAllData().ToList();
           
           IList<Sys_Menu> resultList = new List<Sys_Menu>();

           if (menuList != null && menuList.Count > 0) 
           {
               resultList = menuList;
              foreach (Sys_Menu menu in menuList) 
              {
                  currentLevel = 1;
                  if (menu.ParentId != null)
                  {
                    resultList = resultList.Concat(GetParentMenu(menu.ParentId.Value)).ToList();
                  }
              }
           }
           resultList = resultList.Distinct().ToList();
           return resultList;
       }
       private int maxLevel = 5;
       private int currentLevel = 1;
       private IList<Sys_Menu> allMenu;

       private IList<Sys_Menu> GetParentMenu(Guid parentId) 
       {
           IList<Sys_Menu> resultList = new List<Sys_Menu>();
           Sys_Menu parentMenu = (from Sys_Menu menu in allMenu where menu.Id == parentId select menu).First();
           if (parentMenu != null && currentLevel <= maxLevel)
           {
               currentLevel++;
               resultList.Add(parentMenu);
               if(parentMenu.ParentId  != null)
               {
                  resultList = resultList.Concat(GetParentMenu(parentMenu.ParentId.Value)).ToList();
               }
           }
           return resultList;
       }

    }
}
