using Casino;

var random = new Random();
var odds = 0.75;
var player = new Player("The player", 100);


Console.WriteLine($"Welcome to the casino. The odds are {odds}");

while (player.Cash > 0)
{
	player.WriteMyInfo();
	Console.Write("How much do you want to bet: ");
	var input = Console.ReadLine();
	if (input == "") break;

	if (int.TryParse(input, out int amount))
	{
		var pot = player.GiveCash(amount) * 2;
		if (pot > 0)
		{
			if (random.NextDouble() > odds)
			{
				Console.WriteLine($"You Win {pot}");
				player.ReceiveCash(pot);
			}
			else
			{
				Console.WriteLine($"Bad luck, you lose.");
			}
		}
	}
	else
	{
		Console.WriteLine("Please enter a valid number.");
	}
}
Console.WriteLine("The house always wins");