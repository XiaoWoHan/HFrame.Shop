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
    public class StringHelperTests
    {
        [TestMethod()]
        public void StringByteLengthTest()
        {
            var aaa = "12314asfd65adsf";
            var bbb=aaa.StringByteLength();
            Assert.IsNotNull(bbb);
        }

        [TestMethod()]
        public void StringByteLengthTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SplitStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsContainsInTest()
        {
            Assert.Fail();
        }
    }
}