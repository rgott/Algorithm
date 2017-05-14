using System;

namespace Algorithm.CSharp.Transfer
{
    public delegate void MessageAvailableEventHandler(object sender, MessageAvailableEventArgs e);
    public class MessageAvailableEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public MessageAvailableEventArgs(string Message) : base()
        {
            this.Message = Message;
        }
    }
}
