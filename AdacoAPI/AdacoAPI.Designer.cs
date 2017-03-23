namespace AdacoAPI
{
    partial class AdacoAPIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.winequestTab = new System.Windows.Forms.TabPage();
            this.resetButton = new System.Windows.Forms.Button();
            this.adacoAuthorizationTextBox = new System.Windows.Forms.TextBox();
            this.adacoAuthorizationLabel = new System.Windows.Forms.Label();
            this.adacoTimeStampLabel = new System.Windows.Forms.Label();
            this.adacoTimeStampTextBox = new System.Windows.Forms.TextBox();
            this.requestButton = new System.Windows.Forms.Button();
            this.responseTextBox = new System.Windows.Forms.RichTextBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.requestTextBox = new System.Windows.Forms.RichTextBox();
            this.requestLabel = new System.Windows.Forms.Label();
            this.adacoUserIdTextBox = new System.Windows.Forms.TextBox();
            this.adacoUserIdLabel = new System.Windows.Forms.Label();
            this.adacoDbInstanceLabel = new System.Windows.Forms.Label();
            this.adacoDbInstanceTextBox = new System.Windows.Forms.TextBox();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.endpointLabel = new System.Windows.Forms.Label();
            this.param3Label = new System.Windows.Forms.Label();
            this.param3TextBox = new System.Windows.Forms.TextBox();
            this.param2TextBox = new System.Windows.Forms.TextBox();
            this.param2Label = new System.Windows.Forms.Label();
            this.param1TextBox = new System.Windows.Forms.TextBox();
            this.param1Label = new System.Windows.Forms.Label();
            this.methodLabel = new System.Windows.Forms.Label();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.winequestTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.winequestTab);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1184, 561);
            this.tabControl.TabIndex = 0;
            // 
            // winequestTab
            // 
            this.winequestTab.Controls.Add(this.resetButton);
            this.winequestTab.Controls.Add(this.adacoAuthorizationTextBox);
            this.winequestTab.Controls.Add(this.adacoAuthorizationLabel);
            this.winequestTab.Controls.Add(this.adacoTimeStampLabel);
            this.winequestTab.Controls.Add(this.adacoTimeStampTextBox);
            this.winequestTab.Controls.Add(this.requestButton);
            this.winequestTab.Controls.Add(this.responseTextBox);
            this.winequestTab.Controls.Add(this.responseLabel);
            this.winequestTab.Controls.Add(this.requestTextBox);
            this.winequestTab.Controls.Add(this.requestLabel);
            this.winequestTab.Controls.Add(this.adacoUserIdTextBox);
            this.winequestTab.Controls.Add(this.adacoUserIdLabel);
            this.winequestTab.Controls.Add(this.adacoDbInstanceLabel);
            this.winequestTab.Controls.Add(this.adacoDbInstanceTextBox);
            this.winequestTab.Controls.Add(this.endpointTextBox);
            this.winequestTab.Controls.Add(this.endpointLabel);
            this.winequestTab.Controls.Add(this.param3Label);
            this.winequestTab.Controls.Add(this.param3TextBox);
            this.winequestTab.Controls.Add(this.param2TextBox);
            this.winequestTab.Controls.Add(this.param2Label);
            this.winequestTab.Controls.Add(this.param1TextBox);
            this.winequestTab.Controls.Add(this.param1Label);
            this.winequestTab.Controls.Add(this.methodLabel);
            this.winequestTab.Controls.Add(this.methodBox);
            this.winequestTab.Location = new System.Drawing.Point(4, 22);
            this.winequestTab.Name = "winequestTab";
            this.winequestTab.Padding = new System.Windows.Forms.Padding(3);
            this.winequestTab.Size = new System.Drawing.Size(1176, 535);
            this.winequestTab.TabIndex = 0;
            this.winequestTab.Text = "winequest";
            this.winequestTab.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(791, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 23);
            this.resetButton.TabIndex = 24;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // adacoAuthorizationTextBox
            // 
            this.adacoAuthorizationTextBox.Location = new System.Drawing.Point(791, 59);
            this.adacoAuthorizationTextBox.Name = "adacoAuthorizationTextBox";
            this.adacoAuthorizationTextBox.ReadOnly = true;
            this.adacoAuthorizationTextBox.Size = new System.Drawing.Size(200, 20);
            this.adacoAuthorizationTextBox.TabIndex = 23;
            this.adacoAuthorizationTextBox.Tag = "requestHeader";
            // 
            // adacoAuthorizationLabel
            // 
            this.adacoAuthorizationLabel.AutoSize = true;
            this.adacoAuthorizationLabel.Location = new System.Drawing.Point(680, 62);
            this.adacoAuthorizationLabel.Name = "adacoAuthorizationLabel";
            this.adacoAuthorizationLabel.Size = new System.Drawing.Size(102, 13);
            this.adacoAuthorizationLabel.TabIndex = 22;
            this.adacoAuthorizationLabel.Tag = "requestHeader";
            this.adacoAuthorizationLabel.Text = "Adaco-Authorization";
            // 
            // adacoTimeStampLabel
            // 
            this.adacoTimeStampLabel.AutoSize = true;
            this.adacoTimeStampLabel.Location = new System.Drawing.Point(690, 36);
            this.adacoTimeStampLabel.Name = "adacoTimeStampLabel";
            this.adacoTimeStampLabel.Size = new System.Drawing.Size(92, 13);
            this.adacoTimeStampLabel.TabIndex = 21;
            this.adacoTimeStampLabel.Tag = "requestHeader";
            this.adacoTimeStampLabel.Text = "Adaco-Timestamp";
            // 
            // adacoTimeStampTextBox
            // 
            this.adacoTimeStampTextBox.Location = new System.Drawing.Point(791, 33);
            this.adacoTimeStampTextBox.Name = "adacoTimeStampTextBox";
            this.adacoTimeStampTextBox.ReadOnly = true;
            this.adacoTimeStampTextBox.Size = new System.Drawing.Size(200, 20);
            this.adacoTimeStampTextBox.TabIndex = 20;
            this.adacoTimeStampTextBox.Tag = "requestHeader";
            // 
            // requestButton
            // 
            this.requestButton.Location = new System.Drawing.Point(385, 88);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(100, 25);
            this.requestButton.TabIndex = 19;
            this.requestButton.Text = "Send Request";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(585, 130);
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.Size = new System.Drawing.Size(370, 400);
            this.responseTextBox.TabIndex = 18;
            this.responseTextBox.Text = "";
            this.responseTextBox.WordWrap = false;
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(582, 114);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(55, 13);
            this.responseLabel.TabIndex = 17;
            this.responseLabel.Text = "Response";
            // 
            // requestTextBox
            // 
            this.requestTextBox.Location = new System.Drawing.Point(8, 130);
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.Size = new System.Drawing.Size(370, 400);
            this.requestTextBox.TabIndex = 16;
            this.requestTextBox.Text = "";
            // 
            // requestLabel
            // 
            this.requestLabel.AutoSize = true;
            this.requestLabel.Location = new System.Drawing.Point(10, 114);
            this.requestLabel.Name = "requestLabel";
            this.requestLabel.Size = new System.Drawing.Size(73, 13);
            this.requestLabel.TabIndex = 15;
            this.requestLabel.Text = "Request body";
            // 
            // adacoUserIdTextBox
            // 
            this.adacoUserIdTextBox.Location = new System.Drawing.Point(385, 59);
            this.adacoUserIdTextBox.Name = "adacoUserIdTextBox";
            this.adacoUserIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.adacoUserIdTextBox.TabIndex = 13;
            this.adacoUserIdTextBox.Tag = "requestHeader";
            this.adacoUserIdTextBox.Text = "winequest";
            // 
            // adacoUserIdLabel
            // 
            this.adacoUserIdLabel.AutoSize = true;
            this.adacoUserIdLabel.Location = new System.Drawing.Point(305, 62);
            this.adacoUserIdLabel.Name = "adacoUserIdLabel";
            this.adacoUserIdLabel.Size = new System.Drawing.Size(71, 13);
            this.adacoUserIdLabel.TabIndex = 12;
            this.adacoUserIdLabel.Tag = "requestHeader";
            this.adacoUserIdLabel.Text = "Adaco-Userid";
            // 
            // adacoDbInstanceLabel
            // 
            this.adacoDbInstanceLabel.AutoSize = true;
            this.adacoDbInstanceLabel.Location = new System.Drawing.Point(279, 36);
            this.adacoDbInstanceLabel.Name = "adacoDbInstanceLabel";
            this.adacoDbInstanceLabel.Size = new System.Drawing.Size(97, 13);
            this.adacoDbInstanceLabel.TabIndex = 11;
            this.adacoDbInstanceLabel.Tag = "requestHeader";
            this.adacoDbInstanceLabel.Text = "Adaco-DBInstance";
            // 
            // adacoDbInstanceTextBox
            // 
            this.adacoDbInstanceTextBox.Location = new System.Drawing.Point(385, 33);
            this.adacoDbInstanceTextBox.Name = "adacoDbInstanceTextBox";
            this.adacoDbInstanceTextBox.Size = new System.Drawing.Size(200, 20);
            this.adacoDbInstanceTextBox.TabIndex = 10;
            this.adacoDbInstanceTextBox.Tag = "requestHeader";
            this.adacoDbInstanceTextBox.Text = "Production";
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Location = new System.Drawing.Point(385, 6);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(400, 20);
            this.endpointTextBox.TabIndex = 9;
            this.endpointTextBox.Text = "http://ie1adddb01.cloudapp.net/DevelopmentService/Product.svc";
            // 
            // endpointLabel
            // 
            this.endpointLabel.AutoSize = true;
            this.endpointLabel.Location = new System.Drawing.Point(327, 10);
            this.endpointLabel.Name = "endpointLabel";
            this.endpointLabel.Size = new System.Drawing.Size(52, 13);
            this.endpointLabel.TabIndex = 8;
            this.endpointLabel.Text = "Endpoint:";
            // 
            // param3Label
            // 
            this.param3Label.AutoSize = true;
            this.param3Label.Location = new System.Drawing.Point(10, 88);
            this.param3Label.Name = "param3Label";
            this.param3Label.Size = new System.Drawing.Size(35, 13);
            this.param3Label.TabIndex = 7;
            this.param3Label.Tag = "requestParameter";
            this.param3Label.Text = "label3";
            // 
            // param3TextBox
            // 
            this.param3TextBox.Location = new System.Drawing.Point(159, 85);
            this.param3TextBox.Name = "param3TextBox";
            this.param3TextBox.Size = new System.Drawing.Size(100, 20);
            this.param3TextBox.TabIndex = 6;
            this.param3TextBox.Tag = "requestParameter";
            // 
            // param2TextBox
            // 
            this.param2TextBox.Location = new System.Drawing.Point(159, 59);
            this.param2TextBox.Name = "param2TextBox";
            this.param2TextBox.Size = new System.Drawing.Size(100, 20);
            this.param2TextBox.TabIndex = 5;
            this.param2TextBox.Tag = "requestParameter";
            // 
            // param2Label
            // 
            this.param2Label.AutoSize = true;
            this.param2Label.Location = new System.Drawing.Point(10, 62);
            this.param2Label.Name = "param2Label";
            this.param2Label.Size = new System.Drawing.Size(35, 13);
            this.param2Label.TabIndex = 4;
            this.param2Label.Tag = "requestParameter";
            this.param2Label.Text = "label2";
            // 
            // param1TextBox
            // 
            this.param1TextBox.Location = new System.Drawing.Point(159, 33);
            this.param1TextBox.Name = "param1TextBox";
            this.param1TextBox.Size = new System.Drawing.Size(100, 20);
            this.param1TextBox.TabIndex = 3;
            this.param1TextBox.Tag = "requestParameter";
            // 
            // param1Label
            // 
            this.param1Label.AutoSize = true;
            this.param1Label.Location = new System.Drawing.Point(10, 36);
            this.param1Label.Name = "param1Label";
            this.param1Label.Size = new System.Drawing.Size(35, 13);
            this.param1Label.TabIndex = 2;
            this.param1Label.Tag = "requestParameter";
            this.param1Label.Text = "label1";
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(10, 10);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(46, 13);
            this.methodLabel.TabIndex = 1;
            this.methodLabel.Text = "Method:";
            // 
            // methodBox
            // 
            this.methodBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.methodBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Items.AddRange(new object[] {
            "GetCategories",
            "GetProperties",
            "GetPropertyNumberById",
            "GetAllProducts",
            "GetPropertyProducts",
            "GetProductByNumber",
            "GetProductById",
            "GetProductByNumberAndDetail",
            "GetProduct",
            "CreateProduct",
            "UpdatePropertyProduct",
            "UpdateRootProduct",
            "MergeProductDetails",
            "MergeProducts",
            "ResetDataBase",
            "UpdateCoreList",
            "GetCoreList"});
            this.methodBox.Location = new System.Drawing.Point(59, 6);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(200, 21);
            this.methodBox.TabIndex = 0;
            this.methodBox.SelectedIndexChanged += new System.EventHandler(this.methodBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1176, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AdacoAPIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.tabControl);
            this.Name = "AdacoAPIForm";
            this.Text = "AdacoAPI";
            this.tabControl.ResumeLayout(false);
            this.winequestTab.ResumeLayout(false);
            this.winequestTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabPage winequestTab;
        private System.Windows.Forms.Label param1Label;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label param2Label;
        private System.Windows.Forms.Label param3Label;
        private System.Windows.Forms.TextBox param3TextBox;
        private System.Windows.Forms.TextBox param2TextBox;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.Label endpointLabel;
        private System.Windows.Forms.TextBox adacoAuthorizationTextBox;
        private System.Windows.Forms.Label adacoAuthorizationLabel;
        private System.Windows.Forms.Label adacoTimeStampLabel;
        private System.Windows.Forms.TextBox adacoTimeStampTextBox;
        private System.Windows.Forms.RichTextBox responseTextBox;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.Label requestLabel;
        private System.Windows.Forms.TextBox adacoUserIdTextBox;
        private System.Windows.Forms.Label adacoUserIdLabel;
        private System.Windows.Forms.Label adacoDbInstanceLabel;
        private System.Windows.Forms.TextBox adacoDbInstanceTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox param1TextBox;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.RichTextBox requestTextBox;
    }
}

