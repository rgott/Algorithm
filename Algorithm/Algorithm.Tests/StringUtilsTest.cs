using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void MultiSplitTest()
        {
            CollectionAssert.AreEqual(new List<string> { "10", "20", "30", "40" },"10 , 20 - 30 / 40".MultiSplit(",", "-", "/"));
        }
    }
}
