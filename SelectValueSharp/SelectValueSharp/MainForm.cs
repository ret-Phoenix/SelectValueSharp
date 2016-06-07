/*
 * Created by SharpDevelop.
 * User: savage
 * Date: 30.05.2016
 * Time: 22:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SelectValueSharp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string fileNameOut;
		string bigStr;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if (textBoxSearchValue.Text == string.Empty) {
				listBoxResult.BeginUpdate();
				listBoxResult.Items.Clear();
				string[] str = bigStr.Split('\r');
				listBoxResult.Items.AddRange(str);
				listBoxResult.EndUpdate();
				return;
			}
			
			var matches = Regex.Matches(bigStr, @"(.*)(" + textBoxSearchValue.Text.Replace(" ", @".*") + @")(.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			int counter = 0;
			listBoxResult.BeginUpdate();
			listBoxResult.Items.Clear();
			foreach (Match item in matches) {
				counter++;
				listBoxResult.Items.Add(item);
			}
			listBoxResult.EndUpdate();
			
		}
	
		void ListBox2KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode) {
				string сurValue = listBoxResult.SelectedItem.ToString();
				ResultToFile(сurValue);
				Application.Exit();
			} else if (Keys.Left == e.KeyCode) {
				//textBoxSearchValue.Text = listBoxResult.SelectedItem.ToString();
				textBoxSearchValue.Focus();
			} else if (Keys.Right == e.KeyCode) {
				//textBoxSearchValue.Text = listBoxResult.SelectedItem.ToString();
				textBoxSearchValue.Focus();
			}
		}

		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down) {
				listBoxResult.Select();
			} else if (e.KeyCode == Keys.Enter) {
				string сurValue = textBoxSearchValue.Text;
				ResultToFile(сurValue);
				Application.Exit();
			} else if (e.KeyCode == Keys.Escape) {
				ResultToFile("");
				Application.Exit();
			}
		}
		
		void ResultToFile(string valueToFile)
		{
			StreamWriter sw = new StreamWriter(fileNameOut, false, System.Text.Encoding.Default);
			sw.Write(valueToFile.Trim());
			sw.Close();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string[] appArgs = System.Environment.GetCommandLineArgs();
			string fileName = appArgs[1];
			fileNameOut = fileName;
			FileStream sss = File.Open(fileName, FileMode.Open, FileAccess.Read);
			if (sss != null) {
				var reader = new StreamReader(sss, System.Text.Encoding.GetEncoding(1251));
				bigStr = reader.ReadToEnd();
				sss.Close();
				
				listBoxResult.Items.Clear();
				string[] str = bigStr.Split('\r');
				listBoxResult.Items.AddRange(str);
				listBoxResult.EndUpdate();
				
			}
		}
	}
}
