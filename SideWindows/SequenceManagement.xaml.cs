using EffingoFaciemTuam.Model;
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

			Elements = new ObservableCollection<SequenceElement>
			{
				new SequenceElement(),
			};
			DataContext = this;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Button_Click_AddElement(object sender, RoutedEventArgs e)
		{
			SequenceElement element = new();
			element.StepNumber = Elements.Count + 1;
			Elements.Add(element);
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
	}
}
