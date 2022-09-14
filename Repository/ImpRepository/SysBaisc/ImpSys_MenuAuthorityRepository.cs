using XxsModel.SysBasic;
using Repository.IRepository.SysBasic;
using EFData;

namespace Repository.ImpRepository.SysBasic
{
   
    public class ImpSys_MenuAuthorityRepository : ImpBaseRepository<Sys_MenuAuthority>, ISys_MenuAuthorityRepository
    {
        public ImpSys_MenuAuthorityRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }
    }
}
