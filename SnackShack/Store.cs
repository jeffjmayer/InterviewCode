using System;

namespace SnackShack
{
    public class Store
    {
        private readonly Factory _factory;

        public Store(Factory factory)
        {
            _factory = factory;
        }

        public Sandwich OrderSandwich(string type, int amount, InventoryManager inventory, bool jacketPotatoes)
        {
            const int none = 0;

            var order = _factory.MakeSandwich(type);
            order.amount = amount;
            
            if (order.Estimate())
            {                
                inventory.reduce(amount);

                if (inventory.Count == none)
                {
                    Console.WriteLine("\n" + "Sandwiches are Out of Stock" + "\n");                                       
                }
                else
                {
                    order.Make();
                    Console.WriteLine(order.time.ToString("m:ss") + " take a well earned break!" + "\n");                    
                }                 
            }
            else
            {
                order.Reject();
            }
            return order;
        }
    }
}