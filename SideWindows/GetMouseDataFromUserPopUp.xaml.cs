using EffingoFaciemTuam.Model;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows
{
	public partial class GetKeyboardDataFromUserPopUp : Window
	{
		//This window is used to get data from user to create a mouse element for SequenceElement and add this element to SequenceModel

		private SequenceModel _sequenceElements;

		public GetKeyboardDataFromUserPopUp(SequenceModel sequence)
		{
			InitializeComponent();

			_sequenceElements = sequence;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		//CreateFillAndAddSequenceElement
		private async void Button_Click_CreateFillAndAddSequenceElement(object sender, RoutedEventArgs e)
		{
			BtnStartTrackMouse.IsEnabled = false;
			this.Topmost = !this.Topmost;

			SequenceElement newElemenet = new(SequenceElement.ElementType.Mysz, 0, 0);

			await StartTrackingMouseUntilClick(newElemenet);

			_sequenceElements.AddElementToSequence(newElemenet);

			BtnStartTrackMouse.IsEnabled = true;
			this.Topmost = !this.Topmost;
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
