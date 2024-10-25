using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MatchGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DispatcherTimer _timer = new DispatcherTimer();
		private int _tenthsOfSecondsElapsed;
		private int _matchesFound;
		public MainWindow()
		{

			InitializeComponent();
			_timer.Interval = TimeSpan.FromSeconds(0.1);
			_timer.Tick += TimerOnTick;

			SetUpGame();
		}

		void TimerOnTick(object? sender, EventArgs e)
		{
			_tenthsOfSecondsElapsed++;
			TimeTextBlock.Text = (_tenthsOfSecondsElapsed / 10f).ToString("0.0s");
			if (_matchesFound == 8)
			{
				_timer.Stop();
				TimeTextBlock.Text += " - play again";
			}
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
				if (textBlock.Name != TimeTextBlock.Name)
				{
					textBlock.Visibility = Visibility.Visible;
					var index = random.Next(animalEmoji.Count);
					var nextEmoji = animalEmoji[index];
					textBlock.Text = nextEmoji;
					animalEmoji.RemoveAt(index);
				}
			}

			_timer.Start();
			_tenthsOfSecondsElapsed = 0;
			_matchesFound = 0;
		}

		TextBlock _lastTextBlockClicked;
		bool _findingMatch;

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var textBlock = sender as TextBlock;
			if (textBlock == null) return;
			if (_findingMatch == false)
			{
				textBlock.Visibility = Visibility.Hidden;
				_lastTextBlockClicked = textBlock;
				_findingMatch = true;
			}
			else if (textBlock.Text == _lastTextBlockClicked.Text)
			{
				textBlock.Visibility = Visibility.Hidden;
				_matchesFound++;
				_findingMatch = false;
			}
			else
			{
				_lastTextBlockClicked.Visibility = Visibility.Visible;
				_findingMatch = false;
			}
		}

		private void TimeTextBlock_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (_matchesFound == 8)
			{
				SetUpGame();
			}
		}
	}
}