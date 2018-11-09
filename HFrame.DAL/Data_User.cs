using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    public class Data_User: DbBase<Data_User>
    {
        private int ID { get; set; }
        [MaxLength(50,ErrorMessage ="字符串长度为0-50")]
        public string OID { get; set; }
        [MaxLength(500, ErrorMessage = "字符串长度为0-500")]
        public string Name { get; set; }
        [MaxLength(255, ErrorMessage = "字符串长度为0-255")]
        public string UserName { get; set; }
        [MaxLength(255, ErrorMessage = "字符串长度为0-255")]
        public string Password { get; set; }
        [Phone(ErrorMessage ="手机号格式不正确")]
        [MaxLength(50, ErrorMessage = "字符串长度为0-50")]
        public string Telephone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
