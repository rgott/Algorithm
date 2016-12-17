using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm
{
    public class Sort<T> where T : IComparable
    {
        private static void Swap(ref T[] array, int swapIndex1, int swapIndex2)
        {
            T temp = array[swapIndex1];
            array[swapIndex1] = array[swapIndex2];
            array[swapIndex2] = temp;
        }


        public static void Bubble(ref T[] array)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true; // always assume sorted until found not to be
                for (int i = 0; i < array.Length - 1; i++)
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
            if(array.Length > 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int minValue = i;
                    for (int j = i; j < array.Length; j++)
                    {
                        if((array[minValue] as IComparable).CompareTo(array[j]) == 1) // first < second then second = max
                            minValue = j;
                    }

                    if(minValue != i)
                        Swap(ref array, minValue, i);
                }
            }
        }

        public static void Insertion(ref T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if ((array[i] as IComparable).CompareTo(array[i + 1]) == 1) // first > second then swap and check list
                {
                    // swap
                    Swap(ref array, i, i + 1);

                    // check list
                    for (int j = i; j > 0; j--)
                    {
                        if ((array[j] as IComparable).CompareTo(array[j - 1]) == -1)// if not in order
                            Swap(ref array, j, j - 1);
                    }
                }
            }
        }

        public static void Merge(ref T[] array)
        {
            int length = (array.Length % 2 == 1) ? array.Length - 1 : array.Length;
            int? LeftPtr = null;// secondary left pointer

            for (int distoffset = 1; distoffset < length; distoffset *= 2)
            {// outer pass
                for (int i = 0; i < length / distoffset; i++)
                {
                    int PlacementPtr = i * (distoffset * 2);
                    int RightPtr = PlacementPtr + distoffset;
                    int max = RightPtr + distoffset;

                    while(true)
                    {
                        if(LeftPtr != null && RightPtr >= max)
                        {
                            RightPtr = (int)LeftPtr;
                            LeftPtr = null;
                        }
                        else
                        {

                            if (PlacementPtr >= RightPtr || RightPtr >= max || RightPtr >= array.Length)
                            {
                                break;
                            }
                        }
                        if (LeftPtr != null)
                        {
                            if (array[(int)LeftPtr].CompareTo(array[RightPtr]) == 1)
                            //if([PrimaryLeftPtr] > [RightPtr])
                            { // swap right
                                if (PlacementPtr == LeftPtr) LeftPtr = RightPtr;
                                Swap(ref array, PlacementPtr++, RightPtr++);
                            }
                            else
                            { // swap left
                                Swap(ref array, PlacementPtr++, (int)LeftPtr++);

                                if (LeftPtr >= RightPtr)
                                    LeftPtr = null;
                            }
                        }
                        else if (array[PlacementPtr].CompareTo(array[RightPtr]) == 1)
                        //else if (array[LeftPtr] > array[RightPtr])
                        {
                            LeftPtr = RightPtr;
                            Swap(ref array, PlacementPtr++, RightPtr++);
                        }
                        else
                        {
                            PlacementPtr++;
                        }
                    }
                    LeftPtr = null;
                }
            }
        }
    }
}