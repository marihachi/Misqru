using Misqru.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Misqru
{
	public partial class AddAccountForm : Form
	{
		public AddAccountForm(Setting setting)
		{
			InitializeComponent();

			this.setting = setting;
		}

		private Setting setting;

		private List<MisskeyInstance> instances => this.setting.Instances;

		private List<MisskeyAccount> accounts => this.setting.Accounts;

		public MisskeyAccount Data { get; private set; }

		private void AddInstanceForm_Load(object sender, EventArgs e)
		{
			this.label2.Visible = false;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			this.button1.Enabled = false;

			if (string.IsNullOrEmpty(this.hostBox.Text))
			{
				this.button1.Enabled = true;
				MessageBox.Show("ホスト名が無効です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Uri uri;
			try
			{
				uri = new Uri($"https://{this.hostBox.Text}");
			}
			catch
			{
				this.button1.Enabled = true;
				MessageBox.Show("ホスト名が無効です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// 既に保存されているインスタンスを取得
			var instance = this.instances.FindByHost(uri.Host);

			var isNewInstance = (instance == null);

			// 新しいインスタンスだったとき
			if (isNewInstance)
			{
				Debug.WriteLine($"register app of new instance: {uri.Scheme}://{uri.Host}");

				try
				{
					// 連携アプリを新規登録
					instance = await MisskeyInstance.Register(uri.Host, "Misqru", "An desktop app to prepare user-followings", new[] { "following-write" });
				}
				catch
				{
					this.button1.Enabled = true;
					MessageBox.Show("連携アプリの登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				// Instancesに追加
				this.instances.Add(instance);
				await this.setting.SaveAsync();
			}

			this.label2.Visible = true;

			var account = await MisskeyAccount.Authorize(instance);

			this.label2.Visible = false;

			// 新しいインスタンスだったとき or Accountsに存在しなければ
			if (isNewInstance || this.accounts.FindIndex(i => i.Token == account.Token && i.Host == instance.Host) == -1)
			{
				// Accountsに追加
				this.accounts.Add(account);
				await this.setting.SaveAsync();

				this.Data = account;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
