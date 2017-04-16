using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.Transfer;
using System.IO;
using System.Threading;

namespace Algorithm.Tests.Transfer
{
    [TestClass]
    public class StreamListenerTest
    {
        [TestMethod]
        public void ReadWriteTest()
        {
            using (var stream = new MemoryStream())
            {
                var Signal = new ManualResetEvent(false);
                var bytes = new byte[] { (byte)'t', (byte)'e', (byte)'s', (byte)'t' };

                var listener = new StreamListener(stream);
                listener.MessageAvailable += (s, e) =>
                {
                    Assert.AreEqual("test", e.Message);
                    Signal.Set();
                };

                stream.Write(bytes, 0, bytes.Length);

                Assert.IsTrue(Signal.WaitOne(1000)); // wait for event to complete
            }
        }

        [TestMethod]
        public void DisposalTest()
        {
            using (var stream = new MemoryStream())
            {
                var listener = new StreamListener(stream);

                // no errors on dispose
                stream.Dispose();
            }
        }

        [TestMethod]
        public void DisposalStreamClosedEventTest()
        {
            var Signal = new ManualResetEvent(false);
            using (var stream = new MemoryStream())
            {
                var listener = new StreamListener(stream);
                listener.StreamClosed += (s, e) => { Signal.Set(); };
            }
            Assert.IsTrue(Signal.WaitOne(1000)); // allow stream closed to run
        }
    }

}
