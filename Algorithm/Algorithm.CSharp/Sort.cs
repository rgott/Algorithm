using System;

namespace Algorithm.CSharp
{
    public class Sort<T> where T : IComparable
    {
        private static void Swap(ref T[] array, int swapIndex1, int swapIndex2)
        {
            var temp = array[swapIndex1];
            array[swapIndex1] = array[swapIndex2];
            array[swapIndex2] = temp;
        }

        public static void Bubble(ref T[] array)
        {
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true; // always assume sorted until found not to be
                for (var i = 0; i < array.Length - 1; i++)
                {
                    if ((array[i] as IComparable).CompareTo(array[i + 1]) == 1) // (first > second)? then swap
                    {
                        isSorted = false;

                        Swap(ref array, i, i + 1);
                    }
                }
            }
        }

        public static void Selection(ref T[] array)
        {
            if (array.Length > 1)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    var minValue = i;
                    for (var j = i; j < array.Length; j++)
                    {
                        if ((array[minValue] as IComparable).CompareTo(array[j]) == 1) // first < second then second = max
                            minValue = j;
                    }

                    if (minValue != i)
                        Swap(ref array, minValue, i);
                }
            }
        }

        public static void Insertion(ref T[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                if ((array[i] as IComparable).CompareTo(array[i + 1]) == 1) // first > second then swap and check list
                {
                    // swap
                    Swap(ref array, i, i + 1);

                    // check list
                    for (var j = i; j > 0; j--)
                    {
                        if ((array[j] as IComparable).CompareTo(array[j - 1]) == -1)// if not in order
                            Swap(ref array, j, j - 1);
                    }
                }
            }
        }
        
    }
}