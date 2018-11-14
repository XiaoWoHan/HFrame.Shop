using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Cache.Tests
{
    [TestClass()]
    public class CacheModelTests
    {
        [TestMethod()]
        public void CacheModelTest()
        {
            CacheHelper.Current.Add("123",new { Name="CacheTest"});
            var aaa=CacheHelper.Current.Get("123");
            Assert.IsNotNull(aaa);

            var CacheModelTest = CacheHelper.Current.Get<object>("123");
            Assert.IsNotNull(CacheModelTest);

            CacheHelper.Current.Remove("123");
            Assert.IsNull(CacheHelper.Current.Get("123"));

            RedisHelper.Current.Add("123", new { Name = "CacheTest" });
            var RedisGet = RedisHelper.Current.Get("123");
            Assert.IsNotNull(RedisGet);

            var RedisGetModel = RedisHelper.Current.Get<object>("123");
            Assert.IsNotNull(RedisGetModel);

            RedisHelper.Current.Remove("123");
            Assert.IsNull(RedisHelper.Current.Get("123"));
        }

        [TestMethod()]
        public void CacheModelTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExistsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrUpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }
    }
}