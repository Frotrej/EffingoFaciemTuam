using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EffingoFaciemTuam
{
	public static class SelectAllOnFocusBehavior
	{
		public static readonly DependencyProperty EnableProperty =
			DependencyProperty.RegisterAttached(
				"Enable",
				typeof(bool),
				typeof(SelectAllOnFocusBehavior),
				new UIPropertyMetadata(false, OnEnableChanged));

		public static bool GetEnable(DependencyObject obj)
		{
			return (bool)obj.GetValue(EnableProperty);
		}

		public static void SetEnable(DependencyObject obj, bool value)
		{
			obj.SetValue(EnableProperty, value);
		}

		private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox textBox)
			{
				if ((bool)e.NewValue)
				{
					textBox.GotFocus += TextBox_GotFocus;
					textBox.PreviewMouseLeftButtonDown += TextBox_PreviewMouseLeftButtonDown;
				}
				else
				{
					textBox.GotFocus -= TextBox_GotFocus;
					textBox.PreviewMouseLeftButtonDown -= TextBox_PreviewMouseLeftButtonDown;
				}
			}
		}

		private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private static void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var textBox = (TextBox)sender;
			if (!textBox.IsKeyboardFocusWithin)
			{
				e.Handled = true;
				textBox.Focus(); // This will trigger GotFocus → SelectAll
			}
		}
	}
}
