using XxsModel.SysBasic;
using Repository.IRepository.SysBasic;
using EFData;

namespace Repository.ImpRepository.SysBasic
{ 
    public class ImpSys_UserAndRoleRepository : ImpBaseRepository<Sys_UserAndRole>, ISys_UserAndRoleRepository
    {
        public ImpSys_UserAndRoleRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }
    }
}
