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
            int expected = 10;
            Assert.AreEqual(expected, tst.myPop(), "test passed");
        }
        [TestMethod]
        public void TestIncorrectString()
        {
            myStack tst = new myStack("5 +");
            //Assert.
            // exception returns
        }
    }
}
