using PickRandomCards;

Console.Write("Enter the number of cards to pick: ");
var input = Console.ReadLine()?.TrimStart().TrimEnd();

if (int.TryParse(input, out int numberOfCard))
{
	var pickedCards = CardPicker.PickSomeCard(numberOfCard);
	foreach (var pickedCard in pickedCards)
	{
		Console.WriteLine(pickedCard);
	}
}