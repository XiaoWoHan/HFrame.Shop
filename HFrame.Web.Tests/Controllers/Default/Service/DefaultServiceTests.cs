using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.Web.Default.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFrame.Common.Model;
using HFrame.Common.Helper;

namespace HFrame.Web.Default.Service.Tests
{
    [TestClass()]
    public class DefaultServiceTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            var Code = ValidateCodeHelper.GetRandomCode(7);
            ValidateCodeHelper.SetCodeString(Code);
            Assert.IsTrue(DefaultService.Register(new ResultModel(),new Model.RegisterModel { Password="123",RePassword="123",Telephone="123456",UserName="HanTest",VerisonCode= Code }));
        }
    }
}