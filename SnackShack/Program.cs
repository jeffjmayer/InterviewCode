namespace SnackShack
{
    public class SnackShack
    {
        static void Main()
        {
            var inventory = new InventoryManager(45);
            var input = new Input();
            input.CustomerInput("How many sandwiches would you like? ", "standard", inventory);
        }
    }
}

