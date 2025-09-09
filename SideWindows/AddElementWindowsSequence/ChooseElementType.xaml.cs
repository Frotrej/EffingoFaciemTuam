using EffingoFaciemTuam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EffingoFaciemTuam.SideWindows.AddElementWindowsSequence
{
	/// <summary>
	/// Logika interakcji dla klasy ChooseElementType.xaml
	/// </summary>
	public partial class ChooseElementType : Window
	{
		//choose if element will be keyboard or mouse element, after that close window, next window will be opened based on this choice in SequenceManagementWindow
		SequenceElement _element;

		public ChooseElementType(SequenceElement element)
		{
			InitializeComponent();

			_element = element;
		}

		private void Button_Click_Mouse(object sender, RoutedEventArgs e)
		{
			_element.Type = SequenceElement.ElementType.Mysz;
			Close();
		}

		private void Button_Click_Kbd(object sender, RoutedEventArgs e)
		{
			_element.Type = SequenceElement.ElementType.Klawiatura;
			Close();
		}
	}
}
