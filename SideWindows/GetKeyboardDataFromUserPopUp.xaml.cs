using EffingoFaciemTuam.Model;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows
{
	public partial class GetKeyboardDataFromUserPopUp : Window
	{
		//This window is used to get data from user to create a mouse element for SequenceElement and pass it to the sequence

		private ObservableCollection<SequenceElement> _element;

		public GetKeyboardDataFromUserPopUp(ObservableCollection<SequenceElement> element)
		{
			InitializeComponent();

			_element = element;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void GetPosAndTrackMouseUntilClick(SequenceElement elemenet)
		{
			SharpHookImplementation.SharphookMouse sharphookMouse = new();
			sharphookMouse.SetMousePositionOnFirstMouseClick(UpdateCoordinatesUI);

			elemenet.MouseX = sharphookMouse.coordinatesX;
			elemenet.MouseY = sharphookMouse.coordinatesY;
		}
		
		//CreateFillAndAddSequenceElement
		private void Button_Click_CreateFillAndAddSequenceElement(object sender, RoutedEventArgs e)
		{
			SequenceElement newElemenet = new();

			GetPosAndTrackMouseUntilClick(newElemenet);

			_element.Add(newElemenet);//dziala ale nie czeka na klikniecie myszy hehe
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
