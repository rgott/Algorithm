using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    /// OverWrittable circular queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FixedCircularQueue<T>
    {
        private readonly T[] Items;
        private int enqueuePos;
        private int dequeuePos;

        /// <summary>
        /// Maximum number of items that can fit in the queue.
        /// </summary>
        public int MaxSize { get; private set; }

        /// <summary>
        /// Current Number of items in the queue.
        /// </summary>
        public int Size { get; private set; }


        /// <summary>
        /// Set array behind the scenes
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Value at index.</returns>
        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MaxSize">Number of elements can be added to queue. Anything values enqueued over will be overwritten</param>
        public FixedCircularQueue(int MaxSize)
        {
            Items = new T[MaxSize];
            this.MaxSize = MaxSize;
            Size = 0;

            // start before beginning 
            // move to position then set value
            enqueuePos = -1; 
            dequeuePos = -1;
        }

        /// <summary>
        /// Add items to queue. Items will be overwritten if too many are added.
        /// </summary>
        /// <param name="item">Add to queue</param>
        public void Enqueue(T item)
        {
            // if out of bounds reset
            if (enqueuePos + 1 >= MaxSize)
                enqueuePos = 0;
            else
                enqueuePos++;

            if (Size < MaxSize)// bound size
                Size++;
            else // if maxSize then enqueue will pass dequeue. Keep dequeue ahead
                dequeuePos++;

            Items[enqueuePos] = item; // set item
        }

        /// <summary>
        /// Remove items from queue.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">If no elements are in queue.</exception>
        /// <returns></returns>
        public T Dequeue()
        {
            if (dequeuePos + 1 >= MaxSize) // if out of bounds reset
                dequeuePos = -1;

            if (Size-- <= 0)
                throw new IndexOutOfRangeException("No elements in queue.");

            return Items[++dequeuePos];
        }
    }
}
