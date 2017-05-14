using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.FSharp.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void IsPalindrometrueOddTest()
        {
            Assert.IsTrue(StringUtils.IsPalindrome("racecar"));
        }

        [TestMethod]
        public void IsPalindromefalseOddTest()
        {
            Assert.IsFalse(StringUtils.IsPalindrome("racecam"));
        }

        [TestMethod]
        public void IsPalindrometrueEvenTest()
        {
            Assert.IsTrue(StringUtils.IsPalindrome("ABBA"));
        }

        [TestMethod]
        public void IsPalindromefalseEvenTest()
        {
            Assert.IsFalse(StringUtils.IsPalindrome("ABBB"));
        }
    }
}
