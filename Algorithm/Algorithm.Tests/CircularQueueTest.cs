using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm.Tests
{
    [TestClass]
    public class CircularQueueTest
    {
        public CircularOverflowQueue<int> COFQ { get; set; }

        [TestMethod]
        public void BasicOperations1()
        {
            COFQ = new CircularOverflowQueue<int>(4);
            COFQ.Enqueue(0);
            COFQ.Enqueue(1);
            COFQ.Enqueue(2);
            COFQ.Enqueue(3);

            Assert.AreEqual(0, COFQ.Dequeue());
            Assert.AreEqual(1, COFQ.Dequeue());
            Assert.AreEqual(2, COFQ.Dequeue());
            Assert.AreEqual(3, COFQ.Dequeue());
        }

        [TestMethod]
        public void BasicOperations2()
        {
            COFQ = new CircularOverflowQueue<int>(4);
            COFQ.Enqueue(0);
            COFQ.Enqueue(1);
            COFQ.Enqueue(2);
            COFQ.Enqueue(3);

            Assert.AreEqual(0, COFQ.Dequeue());
            Assert.AreEqual(1, COFQ.Dequeue());

            COFQ.Enqueue(4);
            COFQ.Enqueue(5);

            Assert.AreEqual(2, COFQ.Dequeue());
            Assert.AreEqual(3, COFQ.Dequeue());
            Assert.AreEqual(4, COFQ.Dequeue());
            Assert.AreEqual(5, COFQ.Dequeue());

        }

        [TestMethod]
        public void underflow()
        {
            COFQ = new CircularOverflowQueue<int>(1);
            try
            {
                COFQ.Dequeue();// should fail
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
                // passed test
            }
        }

        [TestMethod]
        public void overflow()
        {
            COFQ = new CircularOverflowQueue<int>(2);
            COFQ.Enqueue(1);
            COFQ.Enqueue(2);
            COFQ.Enqueue(3);// should wrap around (pass)
        }

        [TestMethod]
        public void mutlipleOverflow()
        {
            COFQ = new CircularOverflowQueue<int>(2);
            COFQ.Enqueue(1);
            COFQ.Enqueue(2);
            COFQ.Enqueue(3);// All passed this should wrap around (pass)
            COFQ.Enqueue(4);
            COFQ.Enqueue(5);
            COFQ.Enqueue(6);
            COFQ.Enqueue(7);
            COFQ.Enqueue(8);
            COFQ.Enqueue(9);
            
            Assert.AreEqual(9, COFQ.Dequeue());
            Assert.AreEqual(8, COFQ.Dequeue());
        }
    }
}