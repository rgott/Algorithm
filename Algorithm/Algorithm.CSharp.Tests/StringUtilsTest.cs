using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CSharp.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void MultiSplitTest()
        {
            CollectionAssert.AreEqual(new List<string> { "10", "20", "30", "40" },"10 , 20 - 30 / 40".MultiSplit(",", "-", "/"));
        }

        #region IsPalindromeLinq
        [TestMethod]
        public void IsPalindromeLinqTrueOddTest()
        {
            Assert.IsTrue(StringUtils.IsPalindromeLinq("racecar"));
        }
        [TestMethod]
        public void IsPalindromeLinqFalseOddTest()
        {
            Assert.IsFalse(StringUtils.IsPalindromeLinq("racecam"));
        }
        [TestMethod]
        public void IsPalindromeLinqTrueEvenTest()
        {
            Assert.IsTrue(StringUtils.IsPalindromeLinq("ABBA"));
        }
        [TestMethod]
        public void IsPalindromeLinqTalseEvenTest()
        {
            Assert.IsFalse(StringUtils.IsPalindromeLinq("ABBB"));
        }
        #endregion


        #region IsPalindromeLinq
        [TestMethod]
        public void IsPalindromeLoopTrueOddTest()
        {
            Assert.IsTrue(StringUtils.IsPalindromeLoop("racecar"));
        }
        [TestMethod]
        public void IsPalindromeLoopFalseOddTest()
        {
            Assert.IsFalse(StringUtils.IsPalindromeLinq("racecam"));
        }
        [TestMethod]
        public void IsPalindromeLoopTrueEvenTest()
        {
            Assert.IsTrue(StringUtils.IsPalindromeLinq("ABBA"));
        }
        [TestMethod]
        public void IsPalindromeLoopTalseEvenTest()
        {
            Assert.IsFalse(StringUtils.IsPalindromeLinq("ABBB"));
        } 
        #endregion

    }
}
