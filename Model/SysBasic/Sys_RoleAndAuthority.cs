using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace XxsModel.SysBasic
{
    public class Sys_RoleAndAuthority: XxsEntity
    {
                
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Num { get; set; }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        public Guid? RoleId { get; set; }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        public Guid? AuthorityId { get; set; }
        
        
        
        /// <summary>
        ///添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        
        
        
        /// <summary>
        ///添加用户id
        /// </summary>
        public Guid? AddUserId { get; set; }
        
        
        
        /// <summary>
        ///添加用户姓名
        /// </summary>
        public string AddName { get; set; }
        
        

    }
}
