using EffingoFaciemTuam.Model;
using EffingoFaciemTuam.SideWindows;
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
			this.Topmost = !this.Topmost;

			GetKeyboardDataFromUserPopUp _window = new GetKeyboardDataFromUserPopUp(Sequence);
			_window.ShowDialog();

			this.Topmost = !this.Topmost;
		}

		private void Button_Click_RemoveElement(object sender, RoutedEventArgs e)
		{
			if (Sequence.Sequence.Count <= 0)
			{
				MessageBox.Show("Brak elementów do usunięcia.");
				return;
			}
			Sequence.Sequence.RemoveAt(Sequence.Sequence.Count - 1);
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

		private void GetValuesFromUserForSequenceElement(SequenceElement element)
		{
			if (element.Type == SequenceElement.ElementType.Klawiatura)
			{
				//get values for keyboard element
				//1 ask user for type of input (char, string, shortcut combination
			}
			if (element.Type == SequenceElement.ElementType.Mysz)
			{
				//get values for mouse element
			}
		}
	}
}
