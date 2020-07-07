namespace SnackShack
{
    public abstract class InputImplementation
    {
        public void CustomerInput(string question, string type, InventoryManager inventory)
        {
            CustomerWants(question, type, inventory);
        }

        public void ProcessAnswer(int answer, string type, InventoryManager inventory)
        {
            var factory = new Factory();
            var store = new Store(factory);
            
            store.OrderSandwich(type, answer, inventory);                      
        }

        public virtual int CustomerWants(string quesiton, string type, InventoryManager inventory)
        {
            return 0;
        }
    }


}