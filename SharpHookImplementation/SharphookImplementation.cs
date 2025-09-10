using EffingoFaciemTuam.Model;
using SharpHook;
using static EffingoFaciemTuam.SideWindows.GetMouseDataFromUserPopUp;

namespace EffingoFaciemTuam.SharpHookImplementation
{
	internal class SharphookImplementation
	{
		public SimpleGlobalHook hook = new SimpleGlobalHook();

		public async Task RefreshMousePositionUntillFirstMouseClick(UpdateCoordinatesInUI UpdateUI, SequenceElement element)
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

		public async Task TrackKbdKeys(SequenceElement element)
		{
			hook.KeyPressed += (sender, e) =>
			{
					element.KeyboardKeys.Add(e.Data.KeyCode);

				element.TranslateToString(element.KeyboardKeys);
			};

			await hook.RunAsync();
		}
	}
}
