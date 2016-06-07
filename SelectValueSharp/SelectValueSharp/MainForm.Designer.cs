/*
 * Created by SharpDevelop.
 * User: savage
 * Date: 30.05.2016
 * Time: 22:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SelectValueSharp
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBoxSearchValue;
		private System.Windows.Forms.ListBox listBoxResult;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxSearchValue = new System.Windows.Forms.TextBox();
			this.listBoxResult = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// textBoxSearchValue
			// 
			this.textBoxSearchValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxSearchValue.Location = new System.Drawing.Point(0, 0);
			this.textBoxSearchValue.Name = "textBoxSearchValue";
			this.textBoxSearchValue.Size = new System.Drawing.Size(499, 20);
			this.textBoxSearchValue.TabIndex = 0;
			this.textBoxSearchValue.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			this.textBoxSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1KeyDown);
			// 
			// listBoxResult
			// 
			this.listBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxResult.FormattingEnabled = true;
			this.listBoxResult.Location = new System.Drawing.Point(0, 20);
			this.listBoxResult.Name = "listBoxResult";
			this.listBoxResult.Size = new System.Drawing.Size(499, 299);
			this.listBoxResult.TabIndex = 2;
			this.listBoxResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox2KeyDown);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 319);
			this.Controls.Add(this.listBoxResult);
			this.Controls.Add(this.textBoxSearchValue);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SelectValueSharp";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
