using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm.CSharp.Linq
{
    public static class StreamLinq
    {
        /// <summary>
        /// Implementation of Take for Streams
        /// </summary>
        /// <param name="stream">The sequence to return elements from.</param>
        /// <param name="predicate">Take while expression is false, once expression is true return value.</param>
        /// <param name="size">Buffer size to read from stream</param>
        /// <returns></returns>
        public static IEnumerable<string> Take(this Stream stream, Func<byte, bool> predicate, int size = 5)
        {
            StringBuilder sb = new StringBuilder();

            byte[] buffer = new byte[size];

            int read = -1;
            while(stream.CanRead && read != 0)
            {
                read = stream.Read(buffer, 0, size);
                for (int i = 0; i < read; i++)
                {
                    if(predicate(buffer[i]))
                    {
                        if(sb.Length != 0)
                        {
                            yield return sb.ToString();
                            sb = new StringBuilder();
                        }
                    }
                    else
                    {
                        sb.Append((char)buffer[i]);
                    }
                }
            }
            yield return sb.ToString();
        }
    }
}
