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

        public Sandwich OrderSandwich(string type, int amount)
        {
            var order = _factory.MakeSandwich(type);
            order.amount = amount;
            
            if (order.Estimate())
            {
                order.Make();
                Console.WriteLine(order.time.ToString("m:ss") + " take a well earned break!" + "\n");                                    
            }
            else
            {
                order.Reject();
            }
            return order;
        }
    }
}