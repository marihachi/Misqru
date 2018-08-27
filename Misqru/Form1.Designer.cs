namespace Misqru
{
	partial class Form1
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
			this.showSettingButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// showSettingButton
			// 
			this.showSettingButton.Location = new System.Drawing.Point(587, 12);
			this.showSettingButton.Name = "showSettingButton";
			this.showSettingButton.Size = new System.Drawing.Size(87, 27);
			this.showSettingButton.TabIndex = 0;
			this.showSettingButton.Text = "設定...";
			this.showSettingButton.UseVisualStyleBackColor = true;
			this.showSettingButton.Click += new System.EventHandler(this.showSettingButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(686, 404);
			this.Controls.Add(this.showSettingButton);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form1";
			this.Text = "Misqru";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button showSettingButton;
	}
}

