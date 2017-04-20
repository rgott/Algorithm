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
            for (int i = 0; i < NumberChunk.Length; i++)
            {
                if (lower.TryGetValue(NumberChunk[i], out var lowerNum))
                {
                    // if here again then count number
                    total += _sto;

                    // here then number
                    _sto = lowerNum;
                }
                else if (higher.TryGetValue(NumberChunk[i], out var higherNum))
                {
                    // multiply previous number
                    var zeroHolder = BigInteger.Pow(new BigInteger(10), higherNum);

                    if (_sto.IsZero)
                        throw new ArgumentException("Invalid number format.");

                    _sto = BigInteger.Multiply(zeroHolder, _sto);
                }
            }
            total += _sto;
            return total;
        }

        public static string ConvertToWord(BigInteger number)
        {
            if (number <= 19)
            {
                return lower.FirstOrDefault(n => n.Value == number).Key;
            }
            else
            {
                return RconvertToWord(number).TrimEnd('-');
            }
        }

        private static string RconvertToWord(BigInteger number)
        {
            if (number == 0)
            {
                return "";
            }
            if (number <= 19)
            {
                return lower.FirstOrDefault(n => n.Value == number).Key + "-";
            }
            else if (number <= 99)
            {
                return lower.FirstOrDefault(n => n.Value == (number / 10 * 10)).Key + "-" + RconvertToWord(number % 10);
            }
            else if (number <= 999)
            {
                return RconvertToWord(number / 100) + higher.ElementAt(0).Key + "-" + RconvertToWord(number % 100);
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
                var maxSet = higher.Last().Value;
                var numOfZeros = (totalSegmentCount - 1) * 3;
                while (numOfZeros > 0)
                {
                    if (numOfZeros > maxSet)
                    {
                        aboveHigherValues.Push(higher.Last().Key);

                        numOfZeros -= maxSet;
                        continue;
                    }

                    var value = higher.FirstOrDefault(m => m.Value >= numOfZeros);

                    aboveHigherValues.Push(value.Key);
                    numOfZeros -= value.Value;
                }

                var sb = new StringBuilder();
                while(aboveHigherValues.Count > 0)
                {
                    sb.Append(aboveHigherValues.Pop());
                    sb.Append('-');
                }

                return RconvertToWord(NumberInLeftSegment) + sb.ToString() + RconvertToWord(retSize);
            }
        }
    }
}
