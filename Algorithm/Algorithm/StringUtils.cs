﻿using System;
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
        public static List<string> MultiSplit(this string input,params string[] findIndexes)
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
                    else if(minIndex > index) // if found lower
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
    }
}