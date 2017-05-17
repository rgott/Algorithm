using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Algorithm.CSharp.Linq;

namespace Algorithm.CSharp.Numerics
{
    public partial class NumberUtils
    {
        const char wordSeparator = ' ';
        const char wordJoiner = '-';
        const string HigherNumberSeparator = ", ";

        public static BigInteger ConvertToNumber(string Number, char splitOn = wordJoiner)
        {
            return ConvertToNumber(new MemoryStream(Encoding.ASCII.GetBytes(Number)));
        }

        public static BigInteger ConvertToNumber(Stream inputNumber)
        {
            return ConvertToNumber(inputNumber.Take(b => "- ,".IndexOf((char)b) != -1));
        }

        /// <summary>
        /// Convert a word to a number
        /// </summary>
        /// <param name="NumberChunk">Section of a number word e.g. One-Hundred is two chunks [One, Hundred]</param>
        /// <returns></returns>
        public static BigInteger ConvertToNumber(IEnumerable<string> NumberChunk)
        {
            var total = BigInteger.Zero;

            var _sto = BigInteger.Zero;
            var tmp = NumberChunk;

            var isNegative = false;

            foreach (var item in NumberChunk)
            {
                if (Lower.TryGetValue(item, out var lowerNum))
                {
                    // if here again then count number
                    total += _sto;

                    // here then number
                    _sto = lowerNum;
                }
                else if (Higher.TryGetValue(item, out var higherNum))
                {
                    // multiply previous number
                    var zeroHolder = BigInteger.Pow(new BigInteger(10), higherNum);

                    if (_sto.IsZero)
                        throw new ArgumentException("Invalid number format.");

                    _sto = BigInteger.Multiply(zeroHolder, _sto);
                }
                else if(item.Equals("Negative"))
                {
                    isNegative = true;
                }
            }
            total += _sto;

            if(isNegative)
                total *= -1;

            return total;
        }


        public static string ConvertToWord(int number)
        {
            return ConvertToWord(number.ToString());
        }
        public static string ConvertToWord(BigInteger number)
        {
            return ConvertToWord(number.ToString());
        }
        public static string ConvertToWord(long number)
        {
            return ConvertToWord(number.ToString());
        }

        /// <summary>
        /// Converts a number e.g. "100" into a the word form "One-Hundred"
        /// </summary>
        /// <param name="number">Number to convert into a string word of that number.</param>
        /// <exception cref="StackOverflowException">Large numbers can cause recursion to fail.</exception>
        /// <exception cref="OutOfMemoryException">Large numbers can use all CLR memory.</exception>
        /// <returns>string representation of the number.</returns>
        public static string ConvertToWord(String number)
        {
            var sb = new StringBuilder();

            StreamConvertToWord(
                new MemoryStream(Encoding.ASCII.GetBytes(number)),
                new StringWriter(sb), 
                number.Length);
            return sb.ToString();   
        }

        public static BigInteger CountCharactersInStream(string file, int chunkSize = 1014)
        {
            using (var stream = File.Open(file, FileMode.Open))
            {
                var buffer = new byte[chunkSize];
                BigInteger count = 0;
                while (stream.CanRead)
                {
                    var currentRead = stream.Read(buffer, 0, buffer.Length);
                    count += currentRead;

                    if(currentRead != chunkSize)
                        break;
                }
                return count;
            }
        }

        /// <summary>
        /// Numbers that are too large to be converted into a word in memory can be streamed in via a text file.
        /// </summary>
        /// <param name="inputNumber">Number or File that contains the number to be converted into a word</param>
        /// <param name="output">
        /// Output that allows number to be written to the file while being created to save memory.
        /// </param>
        /// <param name="inputLength">
        /// Stream will need to be counted first since the position of the segment
        /// first needs to be determined. E.G. is the comma of the number 
        /// one,two or three places away from the first comma of the number
        /// </param>
        public static void StreamConvertToWord(Stream inputNumber, TextWriter output, int inputLength)
        {
            var segmentBuffer = new byte[3];

            var fillResult = FillFirstSegment(ref segmentBuffer,inputLength);
            inputLength -= fillResult.TakenLength;
            
            if (fillResult.IsNegative)
            {
                output.Write("Negative");
                output.Write(wordSeparator);
            }

            ConvertCharToByte(ref segmentBuffer);
            if (!Contains(ref segmentBuffer, b => b != 0))
            {
                output.Write("Zero");
                return;
            }
            SegmentToStringLower(ref segmentBuffer, output, inputLength);

            while(inputLength > 0)
            {
                inputNumber.Read(segmentBuffer, 0, 3);
                ConvertCharToByte(ref segmentBuffer);

                if (!Contains(ref segmentBuffer, b => b != 0))
                {
                    inputLength -= 3;
                    continue;
                }

                output.Write(HigherNumberSeparator);
                SegmentToStringLower(ref segmentBuffer, output, inputLength -= 3);
            }

            (bool IsNegative, int TakenLength) FillFirstSegment(ref byte[] buffer, int length)
            {
                var IsNegative = false;
                var start = (3 - (length % 3)) % 3;
                inputNumber.Read(segmentBuffer, start, 1);
                length--;

                var segments = length % 3;
                length -= segments;


                var retSegment = 3 - start;
                if (Contains(ref segmentBuffer, b => b == (byte)'-'))
                {
                    IsNegative = true;

                    segmentBuffer[start] = 0;
                    if (start == 2)
                    { // start is at end read more
                        retSegment += FillFirstSegment(ref buffer, length).TakenLength;
                    }
                    else
                    {
                        inputNumber.Read(segmentBuffer, start + 1, segments);
                    }
                }
                else
                {
                    inputNumber.Read(segmentBuffer, start + 1, segments);
                }
                return (IsNegative, retSegment);
            }
        }

