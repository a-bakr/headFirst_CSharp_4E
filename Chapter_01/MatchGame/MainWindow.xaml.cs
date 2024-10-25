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
		private readonly int _startingTime = 20;
		private int _tenthsOfSecondsElapsed;
		private int _matchesFound;
		private double _bestScore;

		public MainWindow()
		{
			InitializeComponent();

			_timer.Interval = TimeSpan.FromSeconds(0.1);
			_timer.Tick += TimerOnTick;

			SetUpGame();
		}

		void TimerOnTick(object? sender, EventArgs e)
		{
			_tenthsOfSecondsElapsed--;
			TimeTextBlock.Text = (_tenthsOfSecondsElapsed / 10f).ToString("0.0s");

			if (GameFinished())
			{
				_timer.Stop();
				double time = (_startingTime - (_tenthsOfSecondsElapsed / 10f));
				TimeTextBlock.Text = $"{time:0.0s} - play again";

				if (time < _bestScore || _bestScore == 0)
				{
					_bestScore = time;
					BestScore.Text = $"Best Score: {_bestScore:0.0s}";
				}
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
				textBlock.Visibility = Visibility.Visible;
				var index = random.Next(animalEmoji.Count);
				var nextEmoji = animalEmoji[index];
				textBlock.Text = nextEmoji;
				animalEmoji.RemoveAt(index);
			}

			_timer.Start();
			_tenthsOfSecondsElapsed = _startingTime * 10;
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
			if (GameFinished())
			{
				SetUpGame();
			}
		}

		private bool GameFinished()
		{
			return _matchesFound == 8 || _tenthsOfSecondsElapsed == 0;
		}
	}
}