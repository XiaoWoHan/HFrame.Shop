 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-12-08 15:27:12
/// 请勿随意改动该模板 FROM HAN
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_Config:DbBase<Data_Config>                
    {    
         
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="Id不能为空")]
        private Int32 Id { get;  }
        
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="OID不能为空")]
        [MaxLength(50, ErrorMessage = "OID长度不得超过50")]
        public String OID { get; set; }
        
        /// <summary>
        /// 命名空间
        /// </summary>
        [Key]
        [MaxLength(2147483647, ErrorMessage = "命名空间长度不得超过2147483647")]
        public String Namespace { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        [Key]
        [MaxLength(2147483647, ErrorMessage = "描述长度不得超过2147483647")]
        public String Description { get; set; }
        
        /// <summary>
        /// 配置内容
        /// </summary>
        [Key]
        [Required(ErrorMessage="配置内容不能为空")]
        [MaxLength(2147483647, ErrorMessage = "配置内容长度不得超过2147483647")]
        public String Config { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required(ErrorMessage="CreateTime不能为空")]
        public DateTime CreateTime { get; set; }
                 
    }
}

