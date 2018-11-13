using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.CommonDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFrame.CommonDal.Model;
using HFrame.Common.Helper;

namespace HFrame.CommonDal.Tests
{
    [TestClass()]
    public class DbBaseTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            DbBase<Data_User> dbBase = new DbBase<Data_User>();
            var aaa = dbBase.GetList(m => m.IsDeleted != true, m => m.IsDeleted);
            var bbb = dbBase.GetList(m => m.IsDeleted != true, m => m.OID);
        }

        [TestMethod()]
        public void AddTest()
        {
            for (var i = 1; i <= 100; i++)
            {
                new Data_User() { Name = "132", CreateTime = DateTime.Now, IsDeleted = false, OID = StringHelper.GuidStr, IsLocked = false, Password = "a21d", Telephone = "35asd746a3", UserName = "?" }.Add();
            }
        }
    }
}