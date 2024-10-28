namespace Casino;

public class Player
{
	public string Name { get; set; }
	public int Cash { get; set; }
	public Player(string name, int cash)
	{
		Name = name;
		Cash = cash;
	}

	/// <summary>
	/// Writes my name and the amount of cash I have to the console
	/// </summary>
	public void WriteMyInfo()
	{
		var text = $"{Name} has {Cash} bucks";
		Console.WriteLine(text);
	}

	/// <summary> 
	/// Gives some of my cash, removing it from my wallet (or printing
	/// a message to the console if I don't have enough cash).
	/// </summary>
	/// <param name="amount">Amount of cash to give.</param>
	/// <returns>
	///	The amount of cash removed from my wallet, or 0 if I don't
	/// have enough cash (or if the amount is invalid).
	/// </returns> 
	public int GiveCash(int amount)
	{
		if (amount <= 0)
		{
			var text = $"{Name} says: {amount} isn't a valid amount";
			Console.WriteLine(text);
			return 0;
		}

		if (amount > Cash)
		{
			var text = $"{Name} says: I don't have enough cash to give you {amount}";
			Console.WriteLine(text);
			return 0;
		}

		Cash -= amount;
		return amount;
	}

	/// <summary>
	/// Receive some cash adding it to my wallet (or printing
	/// a message to the console if the amount is invalid).
	/// </summary>
	/// <param name="amount">Amount of cash to get.</param>
	public void ReceiveCash(int amount)
	{
		if (amount <= 0)
		{
			var text = $"{Name} says: {amount} isn't an amount I'll take";
			Console.WriteLine(text);
		}
		else
		{
			Cash += amount;
		}
	}
}