        public static bool Contains(ref byte[] buffer, Func<byte,bool> predicate)
        {
            for (var i = 0; i < buffer.Length; i++)
            {
                if(predicate(buffer[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputNumber">buffer length 3</param>
        /// <param name="segmentNum"></param>
        /// <returns></returns>
        private static void SegmentToStringLower(ref byte[] segmentBuffer, TextWriter outputStream, int zerosAfterCurrentSegment)
        {
            if(segmentBuffer[0] != 0)
            { // 100 - 900 -> hundredths place
                outputStream.Write(Lower[segmentBuffer[0]]);
                outputStream.Write(wordSeparator);
                outputStream.Write(Higher.First().Key);

                if(segmentBuffer[1] != 0 || segmentBuffer [2] != 0)
                    outputStream.Write(wordSeparator);
            }
            if (segmentBuffer[1] != 0)
            { // 10 - 99
                segmentBuffer[1] *= 10;
                if (segmentBuffer[1] == 10)
                { // 10 - 19
                    outputStream.Write(Lower[segmentBuffer[1] + segmentBuffer[2]]);
                }
                else
                { // 20 - 99
                    outputStream.Write(Lower[segmentBuffer[1]]);
                    outputStream.Write(wordJoiner);
                    outputStream.Write(Lower[segmentBuffer[2]]);
                }
            }
            else if (segmentBuffer[2] != 0)
            { // 1 - 9
                outputStream.Write(Lower[segmentBuffer[2]]);
            }

            SegmentToStringHigher(outputStream, zerosAfterCurrentSegment);
        }

        private static void SegmentToStringHigher(TextWriter outputStream, int zerosAfterCurrentSegment)
        {
            var countMaxKey = 0;
            var numOfZeros = zerosAfterCurrentSegment;
            // find and remove largest values possible
            // since smaller values must be first 
            {
                var maxSet = Higher.Last().Value;
                while (numOfZeros > maxSet)
                {
                    countMaxKey++;
                    numOfZeros -= maxSet;
                }
            }

            // find smaller values based on wether they can be found 
            // in the subset or must be calculated with smaller values to reach exact number
            if (numOfZeros > 0)
            {
                if (numOfZeros % 3 == 0)
                {
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher[numOfZeros]);
                }
                else if (numOfZeros % 3 == 1)
                {
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher.First().Key);
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher.First().Key);
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher[numOfZeros - 4]);
                }
                else// == 2
                {
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher.First().Key);
                    outputStream.Write(wordSeparator);
                    outputStream.Write(Higher[numOfZeros - 2]);
                }
            }
            var maxValue = Higher.Last().Key;
            for (var j = 0; j < countMaxKey; j++)
            {
                outputStream.Write(wordSeparator);
                outputStream.Write(maxValue);
            }
        }

        /// <summary>
        /// Allows byte to be used as number
        /// </summary>
        /// <param name="num">destructively changes all values</param>
        /// <exception cref="InvalidCastException"></exception>
        private static void ConvertCharToByte(ref byte[] num)
        {
            for (var i = 0; i < num.Length; i++)
            {
                if (num[i] == 0)
                    continue;

                num[i] -= (byte)'0';
                if (num[i] > 9)
                    throw new InvalidCastException("Failed to convert: " + num[i] + " (before subtraction: " + (char)(num[i] + (byte)'0') + ")");
            }
        }
    }
}
