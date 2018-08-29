using Misqru.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Misqru
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private Setting setting;
		private Misq.Me api;
		private List<User> followingUsers = new List<User>();

		private string nextCursor;

		private async void Form1_Load(object sender, EventArgs e)
		{
			this.setting = await Setting.LoadAsync();

			// 構成
			foreach(var account in this.setting.Accounts)
			{
				var instance = this.setting.Instances.Find(i => i.HostAndAppId == account.HostAndAppId);

				this.toolStripComboBox1.Items.Add($"{account.Username}@{instance.Host}");
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			var f = new SettingForm(this.setting);
			f.ShowDialog();
		}

		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			dynamic res;
			try
			{
				var param = new Dictionary<string, object>
				{
					["userId"] = this.api.ID,
					["limit"] = 100,
					["cursor"] = this.nextCursor
				};
				res = await this.api.Request("followingUsers/following", param);
			}
			catch
			{
				MessageBox.Show("データの取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			this.nextCursor = res.next.Value;

			foreach (JObject t in res.followingUsers)
			{
				var user = User.FromJObject(t);

				this.followingUsers.Add(user);

				var listItem = new ListViewItem(new[] { $"{user.Name} @{user.Username}" });
				listItem.Tag = user;
				this.listView1.Items.Add(listItem);
			}
		}

		private async void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var index = this.toolStripComboBox1.SelectedIndex;
			var accountData = this.setting.Accounts[index];
			var instanceData = accountData.FindInstance(this.setting);

			dynamic data = new JObject();
			data.id = accountData.Id;

			this.api = new Misq.Me($"https://{instanceData.Host}", accountData.UserToken, instanceData.AppSecret, data);

			var param = new Dictionary<string, object>
			{
				["userId"] = this.api.ID,
				["limit"] = 100
			};
			var res = await this.api.Request("followingUsers/following", param);

			this.nextCursor = res.next.Value;

			this.followingUsers.Clear();
			this.listView1.Items.Clear();

			foreach (JObject t in res.followingUsers)
			{
				var user = User.FromJObject(t);

				this.followingUsers.Add(user);

				var listItem = new ListViewItem(new[] { $"{user.Name} @{user.Username}" });
				listItem.Tag = user;
				this.listView1.Items.Add(listItem);
			}
		}

		private void updateDisplayedProfile(User user) {
			if (user == null)
			{
				this.label1.Text = "";
				this.label2.Text = "";
				this.button1.Enabled = false;
			}
			else
			{
				this.label1.Text = $"{user.Name} @{user.Username}";
				this.label2.Text = user.Description;

				this.button1.Enabled = true;
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
				var obj = (JObject)await this.api.Request(endpoint, new Dictionary<string, object> { ["userId"] = user.Id });
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
    }
}
