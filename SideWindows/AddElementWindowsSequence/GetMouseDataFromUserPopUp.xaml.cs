using EffingoFaciemTuam.Model;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows
{
	public partial class GetMouseDataFromUserPopUp : Window
	{
		//This window is used to get data from user to create a mouse element for SequenceElement and add this element to SequenceModel

		private SequenceElement _newElement;

		public GetMouseDataFromUserPopUp(SequenceElement element)
		{
			InitializeComponent();

			_newElement = element;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		//CreateFillAndAddSequenceElement
		private async void Button_Click_CreateFillAndAddSequenceElement(object sender, RoutedEventArgs e)
		{
			BtnStartTrackMouse.IsEnabled = false;

			await StartTrackingMouseUntilClick(_newElement);

			BtnStartTrackMouse.IsEnabled = true;

			CloseWindow(sender, e);
		}

		private async Task StartTrackingMouseUntilClick(SequenceElement newElement)
		{
			SharpHookImplementation.SharphookMouse sharphookMouse = new();
			await sharphookMouse.GetMousePositionOnFirstMouseClick(UpdateCoordinatesUI, newElement);
		}

		public delegate void UpdateCoordinatesInUI(int x, int y);

		public void UpdateCoordinatesUI(int x, int y)
		{
			if (Dispatcher.CheckAccess())
			{
				TextBlockXcoord.Text = $"X: {x}";
				TextBlockYcoord.Text = $"Y: {y}";
			}
			else
			{
				Dispatcher.Invoke(() => UpdateCoordinatesUI(x, y));
			}
		}
	}
}
