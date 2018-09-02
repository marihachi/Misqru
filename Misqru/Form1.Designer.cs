namespace Misqru
{
	public partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.accountComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.settingButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.readMoreButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.userListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.DescriptionBox = new System.Windows.Forms.TextBox();
			this.openMisskeyLink = new System.Windows.Forms.LinkLabel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.followButton = new System.Windows.Forms.Button();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.Snow;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.accountComboBox,
            this.settingButton,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.readMoreButton,
            this.toolStripSeparator3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(584, 26);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(73, 23);
			this.toolStripLabel1.Text = "アカウント:";
			// 
			// accountComboBox
			// 
			this.accountComboBox.Name = "accountComboBox";
			this.accountComboBox.Size = new System.Drawing.Size(150, 26);
			this.accountComboBox.Text = "選択してください";
			this.accountComboBox.SelectedIndexChanged += new System.EventHandler(this.accountComboBox_SelectedIndexChanged);
			// 
			// settingButton
			// 
			this.settingButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.settingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.settingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.settingButton.Name = "settingButton";
			this.settingButton.Size = new System.Drawing.Size(48, 23);
			this.settingButton.Text = "設定...";
			this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			// 
			// readMoreButton
			// 
			this.readMoreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.readMoreButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.readMoreButton.Name = "readMoreButton";
			this.readMoreButton.Size = new System.Drawing.Size(72, 23);
			this.readMoreButton.Text = "さらに取得";
			this.readMoreButton.Click += new System.EventHandler(this.readMoreButton_Click);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.userListView);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(584, 576);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(584, 602);
			this.toolStripContainer1.TabIndex = 3;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// userListView
			// 
			this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.userListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userListView.FullRowSelect = true;
			this.userListView.GridLines = true;
			this.userListView.Location = new System.Drawing.Point(0, 0);
			this.userListView.MultiSelect = false;
			this.userListView.Name = "userListView";
			this.userListView.Size = new System.Drawing.Size(584, 419);
			this.userListView.TabIndex = 3;
			this.userListView.UseCompatibleStateImageBehavior = false;
			this.userListView.View = System.Windows.Forms.View.Details;
			this.userListView.SelectedIndexChanged += new System.EventHandler(this.userListView_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名前";
			this.columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ユーザ名";
			this.columnHeader2.Width = 230;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 419);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(584, 4);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.DescriptionBox);
			this.panel1.Controls.Add(this.openMisskeyLink);
			this.panel1.Controls.Add(this.NameLabel);
			this.panel1.Controls.Add(this.followButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 423);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 153);
			this.panel1.TabIndex = 1;
			// 
			// DescriptionBox
			// 
			this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DescriptionBox.BackColor = System.Drawing.Color.White;
			this.DescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DescriptionBox.Location = new System.Drawing.Point(12, 38);
			this.DescriptionBox.Multiline = true;
			this.DescriptionBox.Name = "DescriptionBox";
			this.DescriptionBox.ReadOnly = true;
			this.DescriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DescriptionBox.Size = new System.Drawing.Size(449, 103);
			this.DescriptionBox.TabIndex = 3;
			// 
			// openMisskeyLink
			// 
			this.openMisskeyLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openMisskeyLink.AutoSize = true;
			this.openMisskeyLink.Location = new System.Drawing.Point(467, 38);
			this.openMisskeyLink.Name = "openMisskeyLink";
			this.openMisskeyLink.Size = new System.Drawing.Size(90, 18);
			this.openMisskeyLink.TabIndex = 2;
			this.openMisskeyLink.TabStop = true;
			this.openMisskeyLink.Text = "Misskeyで開く";
			this.openMisskeyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openMisskeyLink_LinkClicked);
			// 
			// NameLabel
			// 
			this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameLabel.AutoEllipsis = true;
			this.NameLabel.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NameLabel.Location = new System.Drawing.Point(12, 10);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(449, 23);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "名前";
			// 
			// followButton
			// 
			this.followButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.followButton.Location = new System.Drawing.Point(468, 6);
			this.followButton.Name = "followButton";
			this.followButton.Size = new System.Drawing.Size(104, 27);
			this.followButton.TabIndex = 0;
			this.followButton.Text = "フォロー";
			this.followButton.UseVisualStyleBackColor = true;
			this.followButton.Click += new System.EventHandler(this.followButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			// 
			// Form1
			// 
			this.AcceptButton = this.followButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 602);
			this.Controls.Add(this.toolStripContainer1);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form1";
			this.Text = "Misqru";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox accountComboBox;
		private System.Windows.Forms.ToolStripButton settingButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton readMoreButton;
		private System.Windows.Forms.ListView userListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button followButton;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.LinkLabel openMisskeyLink;
		private System.Windows.Forms.TextBox DescriptionBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

