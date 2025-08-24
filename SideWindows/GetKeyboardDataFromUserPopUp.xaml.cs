using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
			sharphookMouse.SetMousePositionOnFirstMouseClick();
			int X = sharphookMouse.coordinatesX;
			int Y = sharphookMouse.coordinatesY;
			//nie dziala znalezc lepsze rozwiazanie
		}
	}
}
