using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static AdacoAPI.DataStructs;
using static AdacoAPI.AdacoAPIForm;

namespace AdacoAPI
{
    public class EventDispatcher
    {
        private static readonly Lazy<EventDispatcher> lazy =
        new Lazy<EventDispatcher>(() => new EventDispatcher());

        public static EventDispatcher Instance { get { return lazy.Value; } }

        private EventDispatcher() { }

        public class MessageArgs : EventArgs
        {
            public MessageArgs(bool s, string mes)
            {
                this.state = s;
                this.message = mes;
            }
            private bool state;
            private string message;
            public bool State
            {
                get { return state; }
                set { state = value; }
            }
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
        }

        // TODO: REWRITE

        public event EventHandler<MessageArgs> MainMessage; // events sent TO MAIN
        public event EventHandler<MessageArgs> FormMessage; // events sent TO FORM
        public event EventHandler<MessageArgs> DataMessage; // events sent TO VALIDATOR
        public event EventHandler<MessageArgs> SenderMessage; // events sent TO SENDER

        public void RaiseMainMessage(bool state, string message)
        {
            MainMessage?.Invoke(this, new MessageArgs(state, message));
        }

        public void RaiseFormMessage(bool state, string message)
        {
            FormMessage?.Invoke(this, new MessageArgs(state, message));
        }

        public void RaiseDataMessage(bool state, string message)
        {
            DataMessage?.Invoke(this, new MessageArgs(state, message));
        }

        public void RaiseSenderMessage(bool state, string message)
        {
            SenderMessage?.Invoke(this, new MessageArgs(state, message));
        }
    }
}
