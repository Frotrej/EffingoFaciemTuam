using EffingoFaciemTuam.Model;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows.AddElementWindowsSequence
{
	public partial class GetKbdDataFromUserPupUp : Window
	{
		SequenceElement _newElement;

		SharpHookImplementation.SharphookImplementation sharphookKbd;


		public GetKbdDataFromUserPupUp(SequenceElement element)
		{
			InitializeComponent();

			_newElement = element;
			DataContext = _newElement;
			sharphookKbd = new();
		}

		private void Button_Click_StopTrackingAndCloseWindow(object sender, RoutedEventArgs e)
		{
			sharphookKbd.hook.Dispose();
			Close();
		}

		private async void Button_Click_FillKbdSequenceElement(object sender, RoutedEventArgs e)
		{
			StartBtn.IsEnabled = false;

			await StartTrackingKbd(_newElement);

			StartBtn.IsEnabled = true;
		}

		private async Task StartTrackingKbd(SequenceElement newElement)
		{
			newElement.KeyboardKeys.Clear();

			await sharphookKbd.TrackKbdKeys(newElement);
		}

		private void Button_Click_Stop(object sender, RoutedEventArgs e)
		{
			sharphookKbd.hook.Stop();
		}
	}
}
