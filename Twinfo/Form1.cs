using CoreTweet;
using CoreTweet.Core;
using CoreTweet.Rest;
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

		private String query;

		public Form1()
		{
			InitializeComponent();
		}

		public void Auth()
		{
			Properties.Settings.Default.Reload();

			String url = webBrowser1.Url.ToString();

			if (url.Contains("oauth_token") && url.Contains("oauth_verifier"))
			{
				if (url.Contains("civn.blog.jp"))
				{
					String oauth_token;
					String oauth_verifier;

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
					name = token.Users.Show(id).Name;
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
				int follow;

				try
				{
					follow = token.Users.Show(id).FriendsCount;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Follow: " + follow);
			}

			else if (item == "follower")
			{
				int follower;

				try
				{
					follower = token.Users.Show(id).FollowersCount;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Follower: " + follower);
			}

			else if (item == "description")
			{
				String description;

				try
				{
					description = token.Users.Show(id).Description;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Description: " + description);
			}

			else if (item == "id")
			{
				long id_number;

				try
				{
					id_number = token.Users.Show(id).Id.Value;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s ID: " + id_number);
			}

			else if (item == "timezone")
			{
				String timezone;

				try
				{
					timezone = token.Users.Show(id).TimeZone;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s TimeZone: " + timezone);
			}

			else if (item == "created")
			{
				String created;

				try
				{
					created = token.Users.Show(id).CreatedAt.ToUniversalTime().ToString();
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Created: " + created);
			}

			else if (item == "favorite")
			{
				int fav = 0;

				try
				{
					fav = token.Users.Show(id).FavouritesCount;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Favorite: " + fav);
			}

			else if (item == "tweet")
			{
				int tweet;

				try
				{
					tweet = token.Users.Show(id).StatusesCount;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Tweet: " + tweet);
			}

			else if (item == "language")
			{
				String language;

				try
				{
					language = token.Users.Show(id).Language;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Language: " + language);
			}

			else if (item == "listed")
			{
				int listed;

				try
				{
					listed = token.Users.Show(id).ListedCount.Value;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Listed: " + listed);
			}

			else if (item == "location")
			{
				String loc;

				try
				{
					loc = token.Users.Show(id).Location;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s Location: " + loc);
			}

			else if (item == "url")
			{
				String url;

				try
				{
					url = token.Users.Show(id).Url;
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				richTextBox1.AppendText("\n@" + id + "'s URL: " + url);
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

			Auth();
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
				System.Windows.Forms.Application.Restart();
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
