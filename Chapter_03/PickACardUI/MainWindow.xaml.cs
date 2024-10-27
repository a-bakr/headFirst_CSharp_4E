using System.Windows;
using System.Windows.Controls;

namespace PickACardUI
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			CardList.Items.Clear();
			int numberOfCards = (int)NumberOfCards.Value;
			var cards = CardPicker.PickSomeCard(numberOfCards);
			foreach (var card in cards)
			{
				ListBoxItem item = new ListBoxItem
				{
					Content = card
				};
				CardList.Items.Add(item);
			}
		}

		private void NumberOfCards_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int numberOfCards = (int)NumberOfCards.Value;
			Number.Content = numberOfCards.ToString();
		}
	}
}