using XxsModel.SysBasic; 
using Repository.IRepository.SysBasic;
using EFData;

namespace Repository.ImpRepository.SysBasic
{
   
    public class ImpSys_RoleAndAuthorityRepository : ImpBaseRepository<Sys_RoleAndAuthority>, ISys_RoleAndAuthorityRepository
    {
        public ImpSys_RoleAndAuthorityRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }
    }
}
