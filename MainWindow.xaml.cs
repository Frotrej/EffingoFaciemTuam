using EffingoFaciemTuam.HandlingUserData;
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

			//loading saved user data  from Properties.settings
			SavingLoadingUserData.LoadUserData(this);
		}

		private void OnMainWindowClose(object sender, EventArgs e)
		{
			//saving user data to Properties.settings
			SavingLoadingUserData.SaveUserData(this);
		}

		private void CheckBox_Clicked(object sender, RoutedEventArgs e)
		{
			this.Topmost = !this.Topmost;
		}

		private void Button_Click_CopyData(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			string buttonName = button.Name;
			if (buttonName == null) return;

			char buttonNameLastChar = buttonName.LastOrDefault();
			if (char.IsDigit(buttonNameLastChar) == false) return;
			int id = int.Parse(buttonNameLastChar.ToString());

			Clipboard.SetText(id.ToString());

		}

		/*DataHolder dataHolder = new DataHolder(this);
		dataHolder.Get_LoadData();
		dataHolder.CopyDataToClipboard();*/

	}
}