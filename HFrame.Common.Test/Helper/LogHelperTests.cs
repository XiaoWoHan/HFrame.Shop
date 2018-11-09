using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Helper.Tests
{
    [TestClass()]
    public class LogHelperTests
    {
        [TestMethod()]
        public void GetTodyErrorsTest()
        {
            Assert.IsNotNull(LogHelper.GetErrors());
        }

        [TestMethod()]
        public void LogTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogErrorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTodyErrorsTest1()
        {
            var aaa=LogHelper.GetTodyErrors();
            Assert.IsNotNull(aaa);
        }

        [TestMethod()]
        public void GetErrorsTest()
        {
            Assert.Fail();
        }
    }
}