using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using ClientInterfaces.Factories;
using ClientInterfaces.Models;
using ClientInterfaces;

namespace ClientUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kernel = IoC.IoCKernel.Kernel;
            IItemFactory f = kernel.Get<IItemFactory>();
            IResult<IItem> item = f.CreateItem(3);
        }
    }
}
