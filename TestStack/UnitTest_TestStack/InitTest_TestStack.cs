using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack;

namespace UnitTest_TestStack
{
    [TestClass]
    public class InitTest_TestStack
    {
        [TestMethod]
        public void TestCorrecString()
        {
            myStack tst = new myStack("5 5 +");
            double expected = 10;
            Assert.AreEqual(expected, tst.myPop(), "test passed");
        }
        [TestMethod]
        [ExpectedException(typeof(myException))] // ожидает что теструемый модуль вернет исключение при таком входе
        public void TestIncorrectString()
        {
            myStack tst = new myStack("5 +");
        }
    }
}
