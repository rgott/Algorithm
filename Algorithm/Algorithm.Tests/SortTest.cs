using Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tests
{
    [TestClass]
    public class SortTest
    {
        string[] Items;
        string[] sortedList;
        public SortTest()
        {
            Items = new string[] { "C", "A", "B" , "Z","M","L","V","F","E","D"};
            sortedList = new string[] { "A","B","C","D","E","F","L","M","V","Z" };
        }

        [TestMethod]
        public void Bubble()
        {
            string[] item = new string[Items.Length];
            Array.Copy(Items, item,Items.Length);

            Sort<string>.Bubble(ref item);

            CollectionAssert.AreEqual(sortedList,item);
        }

        [TestMethod]
        public void Selection()
        {
            string[] item = new string[Items.Length];
            Array.Copy(Items, item, Items.Length);

            Sort<string>.Selection(ref item);

            CollectionAssert.AreEqual(sortedList, item);
        }

        [TestMethod]
        public void Insertion()
        {
            string[] item = new string[Items.Length];
            Array.Copy(Items, item, Items.Length);

            Sort<string>.Insertion(ref item);

            CollectionAssert.AreEqual(sortedList, item);
        }
    }
}
