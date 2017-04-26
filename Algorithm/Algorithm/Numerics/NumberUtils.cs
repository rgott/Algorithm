using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;

namespace Algorithm.Numerics
{
    public partial class NumberUtils
    {
        public static BigInteger ConvertToNumber(string Number, char splitOn = '-')
        {
            return ConvertToNumber(Number.Split(splitOn));
        }

        /// <summary>
        /// Convert a word to a number
        /// </summary>
        /// <param name="NumberChunk">Section of a number word e.g. One-Hundred is two chunks [One, Hundred]</param>
        /// <returns></returns>
        public static BigInteger ConvertToNumber(string[] NumberChunk)
        {
            var total = BigInteger.Zero;

            var _sto = BigInteger.Zero;

            var start = 0;
            if(true == NumberChunk[0]?.Equals("Negative"))
            {
                start = 1;
            }

            for (int i = start; i < NumberChunk.Length; i++)
            {
                if (Lower.TryGetValue(NumberChunk[i], out var lowerNum))
                {
                    // if here again then count number
                    total += _sto;

                    // here then number
                    _sto = lowerNum;
                }
                else if (Higher.TryGetValue(NumberChunk[i], out var higherNum))
                {
                    // multiply previous number
                    var zeroHolder = BigInteger.Pow(new BigInteger(10), higherNum);

                    if (_sto.IsZero)
                        throw new ArgumentException("Invalid number format.");

                    _sto = BigInteger.Multiply(zeroHolder, _sto);
                }
            }
            total += _sto;

            if(1 == start)
            {
                total *= -1;
            }

            return total;
        }

        /// <summary>
        /// Converts a number e.g. "100" into a the word form "One-Hundred"
        /// </summary>
        /// <param name="number">Number to convert into a string word of that number.</param>
        /// <exception cref="StackOverflowException">Large numbers can cause recursion to fail.</exception>
        /// <exception cref="OutOfMemoryException">Large numbers can use all CLR memory.</exception>
        /// <returns>string representation of the number.</returns>
        public static string ConvertToWord(BigInteger number)
        {
            if (number < 0)
            {
                return "Negative-" + Rec_ConvertToWord(number * -1).TrimEnd('-');
            }
            else
            {
                return Rec_ConvertToWord(number).TrimEnd('-');
            }
        }

        /// <summary>
        /// Recursive Function used in <see cref="ConvertToWord(BigInteger)"/>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string Rec_ConvertToWord(BigInteger number)
        {
            if (number == 0)
            {
                return "";
            }
            if (number <= 19)
            {
                return Lower.FirstOrDefault(n => n.Value == number).Key + "-";
            }
            else if (number <= 99)
            {
                return Lower.FirstOrDefault(n => n.Value == (number / 10 * 10)).Key + "-" + Rec_ConvertToWord(number % 10);
            }
            else if (number <= 999)
            {
                return Rec_ConvertToWord(number / 100) + Higher.ElementAt(0).Key + "-" + Rec_ConvertToWord(number % 100);
            }
            else //if (number > 999)
            {

                var totalSegmentCount = (int)Math.Ceiling(number.ToString().Length / 3.0); // total number of segments 10,030,003 => 3 segments
                BigInteger NumberInLeftSegment; // compute value in left most segment
                {
                    // length of number minus the latter segments e.g. num 10,030,003 => 8("10,030,003" } - 6("030,003" } = 2
                    var leftSegmentSize = number.ToString().Length - (3 * (totalSegmentCount - 1));

                    var leftSegment = number.ToString().Substring(0, leftSegmentSize); // get first segment
                    NumberInLeftSegment = BigInteger.Parse(leftSegment); // max of 3 segments or 999
                }

                var retSize = number - (NumberInLeftSegment * BigInteger.Pow(10, 3 * (totalSegmentCount - 1))); // remove left segment

                var aboveHigherValues = new Stack<string>();
                var maxSet = Higher.Last().Value;
                var numOfZeros = (totalSegmentCount - 1) * 3;
                while (numOfZeros > 0)
                {
                    if (numOfZeros > maxSet)
                    {
                        aboveHigherValues.Push(Higher.Last().Key);

                        numOfZeros -= maxSet;
                        continue;
                    }

                    var value = Higher.FirstOrDefault(m => m.Value >= numOfZeros);

                    aboveHigherValues.Push(value.Key);
                    numOfZeros -= value.Value;
                }

                var sb = new StringBuilder();
                while(aboveHigherValues.Count > 0)
                {
                    sb.Append(aboveHigherValues.Pop());
                    sb.Append('-');
                }

                return Rec_ConvertToWord(NumberInLeftSegment) + sb.ToString() + Rec_ConvertToWord(retSize);
            }
        }
    }
}
