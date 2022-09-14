

using XxsModel.SysBasic;
using Repository.IRepository.SysBasic;
using EFData;

namespace Repository.ImpRepository.SysBasic
{
 
    public class ImpSys_UserRepository : ImpBaseRepository<Sys_User>, ISys_UserRepository
    {
        public ImpSys_UserRepository(EFDataContext _EFDbContext) : base(_EFDbContext) { }

    }
}
