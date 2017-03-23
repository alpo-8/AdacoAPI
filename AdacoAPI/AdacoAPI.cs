using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static AdacoAPI.Data;
using static AdacoAPI.DataStructs;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace AdacoAPI
{
    public partial class AdacoAPIForm : Form
    {
        private readonly SynchronizationContext synchronizationContext;
        private DateTime previousTime = DateTime.Now;
        private BackgroundWorker bgWorker;
        private static FormData _onFormData;
        private static RequestData _currentRequest;
        public AdacoAPIForm()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
            WinequestTabInit();  //? async task??
            Subscribe(true);
            //this.bgWorker = new BackgroundWorker();
            //this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            //this.PerformLayout();
        }

        private void Subscribe(bool action)
        {
            if (action)
            {
                EventDispatcher.Instance.FormMessage += MessageHandler;
            }
            else
            {
                if (EventDispatcher.Instance != null) EventDispatcher.Instance.FormMessage -= MessageHandler;
            }
        }

        private async void MessageHandler(object sender, EventDispatcher.FormArgs changes)
        {
            await Task.Run(() =>
            {
                winequestTab.Controls.Cast<Control>()
                .FirstOrDefault(c => string.Equals(c.Name, changes.Control))
                .Text = changes.Text;
            });
        }

        private async void responseTextBox_TextChanged(object sender, EventArgs e)
        {
            await Task.Run(() => XmlHighliter.HighlightRTF(responseTextBox));
        }

        private void methodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParamControls(Methods.RequestParams(methodBox.Text));

            //this.bgWorker.RunWorkerAsync();


            // put param fields

            // put time, 
            // ON PARAM CHANGED: gen uri, gen auth, put auth

            adacoTimeStampTextBox.Text = DateTime.Now.ToString();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            responseTextBox.Text = string.Empty;
            var thisMethod = Data.Methods.MethodStructByName(_onFormData.MethodName);  // to task
            Uri ready = PrepareUri().Result;
            List<string> auth = MainAuth.GetAuthKey(_currentRequest.Uri);

            _onFormData.AdacoHeaders["Adaco-Timestamp"] = auth[0];
            _onFormData.AdacoHeaders["Adaco-Authorization"] = auth[1];

            LoadFormData();

            _currentRequest = new DataStructs.RequestData()
            {
                Method = thisMethod.Type,
                Uri = ready,
                Headers = _onFormData.AdacoHeaders
            }; // NO MEDIA HERE
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            WinequestTabInit();
        }


        // TODO: bindings??
        private void WinequestTabInit()
        {
            SetParamControls();
            endpointTextBox.Text = "http://ie1adddb01.cloudapp.net/DevelopmentService/API/Product.svc";
            adacoDbInstanceTextBox.Text = "Production";
            adacoUserIdTextBox.Text = "winequest";
            adacoTimeStampTextBox.Text = string.Empty;
            adacoAuthorizationTextBox.Text = string.Empty;
            requestTextBox.Text = string.Empty;
            responseTextBox.Text = string.Empty;
            methodBox.Text = string.Empty;
        }

        // TODO: REWRITE USING HANDS
        private void SetParamControls(List<string> requestParameters = null)
        {
            foreach (
                var elem in
                winequestTab.Controls.Cast<Control>()
                    .Where(c => string.Equals(c.Tag, "requestParameter"))
                    .OrderBy(c => c.Name)
                    .ToList())
            {
                elem.Visible = false;
                elem.Text = string.Empty;
                if (!(requestParameters?.Count > 0)) continue;
                elem.Visible = Enabled;
                if (elem.Name.Contains("Label")) elem.Text = requestParameters[0];
                else requestParameters.RemoveAt(0);
            }
        }

        // TODO: REWRITE USING HANDS
        private void LoadFormData()
        {
            // headers
            var headerSubSet = winequestTab.Controls.Cast<Control>()
                .Where(c => string.Equals(c.Tag, "requestHeader"))
                .OrderBy(c => c.Name)
                .Select(c => c.Text);
            // parameters
            var paramSubSet = winequestTab.Controls.Cast<Control>()
                .Where(c => string.Equals(c.Tag, "requestParameter"))
                .Where(c => c.Visible)
                .OrderBy(c => c.Name)
                .Select(c => c.Text);

            _onFormData = new DataStructs.FormData
            {
                MethodName = methodBox.Text,
                Endpoint = endpointTextBox.Text,
                AdacoHeaders = headerSubSet.Where((part, index) => index % 2 == 0).Zip(headerSubSet.Where((part, index) => index % 2 != 0), (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v),
                Parameters = paramSubSet.Where((part, index) => index % 2 == 0).Zip(paramSubSet.Where((part, index) => index % 2 != 0), (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v),
                Request = requestTextBox.Text
            };

            Data.OnFormData = _onFormData;
        }


        private Task<Uri> PrepareUri()
        {
            var result = new TaskCompletionSource<Uri>();
            var resource = Data.Methods.ResourceByName(_onFormData.MethodName).Replace("{", string.Empty).Replace("}", string.Empty);
            Uri ready = new Uri(_onFormData.Endpoint + _onFormData.Parameters.Keys.Aggregate(resource, (current, inx) => current.Replace(inx, _onFormData.Parameters[inx])));
            result.SetResult(ready);
            return result.Task;
        }
        

        //private void bgWorker_RunWorkerCompleted(
        //    object sender,
        //    RunWorkerCompletedEventArgs e)
        //{
        //    foreach (var elem in winequestTab.Controls.Cast<Control>()
        //        .Where(c => string.Equals(c.Tag, "requestHeader"))
        //        .OrderBy(c => c.Name))
        //    {
        //        elem.Text = "ololo";
        //    }
        //    SetParamControls(Methods.RequestParams(methodBox.Text));
        //}
    }
}
