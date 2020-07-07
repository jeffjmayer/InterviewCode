namespace SnackShack
{
    public abstract class InputImplementation
    {
        private readonly InventoryManager _inventory = new InventoryManager(45);

        public void CustomerInput(string question, string type)
        {
            CustomerWants(question, type);
        }

        public void ProcessAnswer(int answer, string type)
        {
            var factory = new Factory();
            var store = new Store(factory);
           
            store.OrderSandwich(type, answer, _inventory);                      
        }

        public virtual int CustomerWants(string quesiton, string type)
        {
            return 0;
        }
    }


}