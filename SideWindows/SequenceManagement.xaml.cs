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
            InitializeComponent();
        }


		private void CloseWindow(object sender, RoutedEventArgs e)
		{
            Close();
		}
	}
}
