using Misqru.Models;
using System;
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

		private void showSettingButton_Click(object sender, EventArgs e)
		{
			var f = new SettingForm(this.setting);
			f.ShowDialog();
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			this.setting = await Setting.LoadAsync();
		}
	}
}
