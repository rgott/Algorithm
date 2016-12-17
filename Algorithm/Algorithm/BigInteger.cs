using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class BigInteger
    {
        LinkedList<ushort> Numbers = new LinkedList<ushort>();
        public BigInteger(string number)
        {
            Numbers.AddFirst(1);
        }
        private BigInteger()
        {

        }

        public static BigInteger operator +(BigInteger b1,BigInteger b2)
        {
            LinkedListNode<ushort> currNodeB1 = b1.Numbers.First;
            LinkedListNode<ushort> currNodeB2 = b2.Numbers.First;

            int overflow = 0;
            LinkedList<ushort> SumList = new LinkedList<ushort>();
            do
            {
                var adder = add(currNodeB2.Value, currNodeB1.Value,ref overflow);
                SumList.AddLast(adder);
            } while ((currNodeB1 = currNodeB1.Next) != null
                  && (currNodeB2 = currNodeB2.Next) != null);

            FinishAddingLongerList(ref SumList, currNodeB1, currNodeB2);

            return new BigInteger() { Numbers = SumList };
        }

        private static void FinishAddingLongerList(ref LinkedList<ushort> sumList,LinkedListNode<ushort> b1,LinkedListNode<ushort> b2)
        {
            while (b2.Next != null)
            {
                sumList.AddLast(b2.Value);
            }

            while (b1.Next != null)
            {
                sumList.AddLast(b1.Value);
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="us1"></param>
        /// <param name="us2"></param>
        /// <returns>
        /// T1 = number
        /// T2 = overflow
        /// </returns>
        private static ushort add(ushort us1,ushort us2,ref int retOvfl)
        {
            ushort retNum = 0;

            int number = us1 + us2;

            if (number > ushort.MaxValue || (number + retOvfl) > ushort.MaxValue)
                retOvfl += number - ushort.MaxValue;
            else
                retNum = (ushort)number;

            return retNum;
        }
    }
}
