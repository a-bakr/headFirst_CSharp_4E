using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExperimentWithControls
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Number.Text = NumberTextBox.Text;
		}

		private void NumberTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !int.TryParse(e.Text, out int result);
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (sender is RadioButton radioButton)
				Number.Text = radioButton.Content.ToString();
		}

		private void SmallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Number.Text = SmallSlider.Value.ToString("0");
		}

		private void BigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Number.Text = BigSlider.Value.ToString("000-000-0000");
		}

		private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (sender is ListBox listBox)
			{
				var item = listBox.SelectedItem as ListBoxItem;
				Number.Text = item?.Content.ToString();
			}
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (sender is ComboBox comboBox)
			{
				var item = comboBox.SelectedItem as ListBoxItem;
				Number.Text = item?.Content.ToString();
			}

		}
	}
}