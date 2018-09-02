using Misqru.Models;
using Misqru.Schemas;
using Newtonsoft.Json;
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

		private ApiManager api { get; } = new ApiManager();

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
				this.toolStripComboBox1.Items.Add($"{account.Username}@{account.Host}");

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
					this.toolStripComboBox1.Items.Add($"{account.Username}@{account.Host}");
			}
		}

		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			// 「さらに取得」ボタンを無効化
			this.toolStripButton2.Enabled = false;

			UserSequence followings;
			try
			{
				followings = await this.api.GetFollowings(cursor: this.nextCursor);
			}
			catch
			{
				MessageBox.Show("データの取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			this.nextCursor = followings.NextCursor;

			// 「さらに取得」ボタンを必要に応じて有効化
			this.toolStripButton2.Enabled = (this.nextCursor != null);

			foreach (var user in followings.Users)
			{
				this.followingUsers.Add(user);

				var usernameWithHost = user.Username;

				if (user.Host != null)
					usernameWithHost += $"@{user.Host}";

				var listItem = new ListViewItem(new[] { user.Name, usernameWithHost });
				listItem.Tag = user;
				this.listView1.Items.Add(listItem);
			}
		}

		private async void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 「さらに取得」ボタンを無効化
			this.toolStripButton2.Enabled = false;

			if (this.selectedAccount == null)
				return;

			// APIのアカウントを変更
			this.api.Account = this.selectedAccount;

			// フォロー一覧を取得
			var followings = await this.api.GetFollowings();
			
			this.nextCursor = followings.NextCursor;

			// 「さらに取得」ボタンを必要に応じて有効化
			this.toolStripButton2.Enabled = (this.nextCursor != null);

			this.followingUsers.Clear();
			this.listView1.Items.Clear();

			foreach (var user in followings.Users)
			{
				this.followingUsers.Add(user);

				var usernameWithHost = user.Username;

				if (user.Host != null)
					usernameWithHost += $"@{user.Host}";

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
					usernameWithHost += $"@{user.Host}";

				this.label1.Text = $"{user.Name} @{usernameWithHost}";
				this.textBox1.Text = user.Description;

				if (user.HasPendingFollowRequestFromYou)
					this.button1.Text = "承認待ち";
				else if (user.IsFollowing)
					this.button1.Text = "フォロー中";
				else
					this.button1.Text = "フォロー";

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
			if (this.listView1.SelectedItems.Count != 0)
			{
				var listItem = this.listView1.SelectedItems[0];
				var user = (User)listItem.Tag;

				// 画面を更新
				updateDisplayedProfile(user);
			}
			else
			{
				// 画面を更新
				updateDisplayedProfile(null);
			}
		}

        private async void button1_Click(object sender, EventArgs e)
        {
			var listItem = this.listView1.SelectedItems[0];
			var user = (User)listItem.Tag;

			try
			{
				User updated;

				if (user.HasPendingFollowRequestFromYou)
					updated = await this.api.CancelFollowRequest(user.Id);
				else if (!user.IsFollowing)
					updated = await this.api.Follow(user.Id);
				else
					updated = await this.api.Unfollow(user.Id);

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
				usernameWithHost += $"@{user.Host}";

			Process.Start($"https://{this.selectedAccount.Host}/@{usernameWithHost}");
		}
	}
}
