using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class BusinessLogicLayerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ServiceInterfaces.IItemBO>();
            mock.Setup(x => x.ParameterA).Returns(1);
            mock.Setup(x => x.ParameterB).Returns(1);
            mock.Setup(x => x.GetProduct()).Returns(123);

            double r = mock.Object.GetProduct();
        }
    }
}
