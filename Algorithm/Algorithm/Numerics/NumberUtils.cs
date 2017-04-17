﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Numerics
{
    public partial class NumberUtils
    {
        public static BigInteger ConvertToNumber(string Number, char splitOn = '-')
        {
            return ConvertToNumber(Number.Split(splitOn));
        }

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
            else //if (number > 99 }
            {
                short segmentCount = (short)Math.Ceiling(number.ToString().Length / 3.0); // total number of segments 10,030,003 => 3 segments

                // length of number minus the latter segments e.g. num 10,030,003 => 8("10,030,003" } - 6("030,003" } = 2
                short firstSegmentSize = (short)(number.ToString().Length - (3 * (segmentCount - 1)));

                string segment = number.ToString().Substring(0, firstSegmentSize); // get first segment
                BigInteger numSegment = BigInteger.Parse(segment); // parse to int

                BigInteger retSize = number - ((ulong)numSegment * (ulong)Math.Pow(10, 3 * (segmentCount - 1)));
                return RconvertToWord(numSegment) + higher.ElementAt(segmentCount - 1).Key + "-" + RconvertToWord(retSize);
            }

        }
    }
}