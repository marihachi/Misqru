namespace Misqru
{
	public partial class AddAccountForm
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
			this.hostBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// hostBox
			// 
			this.hostBox.Location = new System.Drawing.Point(26, 40);
			this.hostBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.hostBox.Name = "hostBox";
			this.hostBox.Size = new System.Drawing.Size(247, 25);
			this.hostBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "ホスト名:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(189, 111);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 26);
			this.button1.TabIndex = 4;
			this.button1.Text = "連携";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Teal;
			this.label2.Location = new System.Drawing.Point(22, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "アプリ連携の許可を待っています...";
			// 
			// AddAccountForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 156);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hostBox);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "AddAccountForm";
			this.Text = "アカウントの追加";
			this.Load += new System.EventHandler(this.AddInstanceForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox hostBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
	}
}