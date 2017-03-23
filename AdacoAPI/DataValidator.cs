using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AdacoAPI.AdacoAPIForm;
//using static AdacoAPI.Data;
using static AdacoAPI.DataStructs;
using static AdacoAPI.MainAuth;

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

        private void MessageHandler(object sender, string message)
        {
            switch (message)
            {
                case "Start validation":
                    StartValidation();
                    break;
            }
        }

        private void StartValidation()
        {
            _onFormData = Data.OnFormData;

            if ((_onFormData.Request == "fail") & (!ValidationItself()))
            {
                _validationErrorList = "many errors";
                EventDispatcher.Instance.RaiseMainMessage("Validation Errors");  // TODO: should pass _validationErrorList to the form
            }
            else
            {
                CollectRequestData();
                // Also here we send request media to parser IF NEEDED
                // if it's parsed successfully, it's put in 
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

            _currentRequest = new DataStructs.RequestData()
            {
                Method = thisMethod.Type,
                Uri = new Uri(_onFormData.Endpoint + _onFormData.Parameters.Keys.Aggregate(resource, (current, inx) => current.Replace(inx, _onFormData.Parameters[inx]))),
                Headers = _onFormData.AdacoHeaders
            }; //NO MEDIA HERE
            


            Data.CurrentRequest = _currentRequest;
            EventDispatcher.Instance.RaiseMainMessage("Request Collected");
            Task<string> task = RequestSender.SendRequest(Data.CurrentRequest); // TODO: return headers on UI
            string result = await task;

            //EventDispatcher.Instance.RaiseFormMessage(result);
        }
    }
}
