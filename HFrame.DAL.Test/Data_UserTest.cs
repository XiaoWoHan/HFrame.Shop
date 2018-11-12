using HFrame.DAL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HFrame.DAL.Test
{
    [TestClass]
    public class Data_UserTest
    {
        [TestMethod]
        public void TestDelete()
        {
            Assert.IsTrue(Data_User.Current.Deleted());
        }
    }
}
