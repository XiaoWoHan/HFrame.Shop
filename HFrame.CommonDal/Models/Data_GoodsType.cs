 
 using System;
 using System.ComponentModel.DataAnnotations;
/// <summary>
/// 此模板为T4自动生成
/// 生成时间为2018-11-23 16:05:42
/// 请勿随意改动该模板
/// </summary>
namespace HFrame.CommonDal.Model
{     
    public class Data_GoodsType:DbBase<Data_GoodsType>                
    {    
         
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="不能为空")]
        private Int32 Id { get;  }
        
        /// <summary>
        /// 类型标识
        /// </summary>
        [Required(ErrorMessage="类型标识不能为空")]
        [MaxLength(50, ErrorMessage = "OID长度不得超过50")]
        public String OID { get; set; }
        
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required(ErrorMessage="类型名称不能为空")]
        [MaxLength(255, ErrorMessage = "TypeName长度不得超过255")]
        public String TypeName { get; set; }
        
        /// <summary>
        /// 父类标识
        /// </summary>
        [Required(ErrorMessage="父类标识不能为空")]
        [MaxLength(50, ErrorMessage = "ParentOID长度不得超过50")]
        public String ParentOID { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage="排序不能为空")]
        public Int32 Sort { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage="创建时间不能为空")]
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Required(ErrorMessage="创建人标识不能为空")]
        [MaxLength(50, ErrorMessage = "CreateUserOID长度不得超过50")]
        public String CreateUserOID { get; set; }
        
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage="创建人不能为空")]
        [MaxLength(255, ErrorMessage = "CreateUserName长度不得超过255")]
        public String CreateUserName { get; set; }
                 
    }
}

