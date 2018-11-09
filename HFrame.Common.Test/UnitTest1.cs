using System;
using HFrame.Common.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HFrame.Common.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var aaa = LogHelper.GetErrors();
            Assert.IsNotNull(aaa);
        }
    }
}
