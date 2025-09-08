using EffingoFaciemTuam.Model;
using EffingoFaciemTuam.SideWindows;
using EffingoFaciemTuam.SideWindows.AddElementWindowsSequence;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Windows;

namespace EffingoFaciemTuam.Windows
{
	public partial class SequenceManagement : Window
	{
		public SequenceModel Sequence { get; set; }

		public SequenceManagement()
		{
			InitializeComponent();

			Sequence = new();
			DataContext = this;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Button_Click_AddElement(object sender, RoutedEventArgs e)
		{
			SequenceElement newElement = new SequenceElement();

			//open window to choose type of element
			ChooseElementType _chooseElementTypeWindow = new ChooseElementType(newElement);
			_chooseElementTypeWindow.ShowDialog();

			OpenWindowToGetValuesFromUserBasedOnElementType(newElement);

			Sequence.AddElementToSequence(newElement);
		}

		private void Button_Click_RemoveElement(object sender, RoutedEventArgs e)
		{
			Sequence.RemoveLastElementFromSequence();
		}

		private void Button_Click_TestSequence(object sender, RoutedEventArgs e)
		{
			foreach (var element in Sequence.Sequence)
			{
				if (element.Type == SequenceElement.ElementType.Klawiatura)
					ExecuteKeyboardSequenceElement(element);
				if (element.Type == SequenceElement.ElementType.Mysz)
					ExecuteMouseSequenceElement(element);
			}
		}

		private void ExecuteMouseSequenceElement(SequenceElement element)
		{
			// simulate mouse action in sharphook based on element
		}

		private void ExecuteKeyboardSequenceElement(SequenceElement element)
		{
			//simualte keyboard action in sharphook based on element
		}

		private void OpenWindowToGetValuesFromUserBasedOnElementType(SequenceElement newElement)
		{
			if (newElement.Type == SequenceElement.ElementType.Mysz)
			{
				GetMouseDataFromUserPopUp _window = new GetMouseDataFromUserPopUp(newElement);
				_window.ShowDialog();
			}
			else if (newElement.Type == SequenceElement.ElementType.Klawiatura)
			{
				GetKbdDataFromUserPupUp _window = new GetKbdDataFromUserPupUp(newElement);
				_window.ShowDialog();
			}
		}
	}
}
