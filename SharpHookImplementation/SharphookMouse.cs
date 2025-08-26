using EffingoFaciemTuam.SideWindows;
using SharpHook;
using System.Windows;
using static EffingoFaciemTuam.SideWindows.GetKeyboardDataFromUserPopUp;

namespace EffingoFaciemTuam.SharpHookImplementation
{
	internal class SharphookMouse
	{
		public SimpleGlobalHook hook = new SimpleGlobalHook();

		public int coordinatesX = 0;
		public int coordinatesY = 0;


		public void SetMousePositionOnFirstMouseClick(UpdateCoordinatesInUI UpdateUI)
		{
			hook.MouseMoved += (sender, e) =>
			{
				coordinatesX = e.Data.X;
				coordinatesY = e.Data.Y;

				UpdateUI(coordinatesX, coordinatesY);
			};

			hook.MouseClicked += (sender, e) =>
			{
				coordinatesX = e.Data.X;
				coordinatesY = e.Data.Y;

				hook.Dispose();
			};

			hook.RunAsync();

			coordinatesX = 0;
			coordinatesY = 0;
			do
			{
			 //podpiac koordynaty bezposrednio do okna??
			}
			while (coordinatesY == 0 && coordinatesX == 0);
		}
	}
}
