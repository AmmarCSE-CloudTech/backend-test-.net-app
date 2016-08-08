using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoTest
{
    [TestClass]
    public class TestToDoController
    {
        [TestMethod]
        public void TestGet_ShouldReturnNull()
        {
            var controller = new Tod

            Assert.AreEqual(null, controller.Get());
        }
    }
}
