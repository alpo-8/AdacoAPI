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
        private static FormData _onFormData;
        private static RequestData _currentRequest;
        public AdacoAPIForm()
        {
            InitializeComponent();
             //? async task??
            _onFormData = new FormData();
            Subscribe(true);
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
                var target = this.winequestTab.Controls.Cast<Control>()
                    .FirstOrDefault(c => string.Equals(c.Name, changes.Control));
                if (target != null)
                    target
                        .Text = changes.Text;
            });
        }

        private async void responseTextBox_TextChanged(object sender, EventArgs e)
        {
            await Task.Run(() => XmlHighliter.HighlightRTF(responseTextBox));
        }

        private async void methodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.requestButton.Enabled = true;
            string methodName = methodBox.Text;

            var controls = winequestTab.Controls.Cast<Control>()
                .Where(c => string.Equals(c.Tag, "requestParameter"))
                .OrderBy(c => c.Name)
                .ToList();
            controls.All(x => { x.Visible = false; x.Text = String.Empty;
                                  return true;
            });
            await Task.Run(() => SetParamControls(methodName, controls));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _onFormData = new FormData();
            InitializeComponent();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            responseTextBox.Text = string.Empty;
            var thisMethod = Data.Methods.MethodStructByName(_onFormData.MethodName);  // to task
            Uri ready = PrepareUri().Result;
            List<string> auth = MainAuth.GetAuthKey(_currentRequest.Uri);

            _onFormData.AdacoHeaders["Adaco-Timestamp"] = auth[0];
            _onFormData.AdacoHeaders["Adaco-Authorization"] = auth[1];

            _currentRequest = new DataStructs.RequestData()
            {
                Method = thisMethod.Type,
                Uri = ready,
                Headers = _onFormData.AdacoHeaders
            }; // NO MEDIA HERE
        }

        //private void WinequestTabInit()
        //{
        //    SetParamControls();
        //    endpointTextBox.Text = "http://ie1adddb01.cloudapp.net/DevelopmentService/API/Product.svc";
        //    adacoDbInstanceTextBox.Text = "Production";
        //    adacoUserIdTextBox.Text = "winequest";
        //    adacoTimeStampTextBox.Text = string.Empty;
        //    adacoAuthorizationTextBox.Text = string.Empty;
        //    requestTextBox.Text = string.Empty;
        //    responseTextBox.Text = string.Empty;
        //    methodBox.Text = string.Empty;
        //}

        private Task<bool> SetParamControls(string methodname, List<Control> controls)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var parameters = Methods.RequestParams(methodname);
                foreach (var elem in controls.Where(elem => parameters?.Count > 0))
                {
                    elem.Visible = Enabled;
                    if (elem.Name.Contains("Label")) elem.Text = parameters[0];
                    else parameters.RemoveAt(0);
                }
                tcs.SetResult(true);
                return tcs.Task;
            }
            catch
            {
                tcs.SetResult(false);
                return tcs.Task;
            }
        }

        private static Task<Uri> PrepareUri()
        {
            var result = new TaskCompletionSource<Uri>();
            var resource = Data.Methods.ResourceByName(_onFormData.MethodName).Replace("{", string.Empty).Replace("}", string.Empty);
            Uri ready = new Uri(_onFormData.Endpoint + _onFormData.Parameters.Keys.Aggregate(resource, (current, inx) => current.Replace(inx, _onFormData.Parameters[inx])));
            result.SetResult(ready);
            return result.Task;
        }

        private void LoadData()
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
                MethodName = methodBox?.Text,
                Endpoint = endpointTextBox?.Text,
                AdacoHeaders = headerSubSet?.Where((part, index) => index % 2 == 0).Zip(headerSubSet.Where((part, index) => index % 2 != 0), (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v),
                Parameters = paramSubSet?.Where((part, index) => index % 2 == 0).Zip(paramSubSet.Where((part, index) => index % 2 != 0), (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v),
                Request = requestTextBox?.Text
            };
        }


                //MessageBox.Show("Failed to collect data from the form",
                //    "What a pity",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);

    }
}
