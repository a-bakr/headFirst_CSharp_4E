namespace AbilityScoreTester
{
	internal class AbilityScoreCalculator
	{
		public int RollResult = 14;
		public double DivideBy = 1.75;
		public int AddAmount = 2;
		public int Minimum = 3;
		public int Score;

		public void CalculateAbilityScore()
		{
			// Divide the roll result by the divideBy field
			double divided = RollResult / DivideBy;

			// Add AddAmount to the result of that division
			int added = AddAmount + (int)divided;

			// If the result is too small, use Minimum
			Score = added < Minimum ? Minimum : added;
		}
	}
}
