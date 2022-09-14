using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace XxsModel.SysBasic
{
    public class Sys_UserAndRole : XxsEntity
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid? RoleId{ get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 添加用户Id
        /// </summary>
        public Guid? AddUserId { get; set; }

        /// <summary>
        ///  添加用户姓名
        /// </summary>
        public string AddName { get; set; }



    }
}
