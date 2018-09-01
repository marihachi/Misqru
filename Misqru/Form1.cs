using Misqru.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Misqru
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		private Setting setting;

		private List<MisskeyInstance> instances => this.setting.Instances;

		private List<MisskeyAccount> accounts => this.setting.Accounts;

		private MisskeyAccount selectedAccount
		{
			get {
				if (this.toolStripComboBox1.SelectedIndex == -1)
					return null;

				return this.accounts[this.toolStripComboBox1.SelectedIndex];
			}
		}

		private List<User> followingUsers = new List<User>();

		private string nextCursor;

		private async void Form1_Load(object sender, EventArgs e)
		{
			this.setting = await Setting.LoadAsync();

			// 設定ファイルのバージョンを判定
			if (this.setting._Version != Meta.SettingLatestVersion)
			{
				if(this.setting._Version == 1)
				{
					// "setting file is old format. please remove setting.json and re-execute Misqru."
					MessageBox.Show("古い形式の設定ファイルです。\r\nsetting.jsonを削除してMisqruを再実行してください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
					return;
				}
				else
				{
					throw new NotSupportedException("setting file is unknown version");
				}
			}

			// 構成
			foreach (var account in this.accounts)
			{
				this.toolStripComboBox1.Items.Add($"{account.Username}@{account.Host}");
			}

			// 「さらに取得」ボタンの有効状態
			this.toolStripButton2.Enabled = false;

			updateDisplayedProfile(null);

			this.listView1.Focus();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			var f = new SettingForm(this.setting);
			f.ShowDialog();

			// 設定画面上でアカウント一覧に対して変更があった場合
			if (f.NeedUpdateAccountsList)
			{
				// 再構成
				this.toolStripComboBox1.Items.Clear();
				foreach (var account in this.accounts)
				{
					this.toolStripComboBox1.Items.Add($"{account.Username}@{account.Host}");
				}
			}
		}

		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			if (this.selectedAccount == null) return;

			// 「さらに取得」ボタンを無効化
			this.toolStripButton2.Enabled = false;

			dynamic res;
			try
			{
				var param = new Dictionary<string, object>
				{
					["userId"] = this.selectedAccount.Id,
					["limit"] = 100
				};
				if (this.nextCursor != null)
				{
					param.Add("cursor", this.nextCursor);
				}
				res = await this.selectedAccount.Request("users/following", param);
			}
			catch
			{
				MessageBox.Show("データの取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			this.nextCursor = res.next.Value;

			// 「さらに取得」ボタンを必要に応じて有効化
			this.toolStripButton2.Enabled = (this.nextCursor != null);

			foreach (JObject t in res.users)
			{
				var user = User.FromJObject(t);

				this.followingUsers.Add(user);

				var usernameWithHost = user.Username;
				if (user.Host != null)
				{
					usernameWithHost += $"@{user.Host}";
				}

				var listItem = new ListViewItem(new[] { user.Name, usernameWithHost });
				listItem.Tag = user;
				this.listView1.Items.Add(listItem);
			}
		}

		private async void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 「さらに取得」ボタンを無効化
			this.toolStripButton2.Enabled = false;

			if (this.selectedAccount == null) return;

			// フォロー一覧を取得
			var param = new Dictionary<string, object>
			{
				["userId"] = this.selectedAccount.Id,
				["limit"] = 100
			};
			var res = await this.selectedAccount.Request("users/following", param);

			this.nextCursor = res.next.Value;

			// 「さらに取得」ボタンを必要に応じて有効化
			this.toolStripButton2.Enabled = (this.nextCursor != null);

			this.followingUsers.Clear();
			this.listView1.Items.Clear();

			foreach (JObject t in res.users)
			{
				var user = User.FromJObject(t);

				this.followingUsers.Add(user);

				var usernameWithHost = user.Username;
				if (user.Host != null)
				{
					usernameWithHost += $"@{user.Host}";
				}

				var listItem = new ListViewItem(new[] { user.Name, usernameWithHost });
				listItem.Tag = user;
				this.listView1.Items.Add(listItem);
			}
		}

		private void updateDisplayedProfile(User user) {
			var isUserSelected = (user != null);

			this.button1.Enabled = isUserSelected;
			this.linkLabel1.Enabled = isUserSelected;
			this.textBox1.Enabled = isUserSelected;

			if (isUserSelected)
			{
				var usernameWithHost = user.Username;
				if (user.Host != null)
				{
					usernameWithHost += $"@{user.Host}";
				}

				this.label1.Text = $"{user.Name} @{usernameWithHost}";
				this.textBox1.Text = user.Description;

				if (user.HasPendingFollowRequestFromYou)
				{
					this.button1.Text = "承認待ち";
				}
				else if (user.IsFollowing)
				{
					this.button1.Text = "フォロー中";
				}
				else
				{
					this.button1.Text = "フォロー";
				}

				//this.button1.ForeColor = user.IsFollowing ? Color.LightSeaGreen : SystemColors.Control;
			}
			else
			{
				this.label1.Text = "";
				this.textBox1.Text = "";
				this.button1.Text = "フォロー";
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			User user = null;

			if (this.listView1.SelectedItems.Count != 0)
			{
				var listItem = this.listView1.SelectedItems[0];
				user = (User)listItem.Tag;
			}

			// 画面を更新
			updateDisplayedProfile(user);
		}

        private async void button1_Click(object sender, EventArgs e)
        {
			if (this.selectedAccount == null) return;

			var listItem = this.listView1.SelectedItems[0];
			var user = (User)listItem.Tag;

			string endpoint;
			if (user.HasPendingFollowRequestFromYou)
			{
				endpoint = "following/requests/cancel";
			}
			else
			{
				if (!user.IsFollowing)
					endpoint = "following/create";
				else
					endpoint = "following/delete";
			}

			try
			{
				var obj = (JObject)await this.selectedAccount.Request(endpoint, new Dictionary<string, object> { ["userId"] = user.Id });
				var updated = User.FromJObject(obj);

				// 保持されているユーザデータを更新
				var userIndex = this.followingUsers.IndexOf(user);
				listItem.Tag = updated;
				this.followingUsers[userIndex] = updated;
				user = updated;
			}
			catch
			{
				MessageBox.Show("リクエストに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// 画面を更新
			updateDisplayedProfile(user);
        }

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var listItem = this.listView1.SelectedItems[0];
			var user = (User)listItem.Tag;

			var usernameWithHost = user.Username;
			if (user.Host != null)
			{
				usernameWithHost += $"@{user.Host}";
			}

			Process.Start($"https://{this.selectedAccount.Host}/@{usernameWithHost}");
		}
	}
}
