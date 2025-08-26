using System.Runtime.CompilerServices;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows
{
	public partial class GetKeyboardDataFromUserPopUp : Window
	{
		public GetKeyboardDataFromUserPopUp()
		{
			InitializeComponent();


		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
			//dodac anulowanie procesu dodawania elementu
		}

		private void Button_Click_GetCoordinatesForElement(object sender, RoutedEventArgs e)
		{
			SharpHookImplementation.SharphookMouse sharphookMouse = new();
			sharphookMouse.SetMousePositionOnFirstMouseClick(UpdateUI);
		}

		public delegate void UpdateCoordinatesInUI(int x, int y);

		public void UpdateUI(int x, int y)
		{
			TextBlockXcoord.Text = $"X: {x}";
			TextBlockYcoord.Text = $"Y: {y}";
		}
	}
}
