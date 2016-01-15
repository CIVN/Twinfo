using CoreTweet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoreTweet.OAuth;

namespace Twinfo
{
	public partial class Form1 : Form
	{
		public const String ConsumerKey = "TR9KNUJTuannhiLx4KZLoMMTC";
		public const String ConsumerSecret = "PX5lTa6h3coG6PmGpVqVo33VnKaOUkfyjP1ugUu8hvWrSGKzfe";
		public const String CallbackURL = "http://civn.blog.jp/callback/";

		public Tokens token;
		public OAuthSession session = Authorize(ConsumerKey, ConsumerSecret, CallbackURL);

		private String AccessToken = Properties.Settings.Default.AccessToken;
		private String AccessTokenSecret = Properties.Settings.Default.AccessTokenSecret;

		private String ScreenName = Properties.Settings.Default.ScreenName;
		private long UserID = Properties.Settings.Default.UserID;

		private Uri hp = new Uri("http://civn.blog.jp/");
		private Uri url;

		public Form1()
		{
			InitializeComponent();
		}

		public void OK()
		{
			String id;
			String item = comboBox1.SelectedText;

			if (token == null)
			{
				MessageBox.Show("アカウントの認証が必要です！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (textBox1.Text == "")
			{
				id = token.ScreenName;
			}

			else
			{
				id = textBox1.Text;
			}

			try
			{
				item = comboBox1.SelectedItem.ToString();
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (item == "name")
			{
				String name;

				try
				{
					name = token.Statuses.UserTimeline(id)[0].User.Name;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Name: " + name);
			}

			else if (item == "follow")
			{
				IEnumerable<long> follow;

				try
				{
					follow = token.Friends.EnumerateIds(EnumerateMode.Next, id);
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Follow: " + follow.ToArray().Length);
			}

			else if (item == "follower")
			{
				IEnumerable<long> follower;

				try
				{
					follower = token.Followers.EnumerateIds(EnumerateMode.Next, id);
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Follower: " + follower.ToArray().Length);
			}

			else if (item == "description")
			{
				String description;

				try
				{
					description = token.Statuses.UserTimeline(id)[0].User.Description;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Description: " + description);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();

			if (AccessToken != "" && AccessTokenSecret != "")
			{
				Tokens t = Tokens.Create(ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret, UserID, ScreenName);

				token = t;

				richTextBox1.AppendText("\nアカウントの認証に成功しました！");
			}

			else
			{
				richTextBox1.AppendText("\nアカウントの認証をする必要があります！");
			}

			comboBox1.SelectedIndex = 0;
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			Properties.Settings.Default.Reload();

			String url = webBrowser1.Url.ToString();

			if (url.Contains("oauth_token") && url.Contains("oauth_verifier"))
			{
				if (url.Contains("civn.blog.jp"))
				{
					String query;
					String oauth_token;
					String oauth_verifier;

					//URLからクエリを取得
					try
					{
						query = e.Url.Query;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					//クエリからoauth_tokenを抽出
					try
					{
						oauth_token = query.Substring(13, 27);
					}

					catch
					{
						return;
					}

					//クエリからoauth_verifierを抽出
					try
					{
						oauth_verifier = query.Substring(56);
					}

					catch
					{
						return;
					}

					webBrowser1.Url = hp;

					//トークンを作成
					try
					{
						token = session.GetTokens(oauth_verifier);
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Properties.Settings.Default.AccessToken = token.AccessToken;
					Properties.Settings.Default.AccessTokenSecret = token.AccessTokenSecret;
					Properties.Settings.Default.ScreenName = token.ScreenName;
					Properties.Settings.Default.UserID = token.UserId;
					Properties.Settings.Default.Save();

					richTextBox1.AppendText("\nアカウントの認証に成功しました！");
					richTextBox1.AppendText("\nName: " + token.Statuses.UserTimeline(token.ScreenName)[0].User.Name);
					richTextBox1.AppendText("\nID: @" + token.ScreenName);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (token != null)
			{
				DialogResult m1 = MessageBox.Show("認証はアカウントを変更するなどの際のみ必要です。\nアカウントを再認証しますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (m1 != DialogResult.Yes)
				{
					return;
				}
			}

			url = session.AuthorizeUri;

			try
			{
				webBrowser1.Url = url;
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OK();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DialogResult m1 = MessageBox.Show("全ての設定を初期化して再起動します。\nよろしいですか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (m1 == DialogResult.Yes)
			{
				Properties.Settings.Default.Reload();
				Properties.Settings.Default.Reset();
				Application.Restart();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OK();
			}
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Uri url = new Uri(e.LinkText);

			webBrowser1.Url = url;
		}
	}
}
