using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static AdacoAPI.Data;
using static AdacoAPI.DataStructs;
using System.Xml.Linq;
using ColorCode;

namespace AdacoAPI
{
    public partial class AdacoAPIForm : Form
    {
        private static FormData _onFormData;
        public AdacoAPIForm()
        {
            InitializeComponent();
            WinequestTabInit();
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

        private void MessageHandler(object sender, EventDispatcher.MessageArgs contains)
        {
            PutResponse(new CodeColorizer().Colorize(contains.Message, Languages.Xml));
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            LoadFormData();
            responseTextBox.Text = string.Empty;
            new DataValidator();
            EventDispatcher.Instance.RaiseDataMessage(true, "startValidation");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            WinequestTabInit();
        }

        private void methodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParamControls(Methods.RequestParams(methodBox.Text));
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
                AdacoHeaders = headerSubSet.Where((part, index) => index % 2 == 0).Zip(headerSubSet.Where((part, index) => index % 2 != 0), (k,v) => new {k,v}).ToDictionary(x => x.k, x => x.v),
                Parameters = paramSubSet.Where((part, index) => index % 2 == 0).Zip(paramSubSet.Where((part, index) => index % 2 != 0), (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v),
                Request = requestTextBox.Text
            };

            Data.OnFormData = _onFormData;
        }

        private void PutResponse(string tuc)
        {
            responseTextBox.Text += tuc + "\n";
        }
    }
}
