using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CSharp
{
    public static class StringUtils
    {
        /*
        Given a string @value : string, @findIndexes : string[] 
        will find all values on either side
        and return the operands as an array 
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="findIndexes"></param>
        /// <returns></returns>
        public static List<string> MultiSplit(this string input, params string[] findIndexes)
        {
            string value = input;
            List<string> indicies = new List<string>(findIndexes);
            List<string> result = new List<string>();
            while (value.Length != 0)
            {
                var minIndex = value.Length;
                var minValue = "";

                // finds minimum index in the findIndexes array
                for (var i = 0; i < indicies.Count; i++)
                {// find minimum
                    var index = value.IndexOf(indicies[i]);
                    if (index == -1)
                    {
                        indicies.RemoveAt(i); // remove element
                        i--; // reset to previous
                        continue;
                    }
                    else if (minIndex > index) // if found lower
                    {
                        minIndex = index;
                        minValue = indicies[i];
                    }
                }
                if (indicies.Count == 0)
                    break;

                var retVal = value.Substring(0, minIndex).Trim(); // get left side
                if (!String.IsNullOrEmpty(retVal))
                {
                    result.Add(retVal);
                }

                var minV = minIndex + minValue.Length;
                value = value.Substring(minV, value.Length - minV);
            }
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                result.Add(value.Trim());
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="findIndexes"></param>
        /// <returns>Two lists items split and the index string that the item was split on.</returns>
        public static (List<string> SplitItems, List<string> splitOnIndecies) MultiSplitWithSplits(this string input, params string[] findIndexes)
        {
            string value = input;
            List<string> splitOnIndecies = new List<string>();
            List<string> indicies = new List<string>(findIndexes);
            List<string> result = new List<string>();
            while (value.Length != 0)
            {
                var minIndex = value.Length;
                var minValue = "";

                // finds minimum index in the findIndexes array
                for (var i = 0; i < indicies.Count; i++)
                {// find minimum
                    var index = value.IndexOf(indicies[i]);
                    if (index == -1)
                    {
                        indicies.RemoveAt(i); // remove element
                        i--; // reset to previous
                        continue;
                    }
                    else if (minIndex > index) // if found lower
                    {
                        minIndex = index;
                        minValue = indicies[i];
                    }
                }
                if (indicies.Count == 0)
                    break;

                var retVal = value.Substring(0, minIndex).Trim(); // get left side
                if (!String.IsNullOrEmpty(retVal))
                {
                    result.Add(retVal);
                    splitOnIndecies.Add(minValue);
                }

                var minV = minIndex + minValue.Length;
                value = value.Substring(minV, value.Length - minV);
            }
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                result.Add(value.Trim());
            }

            return (result, splitOnIndecies);
        }

        public static bool IsPalindromeLinq(string word)
        {
            return word.SequenceEqual(word.Reverse());
        }

        public static bool IsPalindromeLoop(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if(word[i] != word[word.Length - i - 1])
                    return false;
            }
            return true;
        }
    }
}
