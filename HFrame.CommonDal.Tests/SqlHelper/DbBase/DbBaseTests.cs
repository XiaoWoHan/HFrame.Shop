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
            DbBase<Data_SysUser> dbBase = new DbBase<Data_SysUser>();
            var aaa = dbBase.GetList(m => m.IsDeleted != true, m => m.IsDeleted);
            var bbb = dbBase.GetList(m => m.IsDeleted != true, m => m.OID);
            Assert.IsNull(aaa);
        }

        [TestMethod()]
        public void AddTest()
        {
        }
    }
}