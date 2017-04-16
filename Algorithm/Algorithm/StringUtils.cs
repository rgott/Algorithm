using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class StringUtils
    {
        /*
        Given a string @value : string, @findIndexes : string[] 
        will find all values on either side
        and return the operands as an array 

        NOTE: consumes findIndexes
        */  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="findIndexes"></param>
        /// <returns></returns>
        public static List<string> MultiSplit(this string value,ref List<string> findIndexes)
        {
            List<string> list = new List<string>();
            while (value.Length != 0)
            {
                var min = value.Length;
                var minValue = "";

                // finds minimum index in the findIndexes array
                for (var i = 0; i < findIndexes.Count; i++)
                {// find minimum
                    var index = value.IndexOf(findIndexes[i]);
                    if (index == -1)
                    {

                        findIndexes.RemoveAt(i); // remove element
                        i--; // reset to previous
                        continue;
                    }
                    else if (index < min)
                    {
                        minValue = findIndexes[i];
                        min = index;
                    }
                }
                if (findIndexes.Count == 0)
                    break;

                var retVal = value.Substring(0, min).Trim(); // get left side
                if (!String.IsNullOrEmpty(retVal))
                {
                    list.Add(retVal);
                }

                var minV = min + minValue.Length;
                value = value.Substring(minV, value.Length);
            }
            if (!String.IsNullOrEmpty(value.Trim()))
            {
                list.Add(value.Trim());
            }

            return list;
        }
    }
}
