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

			//loading Saved Properties.settings of user data
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
		//saving user data to Properties.settings
		private void OnMainWindowClose(object sender, EventArgs e)
		{
			#region savingUserData
			Properties.Settings.Default.SavedTextBox1 = TextBox1.Text;
			Properties.Settings.Default.SavedTextBox2 = TextBox2.Text;
			Properties.Settings.Default.SavedTextBox3 = TextBox3.Text;
			Properties.Settings.Default.SavedTextBox4 = TextBox4.Text;
			Properties.Settings.Default.SavedTextBox5 = TextBox5.Text;
			Properties.Settings.Default.SavedTextBox6 = TextBox6.Text;
			Properties.Settings.Default.SavedTextBox7 = TextBox7.Text;
			Properties.Settings.Default.Save();
			#endregion
		}



		private void CheckBox_Clicked(object sender, RoutedEventArgs e)
		{
			//DODAĆ rozpoznac czy checkbox jest zaznaczony i dopiero poźniej zmienić .Topmost
			this.Topmost = !this.Topmost;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var textBox = button?.Tag as TextBox;
			var textBoxPrefix = button?.Tag as TextBox; //jak zrobic zeby zbindowac wieej niz jeden element tagiem
			Clipboard.SetText(textBox?.Text + textBoxPrefix?.Text);
		}

		#region distinguishing the number of the Coppy button clicked 
		private void Button1_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox1.Text, SuffixValue1.Text);
		}
		private void Button2_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox2.Text, SuffixValue2.Text);
		}
		private void Button3_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox3.Text, SuffixValue3.Text);
		}
		private void Button4_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox4.Text, SuffixValue4.Text);
		}
		private void Button5_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox5.Text, SuffixValue5.Text);
		}
		private void Button6_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox6.Text, SuffixValue6.Text);
		}
		private void Button7_coppy(object sender, RoutedEventArgs e)
		{
			JoinValuesAndCoppyToCB(TextBox7.Text, SuffixValue7.Text);
		}
		#endregion 

		private void JoinValuesAndCoppyToCB(string main, string prefix)
		{
			string joinedValues = main + prefix;

			Clipboard.SetText(joinedValues);
		}
	}
}