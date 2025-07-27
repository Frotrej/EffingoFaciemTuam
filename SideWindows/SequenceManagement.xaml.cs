using EffingoFaciemTuam.Model;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Windows;

namespace EffingoFaciemTuam.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy SequenceManagement.xaml
    /// </summary>
    public partial class SequenceManagement : Window
    {
        public SequenceManagement()
        {
            DataContext = this;
            sequence = new ObservableCollection<String>();
            InitializeComponent();
        }

		private ObservableCollection<String> sequence = new();

		public ObservableCollection<String> Sequence
		{
			get { return sequence; }
			set { sequence = value; }
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
            Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            Sequence.Add("entry to list");

            
		}
	}
}
