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
			//int x = 0;
			if (textBoxSearchValue.Text == string.Empty) {
				listBoxResult.Items.AddRange(listBoxAllValues.Items);
				return;
			}
			
			string match = @".*(" + textBoxSearchValue.Text + @").*";
			match = match.Replace(" ", @".*");
			listBoxResult.Items.Clear();
			
			Regex newReg = new Regex(match, RegexOptions.IgnoreCase);
			
			// Examine text box length 
			if (textBoxSearchValue.Text.Length != 0) {
				foreach (var strv in listBoxAllValues.Items) {
					if (newReg.IsMatch(strv.ToString())) {
						listBoxResult.Items.Add(strv);
						listBoxResult.SetSelected(0, true);
					}
				}
			}
		}
	
		void ListBox2KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode) {
				// MessageBox.Show("2: " + listBox2.SelectedItem.ToString());
				string сurValue = listBoxResult.SelectedItem.ToString();
//				if (сurValue == string.Empty) {
//					сurValue = textBoxSearchValue.Text;
//				}
				ResultToFile(сurValue);
				Application.Exit();
			} else if (Keys.Left == e.KeyCode) {
				textBoxSearchValue.Text = listBoxResult.SelectedItem.ToString();
				textBoxSearchValue.Focus();
			} else if (Keys.Right == e.KeyCode) {
				textBoxSearchValue.Text = listBoxResult.SelectedItem.ToString();
				textBoxSearchValue.Focus();
			}
		}

		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Down == e.KeyCode) {
				listBoxResult.Select();
			} else if (Keys.Enter == e.KeyCode) {
				string сurValue = textBoxSearchValue.Text;
				ResultToFile(сurValue);
				Application.Exit();
			}
		}
		
		void ResultToFile(string valueToFile) {
			StreamWriter sw = new StreamWriter(fileNameOut, false,System.Text.Encoding.Default);
			//sw.Write(valueToFile, System.Text.Encoding.GetEncoding(1251));
			sw.Write(valueToFile);
			sw.Close();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string[] appArgs = System.Environment.GetCommandLineArgs();
			
//			foreach (string strVal in appArgs) {
//				listBox2.Items.Add(strVal);
//			}
			
			string line;
			string fileName = appArgs[1]; //"c:\\work\\portable\\v8CfgAddsAhk\\tmp\\module.1s";
			fileNameOut = fileName;
			FileStream sss = File.Open(fileName, FileMode.Open, FileAccess.Read);
			if (sss != null) {
				StreamReader reader = new StreamReader(sss, System.Text.Encoding.GetEncoding(1251));
				while ((line = reader.ReadLine()) != null) {
					listBoxAllValues.Items.Add(line);
					listBoxResult.Items.Add(line);
                    	
				}
				sss.Close();
			}
		}
	}
}
