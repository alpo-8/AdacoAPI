using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AdacoAPI.AdacoAPIForm;
//using static AdacoAPI.Data;
using static AdacoAPI.DataStructs;
using static AdacoAPI.TaskBroker;

namespace AdacoAPI
{
    public class DataValidator
    {
        private static DataStructs.RequestData _currentRequest;
        private static DataStructs.FormData _onFormData;
        private string _validationErrorList;
        public DataValidator()
        {
            Subscribe(true);
        }

        private void Subscribe(bool action)
        {
            if (action)
            {
                EventDispatcher.Instance.DataMessage += MessageHandler;
            }
            else
            {
                if (EventDispatcher.Instance != null) EventDispatcher.Instance.DataMessage -= MessageHandler;
            }
        }

        private void MessageHandler(object sender, EventDispatcher.MessageArgs contains)
        {
            EventDispatcher.Instance.RaiseFormMessage(true, "validation started");
            StartValidation();
        }

        private void StartValidation()
        {
            _onFormData = Data.OnFormData;
            // Also here we send request media to parser IF NEEDED
            // if it's parsed successfully, it's put in 

            if ((_onFormData.Request == "fail") & (!ValidationItself()))
            {
                _validationErrorList = "many errors";
                EventDispatcher.Instance.RaiseMainMessage(false, _validationErrorList);
            }
            else
            {
                CollectRequestData();
            }
        }

        private bool ValidationItself()
        {
            // TODO: implement _onFormData validation
            return true;
        }

        private static async void CollectRequestData()
        {
            var thisMethod = Data.Methods.MethodStructByName(_onFormData.MethodName);

            var resource = thisMethod.Resource.Replace("{", string.Empty).Replace("}", string.Empty);
            resource = _onFormData.Parameters.Keys.Aggregate(resource, (current, inx) => current.Replace(inx, _onFormData.Parameters[inx]));

            _currentRequest = new DataStructs.RequestData()
            {
                Method = thisMethod.Type,
                Uri = new Uri(_onFormData.Endpoint + resource),
                Headers = _onFormData.AdacoHeaders
            }; //NO MEDIA HERE, see parser

            // TODO: rewrite auth calling
            Data.CurrentRequest = AuthKey.GenerateAuthHeader(_currentRequest);

            Task<string> task = RequestSender.SendRequest(Data.CurrentRequest);
            string result = await task;
            EventDispatcher.Instance.RaiseMainMessage(true, "requestIsReady");
            EventDispatcher.Instance.RaiseFormMessage(false, result);
        }
    }
}
