﻿using CoreTweet;
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
		private const string ConsumerKey = "k4QkjYXYXNu2I9zbP3PkNUNgl";
		private const string ConsumerSecret = "";
		private const string CallbackURL = "http://civn.blog.jp/callback/";

		private Tokens token;
		private OAuthSession session = Authorize(ConsumerKey, ConsumerSecret, CallbackURL);

		private string AccessToken = Properties.Settings.Default.AccessToken;
		private string AccessTokenSecret = Properties.Settings.Default.AccessTokenSecret;

		private string ScreenName = Properties.Settings.Default.ScreenName;
		private long UserID = Properties.Settings.Default.UserID;

		private Uri hp = new Uri("http://civn.blog.jp/");
		private Uri url;

		private string query;

		private string id;
		private string item;
		private string result;

		public Form1()
		{
			InitializeComponent();
		}

		public void Result()
		{
			if (item == "BackgroundColor")
			{
				result = "#" + result;

				Color color = ColorTranslator.FromHtml(result);

				//反転色作成
				int R = 255 - color.R;
				int G = 255 - color.G;
				int B = 255 - color.B;
				int A = 255 - color.A;

				Color xcolor = Color.FromArgb(A, R, G, B);

				richTextBox1.BackColor = color;
				richTextBox1.ForeColor = xcolor;
			}

			richTextBox1.AppendText("\n\n@" + id + "'s " + item + ":\n" + result);
		}

		//認証
		private void Auth()
		{
			Properties.Settings.Default.Reload();

			var url = webBrowser1.Url.ToString();

			/*TODO: ここガバガバ*/
			if (url.Contains("oauth_token") && url.Contains("oauth_verifier"))
			{
				if (url.Contains("civn.blog.jp/callback/"))
				{
					string oauth_token;
					string oauth_verifier;

					//クエリから色々抽出
					try
					{
						oauth_token = query.Substring(13, 27);
					}

					catch
					{
						return;
					}

					try
					{
						oauth_verifier = query.Substring(56);
					}

					catch
					{
						return;
					}

					webBrowser1.Url = hp;

					//トークン作成
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
					richTextBox1.AppendText("\nID: @" + token.ScreenName);

					token.Statuses.Update("#UsingTwinfo");
				}
			}
		}

		//処理開始
		private void OK()
		{
			item = comboBox1.SelectedItem.ToString();

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

			switch (item)
			{
				case "Name":

					try
					{
						result = token.Users.Show(id).Name;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Follow":

					try
					{
						result = token.Users.Show(id).FriendsCount.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Follower":

					try
					{
						result = token.Users.Show(id).FollowersCount.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Description":

					try
					{
						result = token.Users.Show(id).Description;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "ID":

					try
					{
						result = token.Users.Show(id).Id.Value.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "TimeZone":

					try
					{
						result = token.Users.Show(id).TimeZone;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Created":

					try
					{
						result = token.Users.Show(id).CreatedAt.ToUniversalTime().ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Favorite":

					try
					{
						result = token.Users.Show(id).FavouritesCount.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Tweet":

					try
					{
						result = token.Users.Show(id).StatusesCount.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Language":

					try
					{
						result = token.Users.Show(id).Language;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Listed":

					try
					{
						result = token.Users.Show(id).ListedCount.Value.ToString();
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "Location":

					try
					{
						result = token.Users.Show(id).Location;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "URL":

					try
					{
						result = token.Users.Show(id).Url;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "BackgroundColor":

					try
					{
						result = token.Users.Show(id).ProfileBackgroundColor;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "BackgroundImageUrl":

					try
					{
						result = token.Users.Show(id).ProfileBackgroundImageUrl;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "BackgroundImageUrlHttps":

					try
					{
						result = token.Users.Show(id).ProfileBackgroundImageUrlHttps;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "BannerUrl":

					try
					{
						result = token.Users.Show(id).ProfileBannerUrl;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "ImageUrl":

					try
					{
						result = token.Users.Show(id).ProfileImageUrl;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;

				case "ImageUrlHttps":

					try
					{
						result = token.Users.Show(id).ProfileImageUrlHttps;
					}

					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					break;
			}

			Result();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();

			if (AccessToken != "" && AccessTokenSecret != "")
			{
				if (UserID != 0 && ScreenName != "")
				{
					token = Tokens.Create(ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret, UserID, ScreenName);

					richTextBox1.AppendText("\nアカウントの認証に成功しました！");
				}
			}

			else
			{
				richTextBox1.AppendText("\nアカウントの認証をする必要があります！");
			}

			comboBox1.SelectedIndex = 0;
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			//URLからクエリ取得
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

		//認証ボタン
		private void button1_Click(object sender, EventArgs e)
		{
			if (token != null)
			{
				var m1 = MessageBox.Show("再認証はアカウントを変更するなどの際のみ必要です。\nアカウントを再認証しますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

		//OKボタン
		private void button2_Click(object sender, EventArgs e)
		{
			OK();
		}

		//初期化ボタン
		private void button3_Click(object sender, EventArgs e)
		{
			var m1 = MessageBox.Show("全ての設定を初期化して再起動します。\nよろしいですか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (m1 == DialogResult.Yes)
			{
				Properties.Settings.Default.Reload();
				Properties.Settings.Default.Reset();

				System.Windows.Forms.Application.Restart();
			}
		}

		//クリアボタン
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
			var url = new Uri(e.LinkText);

			webBrowser1.Url = url;
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			richTextBox1.SelectionStart = richTextBox1.Text.Length;
			richTextBox1.Focus();
			richTextBox1.ScrollToCaret();
		}
	}
}
