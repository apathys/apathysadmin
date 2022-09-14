using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace XxsModel.SysBasic
{
    
    public class Sys_User : XxsEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// 自增用户Id
        /// </summary>
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Num { get; set; } 


        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位id
        /// </summary>
        public Guid? UnitId { get; set; }

        /// <summary>
        /// 教师id
        /// </summary>
        public Guid? WorkerId { get; set; }

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

        /// <summary>
        ///最后修改时间
        /// </summary>
        public DateTime? LastEditTime { get; set; }

        /// <summary>
        /// 最后修改用户Id
        /// </summary>
        public Guid? LastEditUserID { get; set; }

        /// <summary>
        /// 最后修改用户姓名
        /// </summary>
        public string LastEditName { get; set; }

        public string WebToken { get; set; }
    }
}
