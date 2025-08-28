using EffingoFaciemTuam.Model;
using EffingoFaciemTuam.SideWindows;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Windows;

namespace EffingoFaciemTuam.Windows
{
	public partial class SequenceManagement : Window
	{
		public ObservableCollection<SequenceElement> Elements { get; set; }

		

		public SequenceManagement()
		{
			InitializeComponent();

			Elements = new();
			DataContext = this;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Button_Click_AddElement(object sender, RoutedEventArgs e)
		{
			GetKeyboardDataFromUserPopUp _window = new GetKeyboardDataFromUserPopUp(Elements);
			_window.ShowDialog();
		}

		private void Button_Click_RemoveElement(object sender, RoutedEventArgs e)
		{
			if (Elements.Count <= 0)
			{
				MessageBox.Show("Brak elementów do usunięcia.");
				return;
			}
			Elements.RemoveAt(Elements.Count - 1);
		}

		private void Button_Click_TestSequence(object sender, RoutedEventArgs e)
		{
			foreach (var element in Elements)
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
