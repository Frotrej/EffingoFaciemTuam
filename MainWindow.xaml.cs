using EffingoFaciemTuam.HandlingUserData;
using EffingoFaciemTuam.SharpHookImplementation;
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

			//loading saved user data  from Properties.settings
			SavingLoadingUserData.LoadUserData(this);

			UserEntryDataHolder.Instance.LoadDataFromView(this);
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

			UserEntryDataHolder.Instance.LoadDataFromView(this);

			Clipboard.SetText(UserEntryDataHolder.Instance.GetRowOfData(buttonID - 1));
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

		private void GetMousexyOnNextMouseClick(object sender, RoutedEventArgs e)
		{
			SharphookMouse sharphookMouse = new SharphookMouse();

			//sharphookMouse.SetMousePositionOnFirstMouseClick();

			Clipboard.SetText($"X:{sharphookMouse.coordinatesX}, Y:{sharphookMouse.coordinatesY}");
		}

		private void OpenWindow_SequenceManagement(object sender, RoutedEventArgs e)
		{
			SequenceManagement _window = new SequenceManagement();
			_window.ShowDialog();
		}
	}
}