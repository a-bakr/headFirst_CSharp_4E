namespace ElephantApp
{
    internal class Elephant(string name, int earSize)
    {
        public string Name = name;
        public int EarSize = earSize;

        public void WhoAmI()
        {
            Console.WriteLine($"My name is {Name}.");
            Console.WriteLine($"My Ears are {EarSize} inches tall.");
        }
    }
}
