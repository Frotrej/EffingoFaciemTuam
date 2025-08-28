using EffingoFaciemTuam.Model;
using SharpHook;
using static EffingoFaciemTuam.SideWindows.GetKeyboardDataFromUserPopUp;

namespace EffingoFaciemTuam.SharpHookImplementation
{
	internal class SharphookMouse
	{
		public SimpleGlobalHook hook = new SimpleGlobalHook();

		public async Task SetMousePositionOnFirstMouseClick(UpdateCoordinatesInUI UpdateUI, SequenceElement element)
		{
			var tcs = new TaskCompletionSource();

			hook.MouseMoved += (sender, e) =>
			{
				UpdateUI(e.Data.X, e.Data.Y);
			};

			hook.MouseClicked += (sender, e) =>
			{
				element.MouseX = e.Data.X;
				element.MouseY = e.Data.Y;

				hook.Dispose();
				tcs.TrySetResult();
			};

			await hook.RunAsync();
			await tcs.Task;
		}
	}
}
