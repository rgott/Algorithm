using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm.Tests
{
    [TestClass]
    public class SortTest
    {
        int[] Items;
        int[] sortedList;
        public SortTest()
        {
            //Items = new int[] { 80, 85, 17, 27, 80, 94, 62, 54, 89, 39, 7, 25, 22, 35, 56, 35 };
            //sortedList = new int[] { 7, 17, 22, 25, 27, 35, 35, 39, 54, 56, 62, 80,80, 85, 89, 94};

            Items = new int[] { 16,12,14,15,13,1,3,2,4,5,7,6,8,9,11,10 };
            sortedList = new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 };


            //Items = new int[] { "C", "A", "B" , "Z","M","L","V","F","E","D","X","Y","N","O","P","Q"};
            //sortedList = new int[] { "A","B","C","D","E","F","L","M","N","O","P","Q","V","X","Y","Z" };
        }

        [TestMethod]
        public void Bubble()
        {
            int[] item = new int[Items.Length];
            Array.Copy(Items, item,Items.Length);

            Sort<int>.Bubble(ref item);

            CollectionAssert.AreEqual(sortedList,item);
        }

        [TestMethod]
        public void Selection()
        {
            int[] item = new int[Items.Length];
            Array.Copy(Items, item, Items.Length);

            Sort<int>.Selection(ref item);

            CollectionAssert.AreEqual(sortedList, item);
        }

        [TestMethod]
        public void Insertion()
        {
            int[] item = new int[Items.Length];
            Array.Copy(Items, item, Items.Length);

            Sort<int>.Insertion(ref item);

            CollectionAssert.AreEqual(sortedList, item);
        }

        [TestMethod]
        public void Merge()
        {
            int[] item = new int[Items.Length];
            Array.Copy(Items, item, Items.Length);

            Sort<int>.Merge(ref item);

            CollectionAssert.AreEqual(sortedList, item);
        }



    }
}
