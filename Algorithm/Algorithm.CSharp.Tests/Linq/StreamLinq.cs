using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.CSharp.Linq;

namespace Algorithm.CSharp.Tests.Linq
{
    [TestClass]
    public class StreamLinq
    {
        [TestMethod]
        public void StreamLinq1Test()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes("One Hundred"));

            CollectionAssert.AreEqual(
                new string[] { "One", "Hundred" }, 
                stream.Take(b => " ,".IndexOf((char)b) != -1).ToArray());
        }
    }
}
