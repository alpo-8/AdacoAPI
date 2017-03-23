using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdacoAPI.DataStructs;
using static AdacoAPI.DataValidator;

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

        private void MessageHandler(object sender, string message)
        {
            switch (message)
            {
                case "Request Initiated":
                    EventDispatcher.Instance.RaiseDataMessage("Start validation");
                    EventDispatcher.Instance.RaiseFormMessage("Validation Started");
                    break;
                case "Validation Errors":
                    EventDispatcher.Instance.RaiseFormMessage("Request not valid");
                    break;
                case "Request Collected":
                        EventDispatcher.Instance.RaiseFormMessage("Request is ready");
                        //EventDispatcher.Instance.RaiseSenderMessage("Send Request");
                    break;
                default:
                    break;
            }
            
        }
    }
}
