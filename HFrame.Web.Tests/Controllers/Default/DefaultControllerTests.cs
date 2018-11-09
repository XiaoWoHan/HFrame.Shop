using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFrame.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Web.Controllers.Tests
{
    [TestClass()]
    public class DefaultControllerTests
    {
        [TestMethod()]
        public void ValidateCodeImgTest()
        {
            
            Assert.IsNotNull(new DefaultController().ValidateCodeImg());
        }
    }
}