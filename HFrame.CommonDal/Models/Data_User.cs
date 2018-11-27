 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-11-23 16:05:42
/// 请勿随意改动该模板
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_User:DbBase<Data_User>                
    {    
         
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="不能为空")]
        private Int32 ID { get;  }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        [MaxLength(50, ErrorMessage = "OID长度不得超过50")]
        public String OID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        [MaxLength(500, ErrorMessage = "Name长度不得超过500")]
        public String Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        [MaxLength(255, ErrorMessage = "UserName长度不得超过255")]
        public String UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        [MaxLength(255, ErrorMessage = "Password长度不得超过255")]
        public String Password { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        [MaxLength(50, ErrorMessage = "Telephone长度不得超过50")]
        public String Telephone { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        public Boolean IsDeleted { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        public Boolean IsLocked { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        public DateTime CreateTime { get; set; }
                 
    }
}
                
