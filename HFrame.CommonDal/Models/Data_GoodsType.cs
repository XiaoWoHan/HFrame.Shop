 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-12-19 16:31:28
/// 请勿随意改动该模板 FROM HAN
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_GoodsType:DbBase<Data_GoodsType>                
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
        /// 类型名称
        /// </summary>
        [Required(ErrorMessage="类型名称不能为空")]
        [MaxLength(255, ErrorMessage = "类型名称长度不得超过255")]
        public String TypeName { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage="排序不能为空")]
        public Int32 Sort { get; set; }
        
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

