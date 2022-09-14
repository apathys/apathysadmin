 
using Microsoft.EntityFrameworkCore;
using XxsModel.SysBasic; 

namespace EFData
{
    public class EFDataContext:DbContext
    {
        public EFDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Sys_User> Sys_User { get; set; }
        public DbSet<Sys_Role> Sys_Role { get; set; }
        public DbSet<Sys_UserAndRole> Sys_UserAndRole { get; set; }
        public DbSet<Sys_Menu> Sys_Menu { get; set; }
        public DbSet<Sys_MenuAuthority> Sys_MenuAuthority { get; set; }
        public DbSet<Sys_AuthorityRequest> Sys_AuthorityRequest { get; set; }
        public DbSet<Sys_RoleAndAuthority> Sys_RoleAndAuthority { get; set; }
    }
}
