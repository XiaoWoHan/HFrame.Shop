using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.CommonDal.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFrame.CommonDal.Model;

namespace HFrame.CommonDal.Sql.Tests
{
    [TestClass()]
    public class SelectSqlHelperTests:InsertSqlHelper<Data_User>
    {
        [TestMethod()]
        public void SelectSqlHelperTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSelectColumnTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSelectColumnTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddSelectColumnTest2()
        {
            Assert.IsNotNull(this.Sql);
        }

        [TestMethod()]
        public void AddSelectColumnTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetFunctionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetWhereTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetWhereTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AndWhereTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AndWhereTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OrWhereTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OrWhereTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetLimitTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTopTest1()
        {
            Assert.Fail();
        }
    }
}