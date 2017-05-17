using System;
using System.IO;
using System.Text;

namespace Algorithm.CSharp.Transfer
{
    public class StreamListener
    {
        public readonly byte WAIT_SIZE = 1;
        public readonly int CHUNK_SIZE = 256;
        private Stream _Stream;
        private byte[] ChunkBuffer;

        public event MessageAvailableEventHandler MessageAvailable;
        public event EventHandler StreamClosed;
        
        

        public StreamListener(Stream Stream)
        {
            _Stream = Stream ?? throw new ArgumentNullException("Stream");

            ChunkBuffer = new byte[CHUNK_SIZE];
            WatchNext();
        }

        protected void OnStreamClosed()
        {
            StreamClosed?.Invoke(this, EventArgs.Empty);
        }

        protected void OnMessageAvailable(string message)
        {
            MessageAvailable?.Invoke(this, new MessageAvailableEventArgs(message));
        }


        protected void WatchNext()
        {
            try
            {
                _Stream.BeginRead(ChunkBuffer, 0, WAIT_SIZE, new AsyncCallback(ReadCallback), null);
            }catch(ObjectDisposedException)
            {
                // stream can no longer read since its been closed
                OnStreamClosed();
                return;
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                var bytesRead = _Stream.EndRead(ar);

                if (!_Stream.CanRead)
                {
                    OnStreamClosed();
                    return;
                }
            }
            catch (ObjectDisposedException)
            {
                // object disposed or stream is closed - graceful exit
                OnStreamClosed();
                return;
            }

            StringBuilder streamBuilder;
            if (_Stream.CanSeek)
            {
                _Stream.Position = 0;
                streamBuilder = new StringBuilder(CHUNK_SIZE);
            }
            else
            {
                // capture bytes written during listening 
                streamBuilder = new StringBuilder(
                    Encoding.ASCII.GetString(ChunkBuffer, 0, WAIT_SIZE),
                    CHUNK_SIZE);
            }

            // read from stream
            int numBytes;
            do
            {
                numBytes = _Stream.Read(ChunkBuffer, 0, CHUNK_SIZE);
                streamBuilder.Append(Encoding.ASCII.GetString(ChunkBuffer, 0, numBytes));
            } while (numBytes == CHUNK_SIZE);

            OnMessageAvailable(Encoding.ASCII.GetString(ChunkBuffer, 0, numBytes));
            WatchNext();
        }
    }
}
