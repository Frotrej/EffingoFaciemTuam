using EffingoFaciemTuam.SideWindows;
using SharpHook;
using System.Windows;

namespace EffingoFaciemTuam.SharpHookImplementation
{
	internal class SharphookMouse
	{
		public SimpleGlobalHook hook = new SimpleGlobalHook();

		public int coordinatesX = 0;
		public int coordinatesY = 0;


		public void SetMousePositionOnFirstMouseClick()
		{
			hook.MouseMoved += (sender, e) =>
			{
				coordinatesX = e.Data.X;
				coordinatesY = e.Data.Y;
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
				GetKeyboardDataFromUserPopUp. //podpiac koordynaty bezposrednio do okna??
			}
			while (coordinatesY == 0 && coordinatesX == 0);
		}
	}
}
