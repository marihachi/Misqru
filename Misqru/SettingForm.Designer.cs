namespace Misqru
{
	public partial class SettingForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.addInstanceButton = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.removeInstanceButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.LicenseLinkLabel = new System.Windows.Forms.LinkLabel();
			this.appNameLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.appDescriptionLabel = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// addInstanceButton
			// 
			this.addInstanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addInstanceButton.Location = new System.Drawing.Point(328, 6);
			this.addInstanceButton.Name = "addInstanceButton";
			this.addInstanceButton.Size = new System.Drawing.Size(80, 27);
			this.addInstanceButton.TabIndex = 1;
			this.addInstanceButton.Text = "追加...";
			this.addInstanceButton.UseVisualStyleBackColor = true;
			this.addInstanceButton.Click += new System.EventHandler(this.addInstanceButton_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(6, 6);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(316, 287);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ユーザ名";
			this.columnHeader1.Width = 250;
			// 
			// removeInstanceButton
			// 
			this.removeInstanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeInstanceButton.Location = new System.Drawing.Point(328, 39);
			this.removeInstanceButton.Name = "removeInstanceButton";
			this.removeInstanceButton.Size = new System.Drawing.Size(80, 27);
			this.removeInstanceButton.TabIndex = 1;
			this.removeInstanceButton.Text = "削除";
			this.removeInstanceButton.UseVisualStyleBackColor = true;
			this.removeInstanceButton.Click += new System.EventHandler(this.removeInstanceButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(6, 6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Padding = new System.Drawing.Point(0, 0);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(422, 330);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.addInstanceButton);
			this.tabPage1.Controls.Add(this.removeInstanceButton);
			this.tabPage1.Controls.Add(this.listView1);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(414, 299);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "アカウント";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.appDescriptionLabel);
			this.tabPage2.Controls.Add(this.versionLabel);
			this.tabPage2.Controls.Add(this.appNameLabel);
			this.tabPage2.Controls.Add(this.LicenseLinkLabel);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(414, 299);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "About";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// LicenseLinkLabel
			// 
			this.LicenseLinkLabel.AutoSize = true;
			this.LicenseLinkLabel.Location = new System.Drawing.Point(24, 132);
			this.LicenseLinkLabel.Name = "LicenseLinkLabel";
			this.LicenseLinkLabel.Size = new System.Drawing.Size(51, 18);
			this.LicenseLinkLabel.TabIndex = 6;
			this.LicenseLinkLabel.TabStop = true;
			this.LicenseLinkLabel.Text = "License";
			this.LicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// appNameLabel
			// 
			this.appNameLabel.AutoSize = true;
			this.appNameLabel.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.appNameLabel.Location = new System.Drawing.Point(22, 55);
			this.appNameLabel.Name = "appNameLabel";
			this.appNameLabel.Size = new System.Drawing.Size(74, 28);
			this.appNameLabel.TabIndex = 7;
			this.appNameLabel.Text = "Misqru";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.versionLabel.Location = new System.Drawing.Point(102, 59);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(55, 23);
			this.versionLabel.TabIndex = 8;
			this.versionLabel.Text = "v0.0.0";
			// 
			// appDescriptionLabel
			// 
			this.appDescriptionLabel.AutoSize = true;
			this.appDescriptionLabel.Location = new System.Drawing.Point(24, 89);
			this.appDescriptionLabel.Name = "appDescriptionLabel";
			this.appDescriptionLabel.Size = new System.Drawing.Size(320, 18);
			this.appDescriptionLabel.TabIndex = 9;
			this.appDescriptionLabel.Text = "A desktop app to prepare user-followings for Misskey.";
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 342);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button addInstanceButton;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button removeInstanceButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.LinkLabel LicenseLinkLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label appNameLabel;
		private System.Windows.Forms.Label appDescriptionLabel;
	}
}