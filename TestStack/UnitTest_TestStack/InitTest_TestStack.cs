using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack;

namespace UnitTest_TestStack
{
    [TestClass]
    public class InitTest_TestStack
    {
        /// <summary>
        /// Test that we have correct result while working with correct input
        /// </summary>
        [TestMethod]
        public void TestCorrecString()
        {
            myStack tst = new myStack("5 5 +");
            double expected = 10;
            Assert.AreEqual(expected, tst.myPop(), "test passed");
        }
        /// <summary>
        /// Test to return an exception type myException when the string is incorrect
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(myException))] //this one shows that an exception can be return while testing in such way 
        public void TestIncorrectString()
        {
            myStack tst = new myStack("5 +");

        }
    }
}
