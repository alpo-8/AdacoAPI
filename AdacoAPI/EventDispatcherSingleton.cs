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

        public class FormArgs : EventArgs
        {
            public FormArgs(string ctrl, string txt)
            {
                this.control = ctrl;
                this.text = txt;
            }
            private string control;
            private string text;
            public string Control
            {
                get { return control; }
                set { control = value; }
            }
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
        }

        // TODO: REWRITE

        public event EventHandler<string> MainMessage; // events sent TO MAIN
        public event EventHandler<FormArgs> FormMessage; // events sent TO FORM
        public event EventHandler<string> DataMessage; // events sent TO VALIDATOR
        public event EventHandler<string> SenderMessage; // events sent TO SENDER

        public void RaiseMainMessage(string message)
        {
            MainMessage?.Invoke(this, message);
        }

        public void RaiseFormMessage(string control, string text)
        {
            FormMessage?.Invoke(this, new FormArgs(control, text));
        }

        public void RaiseDataMessage(string message)
        {
            DataMessage?.Invoke(this, message);
        }

        public void RaiseSenderMessage(string message)
        {
            SenderMessage?.Invoke(this, message);
        }
    }
}
