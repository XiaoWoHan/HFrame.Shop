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
    public class UnitTest1
    {
        [TestMethod()]
        public void StringByteLengthTest()
        {
            Assert.IsNotNull(StringHelper.GuidStr);
        }

        [TestMethod()]
        public void SplitStringTest()
        {
            var TimeStr = StringHelper.TimeStr;
            Assert.IsNotNull(TimeStr);
        }

        [TestMethod()]
        public void SplitStringTest1()
        {
            var spStr = "ss,saa,www";
            var alen=StringHelper.SplitString(spStr, ",");
            Assert.AreEqual(alen.Length, 3);
            Assert.AreEqual(spStr.SplitString(",").Length, 3);
        }

        [TestMethod()]
        public void IsContainsInTest()
        {
            Assert.IsFalse("1".IsContainsIn("2", "3", "4"));
        }
    }
}