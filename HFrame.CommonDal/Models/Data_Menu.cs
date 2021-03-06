 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-12-19 16:31:28
/// 请勿随意改动该模板 FROM HAN
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_Menu:DbBase<Data_Menu>                
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
        /// 父标识
        /// </summary>
        [MaxLength(50, ErrorMessage = "父标识长度不得超过50")]
        public String ParentOID { get; set; }
        
        /// <summary>
        /// 等级
        /// </summary>
        [Required(ErrorMessage="等级不能为空")]
        public Int32 Layer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(200, ErrorMessage = "Icon长度不得超过200")]
        public String Icon { get; set; }
        
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage="标题不能为空")]
        [MaxLength(255, ErrorMessage = "标题长度不得超过255")]
        public String Title { get; set; }
        
        /// <summary>
        /// 链接
        /// </summary>
        [Required(ErrorMessage="链接不能为空")]
        [MaxLength(2147483647, ErrorMessage = "链接长度不得超过2147483647")]
        public String LinkHref { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="CreateTime不能为空")]
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
                
