using Misqru.Models;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Misqru
{
	public partial class SettingForm : Form
	{
		public SettingForm(Setting setting)
		{
			InitializeComponent();

			this.setting = setting;
		}

		private Setting setting;

		private void addInstanceButton_Click(object sender, EventArgs e)
		{
			var f = new AddAccountForm(this.setting);
			if (f.ShowDialog() == DialogResult.OK)
			{
				var account = f.Data;

				// 新しくAccountsに追加された場合
				if (account != null)
				{
					var instance = account.FindInstance(this.setting);

					// リストに項目を追加
					this.listView1.Items.Add(new ListViewItem(new[] { $"{account.Username}@{instance.Host}" })
					{
						Tag = account
					});
				}
			}
		}

		private async void removeInstanceButton_Click(object sender, EventArgs e)
		{
			var item = this.listView1.SelectedItems[0];
			var account = (MisskeyAccount)item.Tag;

			// Accountsから削除
			this.setting.Accounts.Remove(account);
			await this.setting.SaveAsync();

			// リストの項目を削除
			this.listView1.Items.Remove(item);
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selected = this.listView1.SelectedIndices.Count != 0;
			this.removeInstanceButton.Enabled = selected;
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			this.removeInstanceButton.Enabled = false;

			// リストの項目を構成
			foreach (var account in this.setting.Accounts)
			{
				var instance = this.setting.Instances.Find(i => i.HostAndAppId == account.HostAndAppId);

				this.listView1.Items.Add(new ListViewItem(new[] { $"{account.Username}@{instance.Host}" })
				{
					Tag = account
				});
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/marihachi/Misqru/blob/master/LICENSE.md");
		}
	}
}
