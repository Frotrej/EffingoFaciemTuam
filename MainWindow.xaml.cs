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

			DataHolder.Instance.GetDataAndPassToSaveIt(this);
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

		private void Button_Click_CopyDataBasedOnID(object sender, RoutedEventArgs e)
		{
			int buttonID = ExtractButtonIDFromItsName(sender);
			if (buttonID == 0) return;


			
			Clipboard.SetText(DataHolder.Instance.GetRowOfData(buttonID - 1));

		}

		private int ExtractButtonIDFromItsName(object sender)
		{
			Button? button = sender as Button;
			string? buttonName = button?.Name;

			if (buttonName == null)  return 0;
			char buttonNameLastChar = buttonName.LastOrDefault();

			if (char.IsDigit(buttonNameLastChar) == false) return 0;
			int buttonID = int.Parse(buttonNameLastChar.ToString());
			return buttonID;
		}

		/*DataHolder dataHolder = new DataHolder(this);
		dataHolder.CopyDataToClipboard();*/

	}
}