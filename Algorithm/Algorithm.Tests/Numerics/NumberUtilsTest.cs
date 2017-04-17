using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Algorithm.Numerics;
using System.Linq.Expressions;

namespace Algorithm.Tests.Numerics
{
    [TestClass]
    public class NumberUtilsTest
    {
        [TestMethod]
        public void ConvertToNumber100Test()
        {
            Assert.AreEqual(new BigInteger(100), NumberUtils.ConvertToNumber("One-Hundred"));
        }

        [TestMethod]
        public void ConvertToNumber1_240Test()
        {
            Assert.AreEqual(new BigInteger(1_240), NumberUtils.ConvertToNumber("One-Thousand-Two-Hundred-Fourty"));
        }

        [TestMethod]
        public void ConvertToNumber14_006Test()
        {
            Assert.AreEqual(new BigInteger(14_006), NumberUtils.ConvertToNumber("Fourteen-Thousand-Six"));
        }

        [TestMethod]
        public void ConvertToNumber100_000_000Test()
        {
            Assert.AreEqual(new BigInteger(100_000_000), NumberUtils.ConvertToNumber("One-Hundred-Million"));
        }

        [TestMethod]
        public void ConvertToNumber96Test()
        {
            Assert.AreEqual(new BigInteger(96), NumberUtils.ConvertToNumber("Ninety-Six"));
        }

        [TestMethod]
        public void ConvertToNumber16Test()
        {
            Assert.AreEqual(new BigInteger(16), NumberUtils.ConvertToNumber("Sixteen"));
        }
        [TestMethod]
        public void ConvertToNumber3Test()
        {
            Assert.AreEqual(new BigInteger(3), NumberUtils.ConvertToNumber("Three"));
        }
        [TestMethod]
        public void ConvertToNumberCentillionTest()
        {
            string str = NumberUtils.ConvertToNumber("One-Centillion").ToString();
            Assert.AreEqual(
                "1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", 
                str.ToString());
        }

        [TestMethod]
        public void ConvertToWord10Test()
        {
            Assert.AreEqual("Ten", NumberUtils.ConvertToWord(new BigInteger(10)));
        }

        [TestMethod]
        public void ConvertToWord317Test()
        {
            Assert.AreEqual("Three-Hundred-Seventeen", NumberUtils.ConvertToWord(new BigInteger(317)));
        }
        [TestMethod]
        public void ConvertToWord96Test()
        {
            Assert.AreEqual("Ninety-Six", NumberUtils.ConvertToWord(new BigInteger(96)));
        }
        [TestMethod]
        public void ConvertToWord16Test()
        {
            Assert.AreEqual("Sixteen", NumberUtils.ConvertToWord(new BigInteger(16)));
        }
        [TestMethod]
        public void ConvertToWord100_000_000Test()
        {
            Assert.AreEqual("One-Hundred-Million", NumberUtils.ConvertToWord(new BigInteger(100_000_000)));
        }
        [TestMethod]
        public void ConvertToWord501Test()
        {
            Assert.AreEqual("Five-Hundred-One", NumberUtils.ConvertToWord(new BigInteger(501)));
        }

        
    }
}
