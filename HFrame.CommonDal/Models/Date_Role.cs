 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-12-19 16:31:28
/// 请勿随意改动该模板 FROM HAN
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Date_Role:DbBase<Date_Role>                
    {    
         
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="Id不能为空")]
        private Int32 Id { get;  }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="OID不能为空")]
        [MaxLength(50, ErrorMessage = "OID长度不得超过50")]
        public String OID { get; set; }
        
        /// <summary>
        /// 父代标识
        /// </summary>
        [MaxLength(50, ErrorMessage = "父代标识长度不得超过50")]
        public String ParentOID { get; set; }
        
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage="角色名称不能为空")]
        [MaxLength(255, ErrorMessage = "角色名称长度不得超过255")]
        public String RoleName { get; set; }
        
        /// <summary>
        /// 角色描述
        /// </summary>
        [MaxLength(2147483647, ErrorMessage = "角色描述长度不得超过2147483647")]
        public String Dscription { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage="创建时间不能为空")]
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50, ErrorMessage = "CreateUserOID长度不得超过50")]
        public String CreateUserOID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255, ErrorMessage = "CreateUserName长度不得超过255")]
        public String CreateUserName { get; set; }
                 
    }
}

