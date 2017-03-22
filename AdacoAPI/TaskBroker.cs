using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdacoAPI.DataStructs;
using static AdacoAPI.DataValidator;
using static AdacoAPI.XMLHelper;

namespace AdacoAPI
{
    public class TaskBroker
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new TaskBroker().Subscribe(true);
            Application.Run(new AdacoAPIForm());
        }

        private void Subscribe(bool action)
        {
            if (action)
            {
                EventDispatcher.Instance.MainMessage += MessageHandler;
            }
            else
            {
                if (EventDispatcher.Instance != null) EventDispatcher.Instance.MainMessage -= MessageHandler;
            }
        }

        private void MessageHandler(object sender, EventDispatcher.MessageArgs contains)
        {
            if (!contains.State) EventDispatcher.Instance.RaiseFormMessage(false, "validationErrors");
            switch (contains.Message)
            {
                case "requestReady":
                        EventDispatcher.Instance.RaiseFormMessage(true, "requestReady");
                        EventDispatcher.Instance.RaiseSenderMessage(true, "sendRequest");
                    break;
                default:
                    break;
            }
            
        }
    }
}
