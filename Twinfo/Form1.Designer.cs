namespace Twinfo
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(234, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(550, 461);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Url = new System.Uri("http://civn.blog.jp/", System.UriKind.Absolute);
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 430);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "認証";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.Black;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.ForeColor = System.Drawing.Color.White;
			this.richTextBox1.Location = new System.Drawing.Point(12, 101);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(216, 292);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "情報を取得したいユーザーのID";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(29, 27);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(199, 19);
			this.textBox1.TabIndex = 4;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "@";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "情報コマンド";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "CreatedAt",
            "Description",
            "Favourites",
            "Follow",
            "Followers",
            "ID",
            "IsContributorsEnabled",
            "IsDefaultProfile",
            "IsDefaultProfileImage",
            "IsFollowRequestSent",
            "IsGeoEnabled",
            "IsMuting",
            "IsProfileBackgroundTile",
            "IsProfileUseBackgroundImage",
            "IsProtected",
            "IsShowAllInlineMedia",
            "IsSuspended",
            "IsTranslationEnabled",
            "IsTranslator",
            "IsVerified",
            "Language",
            "Listed",
            "Location",
            "Name",
            "NeedsPhoneVerification",
            "ProfileBackgroundColor",
            "ProfileBackgroundImageUrl",
            "ProfileBackgroundImageUrlHttps",
            "ProfileBannerUrl",
            "ProfileImageUrl",
            "ProfileImageUrlHttps",
            "ProfileLinkColor",
            "ProfileLocation",
            "ProfileSidebarBorderColor",
            "ProfileSidebarFillColor",
            "ProfileTextColor",
            "TimeZone",
            "Tweets",
            "URL",
            "UtcOffset",
            "WithheldInCountries",
            "WithheldScope"});
			this.comboBox1.Location = new System.Drawing.Point(12, 75);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(158, 20);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 9;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 75);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(52, 20);
			this.button2.TabIndex = 10;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(123, 430);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(105, 25);
			this.button3.TabIndex = 11;
			this.button3.Text = "設定を初期化";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 399);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(216, 25);
			this.button4.TabIndex = 12;
			this.button4.Text = "クリア";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.webBrowser1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 500);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "Form1";
			this.Text = "Twinfo";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

