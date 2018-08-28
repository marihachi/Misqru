using Misqru.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
		private List<User> users = new List<User>();

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

		private void toolStripButton2_Click(object sender, EventArgs e)
		{

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
			var res = await this.api.Request("users/following", param);

			this.users.Clear();
			this.listView1.Items.Clear();

			foreach (JToken t in res.users)
			{
				var user = t.ToObject<User>();

				this.users.Add(user);

				var item = new ListViewItem(new[] { $"{user.Name} @{user.Username}" });
				item.Tag = user;
				this.listView1.Items.Add(item);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 0)
			{
				this.label1.Text = "";
				this.label2.Text = "";
				return;
			}

			var item = this.listView1.SelectedItems[0];
			var user = (User)item.Tag;

			this.label1.Text = $"{user.Name} @{user.Username}";
			this.label2.Text = user.Description;
		}
	}
}
