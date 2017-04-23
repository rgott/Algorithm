using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithm.Tests
{
    [TestClass]
    public class SortTest
    {
        List<KeyValuePair<int[], int[]>> Items = new List<KeyValuePair<int[], int[]>>();
        public SortTest()
        {
            int[] unsorted, sorted;

            unsorted = new int[] { 4, 1, 2, 3};
            sorted = new int[] { 1, 2, 3, 4};
            Items.Add(new KeyValuePair<int[], int[]>(sorted, unsorted));

            unsorted = new int[] { 80, 85, 17, 27, 80, 94, 62, 54, 89, 39, 7, 25, 22, 35, 56, 35 };
            sorted = new int[] { 7, 17, 22, 25, 27, 35, 35, 39, 54, 56, 62, 80, 80, 85, 89, 94 };
            Items.Add(new KeyValuePair<int[], int[]>(sorted, unsorted));

            unsorted = new int[] { 16, 12, 14, 15, 13, 1, 3, 2, 4, 5, 7, 6, 8, 9, 11, 10, 19, 18, 17 };
            sorted = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            Items.Add(new KeyValuePair<int[], int[]>(sorted, unsorted));

            unsorted = new int[] { 19, 18, 17 };
            sorted = new int[] { 17, 18, 19 };
            Items.Add(new KeyValuePair<int[], int[]>(sorted, unsorted));


            unsorted = new int[] { 19, 18, 17 };
            sorted = new int[] { 17, 18, 19 };
            Items.Add(new KeyValuePair<int[], int[]>(sorted, unsorted));

        }
        private delegate void SortMethod(ref int[] items);
        private void TestArray(SortMethod method)
        {
            foreach (var item in Items)
            {
                int[] list = new int[item.Value.Length];
                Array.Copy(item.Value, list, item.Value.Length);

                method(ref list);
                CollectionAssert.AreEqual(item.Key, list);
            }
        }


        [TestMethod]
        public void Bubble()
        {
            TestArray(Sort<int>.Bubble);
        }

        [TestMethod]
        public void Selection()
        {
            TestArray(Sort<int>.Selection);
        }

        [TestMethod]
        public void Insertion()
        {
            TestArray(Sort<int>.Insertion);
        }

    }
}
