using EffingoFaciemTuam.Model;
using EffingoFaciemTuam.SharpHookImplementation;
using EffingoFaciemTuam.UserDataHandling;
using EffingoFaciemTuam.Windows;
using System.Windows;
using System.Windows.Controls;


/*przy obecnym wygladazie aplikacji dane z pól tekstowych nie zapisuja sie automatycznie przy kazdorazowej zmianie tego pola, na czas opecny rozwiazaniem jest code behind ktory wywoluje metode do zapisania danych w zmiennych za pomoca "UserEntryDataHolder.Instance.LoadDataFromView(this);" 
 */

namespace EffingoFaciemTuam
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var sequence = SequenceStore.ShareSequence;

			//loading saved user data
			SavingLoadingUserData.LoadUserData(this);
			SequenceStore.LoadUserSequence();

			MainWindowUserDataHolder.Instance.LoadDataFromView(this);
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

			MainWindowUserDataHolder.Instance.LoadDataFromView(this);

			Clipboard.SetText(MainWindowUserDataHolder.Instance.GetRowOfData(buttonID - 1));
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

		private void OpenWindow_SequenceManagement(object sender, RoutedEventArgs e)
		{
			SequenceManagement _window = new SequenceManagement();
			_window.ShowDialog();
		}

		private void Btn_Click_SimulateSequence(object sender, RoutedEventArgs e)
		{
			SequenceModel _sequence = SequenceStore.ShareSequence;

			Button_Click_CopyDataBasedOnID(sender, e);

			InputSimulator.SimulateSequence(_sequence);
		}
	}
}