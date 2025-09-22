using EffingoFaciemTuam.Model;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows
{
	public partial class GetMouseDataFromUserPopUp : Window
	{
		//This window is used to get data from user to create a mouse element for SequenceElement and return it to the SequenceManager window

		private SequenceElement _newElement;

		public bool _operationSuccessful { get; private set; }

		public GetMouseDataFromUserPopUp(SequenceElement element)
		{
			InitializeComponent();
			_newElement = element;
		}

		private async void Button_Click_FillMouseSequenceElement(object sender, RoutedEventArgs e)
		{
			BtnStartTrackMouse.IsEnabled = false;

			await StartTrackingMouseUntilClick(_newElement);

			BtnStartTrackMouse.IsEnabled = true;

			WindowCloseSuccessfully();
		}

		private async Task StartTrackingMouseUntilClick(SequenceElement newElement)
		{
			SharpHookImplementation.SharphookImplementation sharphookMouse = new();
			await sharphookMouse.RefreshMousePositionUntillFirstMouseClick(UpdateCoordinatesUI, newElement);
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

		private void WindowCloseSuccessfully()
		{
			_operationSuccessful = true;
			Close();
		}
	}
}
