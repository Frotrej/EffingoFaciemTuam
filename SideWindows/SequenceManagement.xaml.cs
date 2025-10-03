using EffingoFaciemTuam.Model;
using EffingoFaciemTuam.SharpHookImplementation;
using EffingoFaciemTuam.SideWindows;
using EffingoFaciemTuam.SideWindows.AddElementWindowsSequence;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.Windows;

namespace EffingoFaciemTuam.Windows
{
	public partial class SequenceManagement : Window
	{
		public SequenceModel Sequence;

		public SequenceManagement()
		{
			InitializeComponent();

			Sequence = SequenceStore.ShareSequence;
			DataContext = this;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Button_Click_AddElement(object sender, RoutedEventArgs e)
		{
			SequenceElement newElement = new SequenceElement();

			ChooseElementType _chooseElementTypeWindow = new ChooseElementType(newElement);
			_chooseElementTypeWindow.Owner = this;
			_chooseElementTypeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			_chooseElementTypeWindow.ShowDialog();
			if (!_chooseElementTypeWindow._operationSuccessful) return;


			if (!OpenWindowToGetValuesFromUserBasedOnElementType(newElement)) return;

			Sequence.AddElementToSequence(newElement);
		}

		private void Button_Click_RemoveElement(object sender, RoutedEventArgs e)
		{
			Sequence.RemoveLastElementFromSequence();
		}

		private void Button_Click_TestSequence(object sender, RoutedEventArgs e)
		{
			if (Sequence.Sequence.Count == 0)
			{
				MessageBox.Show("brak elementów w sekwencji");
				return;
			}

			InputSimulator.SimulateSequence(Sequence);
		}

		private bool OpenWindowToGetValuesFromUserBasedOnElementType(SequenceElement newElement)
		{
			if (newElement.Type == SequenceElement.ElementType.Mysz)
			{
				GetMouseDataFromUserPopUp _window = new GetMouseDataFromUserPopUp(newElement);
				_window.Owner = this;
				_window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				_window.ShowDialog();
				return _window._operationSuccessful;
			}
			else if (newElement.Type == SequenceElement.ElementType.Klawiatura)
			{
				GetKbdDataFromUserPupUp _window = new GetKbdDataFromUserPupUp(newElement);
				_window.Owner = this;
				_window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				_window.ShowDialog();
				return _window._operationSuccessful;
			}
			return false;
		}
	}
}
