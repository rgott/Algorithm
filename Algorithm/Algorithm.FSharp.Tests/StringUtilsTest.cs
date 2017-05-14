using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.FSharp.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void IsPalindromeTrueOddTest()
        {
            Assert.IsTrue(StringUtils.IsPalindrome("racecar"));
        }

        [TestMethod]
        public void IsPalindromeFalseOddTest()
        {
            Assert.IsFalse(StringUtils.IsPalindrome("racecam"));
        }

        [TestMethod]
        public void IsPalindromeTrueEvenTest()
        {
            Assert.IsTrue(StringUtils.IsPalindrome("ABBA"));
        }

        [TestMethod]
        public void IsPalindromeFalseEvenTest()
        {
            Assert.IsFalse(StringUtils.IsPalindrome("ABBB"));
        }
    }
}
