using ElephantApp;

var lucinda = new Elephant("Lucinda", 33);
var lloyd = new Elephant("Lloyd", 40);

Console.Write("Press 1 for Lloyd, 2 for Lucinda, 3 to swap: ");
while (true)
{
    var key = Console.ReadKey(true).KeyChar;
    Console.WriteLine($"You pressed {key}");
    switch (key)
    {
        case '1':
            Console.WriteLine("Calling Lloyd.WhoAMI()");
            lloyd.WhoAmI();
            break;
        case '2':
            Console.WriteLine("Calling Lucinda.WhoAMI()");
            lucinda.WhoAmI();
            break;
        case '3':
            (lucinda, lloyd) = (lloyd, lucinda);
            Console.WriteLine("References have been swapped");
            break;
        default:
            return;
    }
}