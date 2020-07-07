namespace SnackShack
{
    public abstract class InputImplementation
    {
        private readonly InventoryManager _inventory = new InventoryManager(45);

        public void CustomerInput(string question, string type, string question2)
        {
            CustomerWants(question, type, question2);
        }

        public void ProcessAnswer(int answer, string type, bool answer2)
        {
            var factory = new Factory();
            var store = new Store(factory);

            store.OrderSandwich(type, answer, _inventory, answer2);                      
        }

        public virtual int CustomerWants(string quesiton, string type, string question2)
        {
            return 0;
        }
    }


}