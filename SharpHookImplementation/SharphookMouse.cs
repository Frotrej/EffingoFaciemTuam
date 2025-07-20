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
				
			}
			while (coordinatesY == 0 && coordinatesX == 0);

			hook.Dispose();
		}

		/*public void OnMouseClicked(object? sender, MouseHookEventArgs e)
		{
			coordinatesX = e.Data.X;
			coordinatesY = e.Data.Y;

			hook.Dispose();
		}*/

	}
}
