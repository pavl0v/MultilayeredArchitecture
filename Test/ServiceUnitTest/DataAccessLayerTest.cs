using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class DataAccessLayerTest
    {
        [TestMethod]
        public void AddTest()
        {
            var mock = new Mock<ServiceInterfaces.IItemDAO>();
            mock.Setup(x => x.ID).Returns(0);
            mock.Setup(x => x.Name).Returns("NAME");
            mock.Setup(x => x.ParameterA).Returns(12);
            mock.Setup(x => x.ParameterB).Returns(34);

            DataAccessLayer.DALItemManagerSQLCompact m = new DataAccessLayer.DALItemManagerSQLCompact();
            long id = m.Add(mock.Object);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void DeleteTest()
        {
            DataAccessLayer.DALItemManagerSQLCompact m = new DataAccessLayer.DALItemManagerSQLCompact();
            bool res = m.Delete(1);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void GetTest()
        {
            DataAccessLayer.DALItemManagerSQLCompact m = new DataAccessLayer.DALItemManagerSQLCompact();
            ServiceInterfaces.IItemDAO res = m.Get(1);
            Assert.AreNotEqual(null, res);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var mock = new Mock<ServiceInterfaces.IItemDAO>();
            mock.Setup(x => x.ID).Returns(2);
            mock.Setup(x => x.Name).Returns("NAME9999");
            mock.Setup(x => x.ParameterA).Returns(5);
            mock.Setup(x => x.ParameterB).Returns(6);

            DataAccessLayer.DALItemManagerSQLCompact m = new DataAccessLayer.DALItemManagerSQLCompact();
            bool res = m.Update(mock.Object);
            Assert.AreEqual(true, res);
        }
    }
}
