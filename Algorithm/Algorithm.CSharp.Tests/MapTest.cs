using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithm.CSharp.Tests
{
    [TestClass]
    public class MapTest
    {
        KeyValuePair<string, int> SimplePair = new KeyValuePair<string, int>("1", 1);

        Map<string, int> Model;

        [TestInitialize]
        public void SetUp()
        {
            Model = new Map<string, int>();
        }

        [TestMethod]
        public void InsertIntoMapTest()
        {
            Model.Add(SimplePair);

            Assert.AreEqual("1", Model[1]);
            Assert.AreEqual(1, Model["1"]);

            Assert.IsTrue(Model.TryGetValue("1", out var value));
            Assert.AreEqual(1, value);

            Assert.IsTrue(Model.TryGetKey(1, out var key));
            Assert.AreEqual("1", key);
        }

        [TestMethod]
        public void RemoveMapItemTest()
        {
            Model.Add(SimplePair);
            Assert.AreEqual(1, Model.Count);

            Model.Remove(SimplePair.Key);
            Assert.AreEqual(0, Model.Count);
        }
    }
}
