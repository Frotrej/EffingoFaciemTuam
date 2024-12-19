using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EffingoFaciemTuam
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			//primitive loading Saved Properties.settings of user data
			#region loadingUserData
			TextBox1.Text = Properties.Settings.Default.SavedTextBox1;
			TextBox2.Text = Properties.Settings.Default.SavedTextBox2;
			TextBox3.Text = Properties.Settings.Default.SavedTextBox3;
			TextBox4.Text = Properties.Settings.Default.SavedTextBox4;
			TextBox5.Text = Properties.Settings.Default.SavedTextBox5;
			TextBox6.Text = Properties.Settings.Default.SavedTextBox6;
			TextBox7.Text = Properties.Settings.Default.SavedTextBox7;
			#endregion 
		}
		//primitive saving user data to Properties.settings
		private void OnMainWindowClose(object sender, EventArgs e)
		{
			Properties.Settings.Default.SavedTextBox1 = TextBox1.Text;
			Properties.Settings.Default.SavedTextBox2 = TextBox2.Text;
			Properties.Settings.Default.SavedTextBox3 = TextBox3.Text;
			Properties.Settings.Default.SavedTextBox4 = TextBox4.Text;
			Properties.Settings.Default.SavedTextBox5 = TextBox5.Text;
			Properties.Settings.Default.SavedTextBox6 = TextBox6.Text;
			Properties.Settings.Default.SavedTextBox7 = TextBox7.Text;
			Properties.Settings.Default.Save();
		}

		//handling of locking and copying textboxes
		private void LockTextBox_Checked(object sender, RoutedEventArgs e)
		{
			var checkBox = sender as CheckBox;
			var textBox = checkBox?.Tag as TextBox;

			if (textBox != null)
			{
				textBox.IsReadOnly = true;
				Clipboard.SetText(textBox.Text);
				textBox.Focusable = false;
				textBox.Cursor = System.Windows.Input.Cursors.Hand;
			}
		}
		private void LockTextBox_Unchecked(object sender, RoutedEventArgs e)
		{
			var checkBox = sender as CheckBox;
			var textBox = checkBox?.Tag as TextBox;

			if (textBox != null)
			{
				textBox.IsReadOnly = false;
				textBox.Focusable = true;
				textBox.Cursor = System.Windows.Input.Cursors.IBeam;
			}
		}

		private void CopyText_LeftClick(object sender, RoutedEventArgs e)
		{
			var textBox = sender as TextBox;
			if (textBox != null && textBox.IsReadOnly)
			{
				Clipboard.SetText(textBox.Text);
			}
		}

		private void CheckBox_Clicked(object sender, RoutedEventArgs e)
		{
			this.Topmost = !this.Topmost;
		}
	}
}