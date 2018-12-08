 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-12-08 15:27:12
/// 请勿随意改动该模板 FROM HAN
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_SysUser:DbBase<Data_SysUser>                
    {    
         
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="ID不能为空")]
        private Int32 ID { get;  }
        
        /// <summary>
        /// 用户标识
        /// </summary>
        [Required(ErrorMessage="用户标识不能为空")]
        [MaxLength(50, ErrorMessage = "用户标识长度不得超过50")]
        public String OID { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        [Key]
        [Required(ErrorMessage="用户名不能为空")]
        [MaxLength(500, ErrorMessage = "用户名长度不得超过500")]
        public String Name { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        [Key]
        [Required(ErrorMessage="姓名不能为空")]
        [MaxLength(255, ErrorMessage = "姓名长度不得超过255")]
        public String UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="Password不能为空")]
        [MaxLength(255, ErrorMessage = "Password长度不得超过255")]
        public String Password { get; set; }
        
        /// <summary>
        /// 联系电话
        /// </summary>
        [Key]
        [Required(ErrorMessage="联系电话不能为空")]
        [MaxLength(50, ErrorMessage = "联系电话长度不得超过50")]
        public String Telephone { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="IsDeleted不能为空")]
        public Boolean IsDeleted { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="IsLocked不能为空")]
        public Boolean IsLocked { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="CreateTime不能为空")]
        public DateTime CreateTime { get; set; }
                 
    }
}

