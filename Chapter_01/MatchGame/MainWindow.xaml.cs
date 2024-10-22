using System.Windows;
using System.Windows.Controls;

namespace MatchGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			SetUpGame();
		}

		private void SetUpGame()
		{
			var animalEmoji = new List<string>()
			{
				"🐱", "🐱",
				"🦒", "🦒",
				"🐰", "🐰",
				"🦓", "🦓",
				"🐶", "🐶",
				"🐻", "🐻",
				"🐴", "🐴",
				"🐒", "🐒"
			};

			var random = new Random();
			foreach (var textBlock in MainGrid.Children.OfType<TextBlock>())
			{
				var index = random.Next(animalEmoji.Count);
				var nextEmoji = animalEmoji[index];
				textBlock.Text = nextEmoji;
				animalEmoji.RemoveAt(index);
			}
		}
	}
}