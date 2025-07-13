using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EffingoFaciemTuam.HandlingUserData
{
	internal static class SavingLoadingUserData
	{
		public static void LoadUserData(MainWindow mainWindow)
		{
			mainWindow.TextBox1.Text = Properties.Settings.Default.SavedTextBox1;
			mainWindow.TextBox2.Text = Properties.Settings.Default.SavedTextBox2;
			mainWindow.TextBox3.Text = Properties.Settings.Default.SavedTextBox3;
			mainWindow.TextBox4.Text = Properties.Settings.Default.SavedTextBox4;
			mainWindow.TextBox5.Text = Properties.Settings.Default.SavedTextBox5;
			mainWindow.TextBox6.Text = Properties.Settings.Default.SavedTextBox6;
			mainWindow.TextBox7.Text = Properties.Settings.Default.SavedTextBox7;

			mainWindow.SuffixValue1.Text = Properties.Settings.Default.SavedSuffix1;
			mainWindow.SuffixValue2.Text = Properties.Settings.Default.SavedSuffix2;
			mainWindow.SuffixValue3.Text = Properties.Settings.Default.SavedSuffix3;
			mainWindow.SuffixValue4.Text = Properties.Settings.Default.SavedSuffix4;
			mainWindow.SuffixValue5.Text = Properties.Settings.Default.SavedSuffix5;
			mainWindow.SuffixValue6.Text = Properties.Settings.Default.SavedSuffix6;
			mainWindow.SuffixValue7.Text = Properties.Settings.Default.SavedSuffix7;
		}

		internal static void SaveUserData(MainWindow mainWindow)
		{
			Properties.Settings.Default.SavedTextBox1 = mainWindow.TextBox1.Text;
			Properties.Settings.Default.SavedTextBox2 = mainWindow.TextBox2.Text;
			Properties.Settings.Default.SavedTextBox3 = mainWindow.TextBox3.Text;
			Properties.Settings.Default.SavedTextBox4 = mainWindow.TextBox4.Text;
			Properties.Settings.Default.SavedTextBox5 = mainWindow.TextBox5.Text;
			Properties.Settings.Default.SavedTextBox6 = mainWindow.TextBox6.Text;
			Properties.Settings.Default.SavedTextBox7 = mainWindow.TextBox7.Text;

			Properties.Settings.Default.SavedSuffix1 = mainWindow.SuffixValue1.Text;
			Properties.Settings.Default.SavedSuffix2 = mainWindow.SuffixValue2.Text;
			Properties.Settings.Default.SavedSuffix3 = mainWindow.SuffixValue3.Text;
			Properties.Settings.Default.SavedSuffix4 = mainWindow.SuffixValue4.Text;
			Properties.Settings.Default.SavedSuffix5 = mainWindow.SuffixValue5.Text;
			Properties.Settings.Default.SavedSuffix6 = mainWindow.SuffixValue6.Text;
			Properties.Settings.Default.SavedSuffix7 = mainWindow.SuffixValue7.Text;

			Properties.Settings.Default.Save();
		}
	}
}
