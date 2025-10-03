using EffingoFaciemTuam.Model;
using System.Windows;

namespace EffingoFaciemTuam.SideWindows.AddElementWindowsSequence
{
	public partial class GetKbdDataFromUserPupUp : Window
	{
		SequenceElement _newElement;

		SharpHookImplementation.SharphookImplementation sharphookKbd;

		public bool _operationSuccessful { get; private set; }


		public GetKbdDataFromUserPupUp(SequenceElement element)
		{
			InitializeComponent();

			_newElement = element;
			DataContext = _newElement;
			sharphookKbd = new();
		}

		private void Button_Click_StopTrackingAndCloseWindowCorrectly(object sender, RoutedEventArgs e)
		{
			sharphookKbd.hook.Dispose();
			WindowCloseSuccessfully();
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

		private void Button_Click_Cancel(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void WindowCloseSuccessfully()
		{
			_operationSuccessful = true;
			Close();
		}
	}
}
